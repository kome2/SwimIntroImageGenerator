namespace SoukeiSwimmerGenerator
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.inputPathTxt = new System.Windows.Forms.Label();
            this.outputPathTxt = new System.Windows.Forms.Label();
            this.InputPath = new System.Windows.Forms.TextBox();
            this.outputPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startNum = new System.Windows.Forms.TextBox();
            this.endNum = new System.Windows.Forms.TextBox();
            this.outputButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.photoDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.メニューToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pptxパス変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkOpen = new System.Windows.Forms.CheckBox();
            this.checkDNS = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.progressTxt = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputPathTxt
            // 
            this.inputPathTxt.AutoSize = true;
            this.inputPathTxt.Location = new System.Drawing.Point(15, 41);
            this.inputPathTxt.Name = "inputPathTxt";
            this.inputPathTxt.Size = new System.Drawing.Size(85, 15);
            this.inputPathTxt.TabIndex = 0;
            this.inputPathTxt.Text = "入力mdbパス";
            // 
            // outputPathTxt
            // 
            this.outputPathTxt.AutoSize = true;
            this.outputPathTxt.Location = new System.Drawing.Point(15, 71);
            this.outputPathTxt.Name = "outputPathTxt";
            this.outputPathTxt.Size = new System.Drawing.Size(103, 15);
            this.outputPathTxt.TabIndex = 1;
            this.outputPathTxt.Text = "出力フォルダパス";
            // 
            // InputPath
            // 
            this.InputPath.Location = new System.Drawing.Point(129, 38);
            this.InputPath.Name = "InputPath";
            this.InputPath.Size = new System.Drawing.Size(329, 22);
            this.InputPath.TabIndex = 2;
            // 
            // outputPath
            // 
            this.outputPath.Location = new System.Drawing.Point(129, 68);
            this.outputPath.Name = "outputPath";
            this.outputPath.Size = new System.Drawing.Size(329, 22);
            this.outputPath.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.button1.Location = new System.Drawing.Point(474, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "参照";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.button2.Location = new System.Drawing.Point(474, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "参照";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "終了プログラムNo.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "開始プログラムNo.";
            // 
            // startNum
            // 
            this.startNum.Location = new System.Drawing.Point(170, 135);
            this.startNum.Name = "startNum";
            this.startNum.Size = new System.Drawing.Size(100, 22);
            this.startNum.TabIndex = 8;
            // 
            // endNum
            // 
            this.endNum.Location = new System.Drawing.Point(170, 162);
            this.endNum.Name = "endNum";
            this.endNum.Size = new System.Drawing.Size(100, 22);
            this.endNum.TabIndex = 9;
            // 
            // outputButton
            // 
            this.outputButton.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.outputButton.Location = new System.Drawing.Point(455, 165);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(89, 23);
            this.outputButton.TabIndex = 10;
            this.outputButton.Text = "実行";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.button4.Location = new System.Drawing.Point(473, 100);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "参照";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // photoDir
            // 
            this.photoDir.Location = new System.Drawing.Point(128, 100);
            this.photoDir.Name = "photoDir";
            this.photoDir.Size = new System.Drawing.Size(329, 22);
            this.photoDir.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "画像フォルダパス";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.メニューToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(577, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // メニューToolStripMenuItem
            // 
            this.メニューToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pptxパス変更ToolStripMenuItem,
            this.終了ToolStripMenuItem});
            this.メニューToolStripMenuItem.Name = "メニューToolStripMenuItem";
            this.メニューToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.メニューToolStripMenuItem.Text = "メニュー";
            // 
            // pptxパス変更ToolStripMenuItem
            // 
            this.pptxパス変更ToolStripMenuItem.Name = "pptxパス変更ToolStripMenuItem";
            this.pptxパス変更ToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.pptxパス変更ToolStripMenuItem.Text = "デフォルトpptxパス変更";
            this.pptxパス変更ToolStripMenuItem.Click += new System.EventHandler(this.pptxパス変更ToolStripMenuItem_Click);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(30, 227);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(514, 23);
            this.progressBar1.TabIndex = 18;
            // 
            // checkOpen
            // 
            this.checkOpen.AutoSize = true;
            this.checkOpen.Location = new System.Drawing.Point(300, 134);
            this.checkOpen.Name = "checkOpen";
            this.checkOpen.Size = new System.Drawing.Size(97, 19);
            this.checkOpen.TabIndex = 19;
            this.checkOpen.Text = "OPEN除外";
            this.checkOpen.UseVisualStyleBackColor = true;
            // 
            // checkDNS
            // 
            this.checkDNS.AutoSize = true;
            this.checkDNS.Location = new System.Drawing.Point(300, 162);
            this.checkDNS.Name = "checkDNS";
            this.checkDNS.Size = new System.Drawing.Size(89, 19);
            this.checkDNS.TabIndex = 20;
            this.checkDNS.Text = "棄権除外";
            this.checkDNS.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // progressTxt
            // 
            this.progressTxt.AutoSize = true;
            this.progressTxt.Location = new System.Drawing.Point(461, 209);
            this.progressTxt.Name = "progressTxt";
            this.progressTxt.Size = new System.Drawing.Size(0, 15);
            this.progressTxt.TabIndex = 22;
            this.progressTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 258);
            this.Controls.Add(this.progressTxt);
            this.Controls.Add(this.checkDNS);
            this.Controls.Add(this.checkOpen);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.photoDir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.endNum);
            this.Controls.Add(this.startNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.outputPath);
            this.Controls.Add(this.InputPath);
            this.Controls.Add(this.outputPathTxt);
            this.Controls.Add(this.inputPathTxt);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Soukei2017Generator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inputPathTxt;
        private System.Windows.Forms.Label outputPathTxt;
        private System.Windows.Forms.TextBox InputPath;
        private System.Windows.Forms.TextBox outputPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox startNum;
        private System.Windows.Forms.TextBox endNum;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox photoDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem メニューToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pptxパス変更ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkOpen;
        private System.Windows.Forms.CheckBox checkDNS;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label progressTxt;
    }
}

