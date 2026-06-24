namespace AItoPDF
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private GroupBox grpSource;
        private Button btnSelectFiles;
        private Button btnSelectFolder;
        private CheckBox chkRecursive;
        private GroupBox grpFiles;
        private ListBox lstFiles;
        private Button btnClearFiles;
        private GroupBox grpSettings;
        private ComboBox cmbCompression;
        private Label lblCompression;
        private TextBox txtOutputDir;
        private Button btnSelectOutput;
        private Label lblOutputDir;
        private Button btnConvert;
        private ProgressBar progressBar;
        private GroupBox grpLog;
        private ListBox lstLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            grpSource = new GroupBox();
            btnSelectFiles = new Button();
            btnSelectFolder = new Button();
            chkRecursive = new CheckBox();
            grpFiles = new GroupBox();
            lstFiles = new ListBox();
            btnClearFiles = new Button();
            grpSettings = new GroupBox();
            lblCompression = new Label();
            cmbCompression = new ComboBox();
            lblOutputDir = new Label();
            txtOutputDir = new TextBox();
            btnSelectOutput = new Button();
            btnConvert = new Button();
            progressBar = new ProgressBar();
            grpLog = new GroupBox();
            lstLog = new ListBox();
            menuStrip1.SuspendLayout();
            grpSource.SuspendLayout();
            grpFiles.SuspendLayout();
            grpSettings.SuspendLayout();
            grpLog.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(750, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Text = "文件(&F)";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Text = "退出(&X)";
            exitToolStripMenuItem.Click += (s, e) => Close();
            // 
            // grpSource
            // 
            grpSource.Controls.Add(btnSelectFiles);
            grpSource.Controls.Add(btnSelectFolder);
            grpSource.Controls.Add(chkRecursive);
            grpSource.Location = new System.Drawing.Point(12, 30);
            grpSource.Name = "grpSource";
            grpSource.Size = new System.Drawing.Size(720, 55);
            grpSource.TabIndex = 1;
            grpSource.TabStop = false;
            grpSource.Text = "选择源文件";
            // 
            // btnSelectFiles
            // 
            btnSelectFiles.Location = new System.Drawing.Point(10, 20);
            btnSelectFiles.Name = "btnSelectFiles";
            btnSelectFiles.Size = new System.Drawing.Size(120, 25);
            btnSelectFiles.TabIndex = 0;
            btnSelectFiles.Text = "选择文件 (多选)";
            btnSelectFiles.UseVisualStyleBackColor = true;
            btnSelectFiles.Click += btnSelectFiles_Click;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Location = new System.Drawing.Point(140, 20);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new System.Drawing.Size(140, 25);
            btnSelectFolder.TabIndex = 1;
            btnSelectFolder.Text = "选择文件夹 (批量)";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // chkRecursive
            // 
            chkRecursive.Location = new System.Drawing.Point(290, 22);
            chkRecursive.Name = "chkRecursive";
            chkRecursive.Size = new System.Drawing.Size(120, 20);
            chkRecursive.TabIndex = 2;
            chkRecursive.Text = "包含子文件夹";
            chkRecursive.UseVisualStyleBackColor = true;
            // 
            // grpFiles
            // 
            grpFiles.Controls.Add(lstFiles);
            grpFiles.Controls.Add(btnClearFiles);
            grpFiles.Location = new System.Drawing.Point(12, 91);
            grpFiles.Name = "grpFiles";
            grpFiles.Size = new System.Drawing.Size(720, 180);
            grpFiles.TabIndex = 2;
            grpFiles.TabStop = false;
            grpFiles.Text = "待转换文件列表";
            // 
            // lstFiles
            // 
            lstFiles.AllowDrop = true;
            lstFiles.FormattingEnabled = true;
            lstFiles.ItemHeight = 15;
            lstFiles.Location = new System.Drawing.Point(10, 20);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new System.Drawing.Size(600, 154);
            lstFiles.TabIndex = 0;
            lstFiles.DragEnter += lstFiles_DragEnter;
            lstFiles.DragDrop += lstFiles_DragDrop;
            // 
            // btnClearFiles
            // 
            btnClearFiles.Location = new System.Drawing.Point(620, 20);
            btnClearFiles.Name = "btnClearFiles";
            btnClearFiles.Size = new System.Drawing.Size(85, 154);
            btnClearFiles.TabIndex = 1;
            btnClearFiles.Text = "清空列表";
            btnClearFiles.UseVisualStyleBackColor = true;
            btnClearFiles.Click += btnClearFiles_Click;
            // 
            // grpSettings
            // 
            grpSettings.Controls.Add(lblCompression);
            grpSettings.Controls.Add(cmbCompression);
            grpSettings.Controls.Add(lblOutputDir);
            grpSettings.Controls.Add(txtOutputDir);
            grpSettings.Controls.Add(btnSelectOutput);
            grpSettings.Location = new System.Drawing.Point(12, 277);
            grpSettings.Name = "grpSettings";
            grpSettings.Size = new System.Drawing.Size(720, 90);
            grpSettings.TabIndex = 3;
            grpSettings.TabStop = false;
            grpSettings.Text = "转换设置";
            // 
            // lblCompression
            // 
            lblCompression.AutoSize = true;
            lblCompression.Location = new System.Drawing.Point(10, 22);
            lblCompression.Name = "lblCompression";
            lblCompression.Size = new System.Drawing.Size(82, 15);
            lblCompression.TabIndex = 0;
            lblCompression.Text = "PDF 压缩等级:";
            // 
            // cmbCompression
            // 
            cmbCompression.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCompression.FormattingEnabled = true;
            cmbCompression.Location = new System.Drawing.Point(100, 19);
            cmbCompression.Name = "cmbCompression";
            cmbCompression.Size = new System.Drawing.Size(200, 23);
            cmbCompression.TabIndex = 1;
            // 
            // lblOutputDir
            // 
            lblOutputDir.AutoSize = true;
            lblOutputDir.Location = new System.Drawing.Point(10, 55);
            lblOutputDir.Name = "lblOutputDir";
            lblOutputDir.Size = new System.Drawing.Size(82, 15);
            lblOutputDir.TabIndex = 2;
            lblOutputDir.Text = "输出文件夹:";
            // 
            // txtOutputDir
            // 
            txtOutputDir.Location = new System.Drawing.Point(100, 52);
            txtOutputDir.Name = "txtOutputDir";
            txtOutputDir.Size = new System.Drawing.Size(510, 25);
            txtOutputDir.TabIndex = 3;
            // 
            // btnSelectOutput
            // 
            btnSelectOutput.Location = new System.Drawing.Point(620, 51);
            btnSelectOutput.Name = "btnSelectOutput";
            btnSelectOutput.Size = new System.Drawing.Size(85, 25);
            btnSelectOutput.TabIndex = 4;
            btnSelectOutput.Text = "选择...";
            btnSelectOutput.UseVisualStyleBackColor = true;
            btnSelectOutput.Click += btnSelectOutput_Click;
            // 
            // btnConvert
            // 
            btnConvert.Location = new System.Drawing.Point(12, 373);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new System.Drawing.Size(720, 35);
            btnConvert.TabIndex = 4;
            btnConvert.Text = "开始转换";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new System.Drawing.Point(12, 414);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(720, 20);
            progressBar.TabIndex = 5;
            // 
            // grpLog
            // 
            grpLog.Controls.Add(lstLog);
            grpLog.Location = new System.Drawing.Point(12, 440);
            grpLog.Name = "grpLog";
            grpLog.Size = new System.Drawing.Size(720, 150);
            grpLog.TabIndex = 6;
            grpLog.TabStop = false;
            grpLog.Text = "转换日志";
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new System.Drawing.Point(10, 20);
            lstLog.Name = "lstLog";
            lstLog.Size = new System.Drawing.Size(700, 124);
            lstLog.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(750, 600);
            Controls.Add(menuStrip1);
            Controls.Add(grpSource);
            Controls.Add(grpFiles);
            Controls.Add(grpSettings);
            Controls.Add(btnConvert);
            Controls.Add(progressBar);
            Controls.Add(grpLog);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AItoPDF - Adobe Illustrator 转 PDF 工具";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            grpSource.ResumeLayout(false);
            grpFiles.ResumeLayout(false);
            grpSettings.ResumeLayout(false);
            grpSettings.PerformLayout();
            grpLog.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
