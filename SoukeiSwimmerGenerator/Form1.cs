using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using PPt = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;

namespace SoukeiSwimmerGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 前回出力したときの値を渡す
            InputPath.Text = Properties.Settings.Default.defaultSourceParh;
            outputPath.Text = Properties.Settings.Default.defaultTargetPath;
            startNum.Text = Properties.Settings.Default.defaultStartNum;
            endNum.Text = Properties.Settings.Default.defaultEndNum;
            photoDir.Text = Properties.Settings.Default.defaultPhotoDir;
            checkOpen.Checked = Properties.Settings.Default.defaultCheckOpen;
            checkDNS.Checked = Properties.Settings.Default.defaultCheckDNS;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // データベースのパスの選択
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                InputPath.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 出力データの格納先の選択
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                outputPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void outputButton_Click(object sender, EventArgs e)
        {
            // inputPath にあるmdbを読み込む
            OleDbConnection conn = new OleDbConnection();
            OleDbCommand comm = new OleDbCommand();

            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + InputPath.Text;

            // progress bar の値を初期化
            progressBar1.Minimum = 0;
            progressBar1.Maximum = int.Parse(endNum.Text);
            progressBar1.Value = 0;
            progressTxt.Text = "進捗 " + "  0%";

            for (int i = int.Parse(startNum.Text); i <= int.Parse(endNum.Text); i++)
            {
                // progress bar の値を更新
                int pValue = 100 * i / progressBar1.Maximum;
                progressBar1.Value = i;
                progressTxt.Text = "進捗 " + pValue.ToString() + "%";
                conn.Open();

                // プログラムナンバーがiの競技の種目情報を取得
                comm.CommandText =
                    "select p.種目, p.距離, p.性別, p.クラス番号 " +
                    "from プログラム p " +
                    "where p.競技番号 = " + i;
                comm.Connection = conn;
                OleDbDataReader reader = comm.ExecuteReader();

                // 存在しない競技番号を除外
                if (!reader.HasRows)
                {
                    conn.Close();
                    continue;
                }

                reader.Read();

                // クラスが大学でない場合次の競技に飛ばす
                if (reader.GetValue(3).ToString().Trim() != "1")
                {
                    conn.Close();
                    continue;
                }

                // データの分割
                string style = reader.GetValue(0).ToString().Trim();
                string dist = reader.GetValue(1).ToString().Trim();
                string sex = (reader.GetValue(2).ToString().Trim() == "1") ? "男子" : "女子";

                // リレー→フリーリレー変換
                if (style == "リレー")
                {
                    style = "フリーリレー";
                }

                string game = sex + " " + dist + " " + style;


                // PowerPoint生成
                // 指定したテンプレートpptxをコピー
                // コピーしたpptxをリネーム
                string sourcePptx = Properties.Settings.Default.defaultPptxPath;
                string targetPptx = outputPath.Text + "/" + i.ToString() + ".pptx";
                System.IO.File.Copy(sourcePptx, targetPptx, true);

                // パワーポイントのオープン
                var app = new PPt.Application();
                var pres = app.Presentations;


                var file = pres.Open(targetPptx, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);

                // 種目タイトルスライドを生成
                // 1枚目のスライドの"style"レイヤーを変更し、種目情報を追加
                file.Slides[1].Shapes["style"].TextFrame.TextRange.Text = game;

                conn.Close();


                // 選手情報を取り出す
                conn.Open();

                if (style.EndsWith("リレー"))
                {
                    // 種目がリレーの場合
                    // 個人種目のテンプレートを削除
                    file.Slides[2].Delete();

                    // チーム名とリレーメンバー情報を取得
                    comm.CommandText =
                        "SELECT [チームマスター].[チーム名], 選手マスター.選手番号, 選手マスター_1.選手番号, 選手マスター_2.選手番号, 選手マスター_3.選手番号, 選手マスター.氏名, 選手マスター_1.氏名, 選手マスター_2.氏名, 選手マスター_3.氏名, 記録マスター.棄権印刷マーク " +
                        "FROM 選手マスター AS 選手マスター_2 INNER JOIN(選手マスター AS 選手マスター_3 INNER JOIN (選手マスター AS 選手マスター_1 INNER JOIN (選手マスター INNER JOIN (チームマスター INNER JOIN (記録マスター INNER JOIN プログラム ON 記録マスター.UID = [プログラム].UID) ON[チームマスター].[チーム番号] = 記録マスター.選手番号) ON 選手マスター.選手番号 = 記録マスター.第１泳者) ON 選手マスター_1.選手番号 = 記録マスター.第２泳者) ON 選手マスター_3.選手番号 = 記録マスター.第４泳者) ON 選手マスター_2.選手番号 = 記録マスター.第３泳者 " +
                        "WHERE [プログラム].競技番号 = " + i + " and [プログラム].クラス番号 = 1";
                    comm.Connection = conn;
                    reader = comm.ExecuteReader();

                    while (reader.Read())
                    {
                        // 取得したデータの分割
                        string team = reader.GetValue(0).ToString().Trim();
                        string[] id = {
                            reader.GetValue(1).ToString().Trim(),
                            reader.GetValue(2).ToString().Trim(),
                            reader.GetValue(3).ToString().Trim(),
                            reader.GetValue(4).ToString().Trim()
                        };
                        string name_swim1 = reader.GetValue(5).ToString().Trim();
                        string name_swim2 = reader.GetValue(6).ToString().Trim();
                        string name_swim3 = reader.GetValue(7).ToString().Trim();
                        string name_swim4 = reader.GetValue(8).ToString().Trim();
                        string kiken = reader.GetValue(9).ToString().Trim();

                        // 棄権とOPENの条件フラグに応じた除外処理
                        if (checkDNS.Checked && kiken == "棄権")
                        {
                            continue;
                        }

                        if (checkOpen.Checked && kiken == "OPEN")
                        {
                            continue;
                        }

                        // テンプレートスライドをコピー
                        file.Slides[2].Duplicate();

                        // テキストの置き換え
                        file.Slides[3].Shapes["team"].TextFrame.TextRange.Text = team;
                        file.Slides[3].Shapes["name1"].TextFrame.TextRange.Text = name_swim1;
                        file.Slides[3].Shapes["name2"].TextFrame.TextRange.Text = name_swim2;
                        file.Slides[3].Shapes["name3"].TextFrame.TextRange.Text = name_swim3;
                        file.Slides[3].Shapes["name4"].TextFrame.TextRange.Text = name_swim4;

                        // 画像の差し替え
                        for (int j = 1; j <= 4; j++)
                        {
                            // 泳順に応じた初期画像レイヤの名前を作成
                            string layer = "photo" + j.ToString();

                            // 泳順に応じた画像貼り付けレイヤを取得
                            var photoShape = file.Slides[3].Shapes[layer];

                            // 初期位置の取得
                            var l = photoShape.Left;
                            var t = photoShape.Top;
                            var h = photoShape.Height;
                            var w = photoShape.Width;

                            // 初期画像の入ったレイヤを削除
                            photoShape.Delete();

                            // 選手画像へのパス
                            string photoPath = photoDir.Text + "/" + id[j - 1] + ".gif";

                            // photoPathの写真がなかったら、1.gifを使用する
                            // debug用。写真が全部揃ったら消す
                            // if (!System.IO.File.Exists(photoPath))
                            // {
                            //     photoPath = photoDir.Text + "/1.gif";
                            // }

                            // 画像の挿入と、その新規レイヤの作成
                            var newPhotoShape = file.Slides[3].Shapes.AddPicture(photoPath, MsoTriState.msoFalse, MsoTriState.msoCTrue, l, t, w, h);
                            newPhotoShape.Name = "newphoto" + j.ToString();
                            var targetShape = file.Slides[3].Shapes[newPhotoShape.Name];
                            var nameShape = file.Slides[3].Shapes["name" + j.ToString()];

                            // 画像の重なり順の変更
                            targetShape.ZOrder(MsoZOrderCmd.msoSendToBack);
                            targetShape.ZOrder(MsoZOrderCmd.msoBringForward);
                            targetShape.ZOrder(MsoZOrderCmd.msoBringForward);

                            // nameとphotoのレイヤをグループ化し、そのグループに対して下記のアニメーションを適用
                            string[] twoShape = { "newphoto" + j.ToString(), "name" + j.ToString() };
                            var groupedShape = file.Slides[3].Shapes.Range(twoShape).Group();
                            var effNew = file.Slides[3].TimeLine.MainSequence.AddEffect(groupedShape, PPt.MsoAnimEffect.msoAnimEffectCustom, PPt.MsoAnimateByLevel.msoAnimateLevelNone, PPt.MsoAnimTriggerType.msoAnimTriggerOnPageClick);
                            var aniMotion = effNew.Behaviors.Add(PPt.MsoAnimType.msoAnimTypeMotion);
                            effNew.Exit = MsoTriState.msoFalse;
                            switch (j)
                            {
                                case 1:
                                    aniMotion.MotionEffect.Path = "m -1 -1  L 1 0.48";
                                    break;
                                case 2:
                                    aniMotion.MotionEffect.Path = "m -1 -1  L 1 0.48";
                                    break;
                                case 3:
                                    aniMotion.MotionEffect.Path = "m -1 -1  L 1 0.48";
                                    break;
                                case 4:
                                    aniMotion.MotionEffect.Path = "m -1 -1  L 1 0.48";
                                    break;
                                default:
                                    break;
                            }
                            aniMotion.Timing.Duration = (float)0.25;
                        }

                        // 生成したスライドを末尾へ移動
                        file.Slides[3].MoveTo(file.Slides.Count);
                    }
                    // テンプレートの画像の削除
                    file.Slides[2].Delete();
                }
                else
                {
                    // 個人種目
                    file.Slides[3].Delete();

                    // 選手情報をデータベースから取得
                    comm.CommandText =
                        "select 氏名, 所属名称１, 学年, 水路, k.選手番号, k.棄権印刷マーク " +
                        "from 選手マスター s, 記録マスター k, プログラム p " +
                        "where k.UID = p.UID and k.選手番号 = s.選手番号 and p.競技番号 = " + i + " and p.クラス番号 = 1";

                    comm.Connection = conn;
                    reader = comm.ExecuteReader();


                    while (reader.Read())
                    {
                        // データの分割
                        string name = reader.GetValue(0).ToString().Trim();
                        string team = reader.GetValue(1).ToString().Trim();
                        string grade = reader.GetValue(2).ToString().Trim();
                        string lane = reader.GetValue(3).ToString().Trim();
                        string id = reader.GetValue(4).ToString().Trim();
                        string kiken = reader.GetValue(5).ToString().Trim();

                        // 棄権とOPEN参加の条件に従い除外処理
                        if (checkDNS.Checked && kiken == "棄権")
                        {
                            continue;
                        }
                        if (checkOpen.Checked && kiken == "OPEN")
                        {
                            continue;
                        }

                        // テンプレートスライドのコピー
                        file.Slides[2].Duplicate();

                        // テキストの置き換え
                        file.Slides[3].Shapes["name"].TextFrame.TextRange.Text = name;
                        file.Slides[3].Shapes["team"].TextFrame.TextRange.Text = team + " " + grade + "年";
                        
                        // 画像のテンプレートレイヤから情報を初期位置情報を取得
                        var photoShape = file.Slides[3].Shapes["photo"];
                        var l = photoShape.Left;
                        var t = photoShape.Top;
                        var h = photoShape.Height;
                        var w = photoShape.Width;

                        // テンプレートの削除
                        photoShape.Delete();

                        // 画像のパスの取得
                        string photoPath = photoDir.Text + "/" + id + ".gif";

                        // photoPathの写真がなかったら、1.gifを使用する
                        // debug用。写真が全部揃ったら消す
                        // 今は全部やこの画像
                        if (!System.IO.File.Exists(photoPath))
                        {
                            photoPath = photoDir.Text + "/1.gif";
                        }

                        // 画像の挿入
                        var newPhotoShape = file.Slides[3].Shapes.AddPicture(photoPath, MsoTriState.msoFalse, MsoTriState.msoCTrue, l, t, w, h);
                        newPhotoShape.Name = "photo2";
                        var targetShape = file.Slides[3].Shapes["photo2"];

                        // レイヤの重なり順変更
                        targetShape.ZOrder(MsoZOrderCmd.msoSendToBack);
                        targetShape.ZOrder(MsoZOrderCmd.msoBringForward);
                        targetShape.ZOrder(MsoZOrderCmd.msoBringForward);

                        // アニメーションの適用
                        var effNew = file.Slides[3].TimeLine.MainSequence.AddEffect(targetShape, PPt.MsoAnimEffect.msoAnimEffectCustom, PPt.MsoAnimateByLevel.msoAnimateLevelNone, PPt.MsoAnimTriggerType.msoAnimTriggerWithPrevious);
                        var aniMotion = effNew.Behaviors.Add(PPt.MsoAnimType.msoAnimTypeMotion);
                        effNew.Exit = MsoTriState.msoFalse;
                        aniMotion.MotionEffect.Path = "m -1 -1  L 1 0.5";
                        aniMotion.Timing.Duration = (float)0.25;

                        // スライドを末尾へ移動
                        file.Slides[3].MoveTo(file.Slides.Count);
                    }
                    // テンプレートスライドを削除
                    file.Slides[2].Delete();

                }
                file.Save();
                conn.Close();
                file.Close();
            }

            // 出力成功したときの書くパラメタを保持
            Properties.Settings.Default.defaultSourceParh = InputPath.Text;
            Properties.Settings.Default.defaultTargetPath = outputPath.Text;
            Properties.Settings.Default.defaultStartNum = startNum.Text;
            Properties.Settings.Default.defaultEndNum = endNum.Text;
            Properties.Settings.Default.defaultPhotoDir = photoDir.Text;
            Properties.Settings.Default.defaultCheckOpen = checkOpen.Checked;
            Properties.Settings.Default.Save();

            MessageBox.Show("Generation Success!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 画像データが格納されたディレクトリを選択
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                photoDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pptxパス変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // テンプレートpptxのデータを選択
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.defaultPptxPath = openFileDialog1.FileName;
                Properties.Settings.Default.Save();
            }
        }
    }
}