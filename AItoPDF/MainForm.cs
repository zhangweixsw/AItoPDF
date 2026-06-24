using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AItoPDF
{
    public partial class MainForm : Form
    {
        private readonly Dictionary<string, string> _presetMap = new()
        {
            { "大 (高质量/打印级)", "[High Quality Print]" },
            { "中 (平衡/可编辑)", "[Illustrator Default]" },
            { "小 (高压缩/最小文件)", "[Smallest File Size]" }
        };

        public MainForm()
        {
            InitializeComponent();
            lstFiles.AllowDrop = true;
            cmbCompression.Items.AddRange(new[] { "大 (高质量/打印级)", "中 (平衡/可编辑)", "小 (高压缩/最小文件)" });
            cmbCompression.SelectedIndex = 1;
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Filter = "Illustrator Files (*.ai)|*.ai|All Files (*.*)|*.*",
                Multiselect = true,
                Title = "选择 AI 文件"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lstFiles.Items.Clear();
                foreach (var f in dlg.FileNames) lstFiles.Items.Add(f);
                txtOutputDir.Text = Path.GetDirectoryName(dlg.FileNames[0]) ?? "";
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog { Description = "选择 AI 文件所在文件夹" };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lstFiles.Items.Clear();
                foreach (var f in Directory.GetFiles(dlg.SelectedPath, "*.ai", chkRecursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
                    lstFiles.Items.Add(f);
                txtOutputDir.Text = dlg.SelectedPath;
            }
        }

        private void btnSelectOutput_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog { Description = "选择 PDF 输出文件夹" };
            if (dlg.ShowDialog() == DialogResult.OK)
                txtOutputDir.Text = dlg.SelectedPath;
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            if (lstFiles.Items.Count == 0) { MessageBox.Show("请先选择 AI 文件。"); return; }
            if (string.IsNullOrWhiteSpace(txtOutputDir.Text) || !Directory.Exists(txtOutputDir.Text))
            { MessageBox.Show("请选择有效的输出文件夹。"); return; }

            btnConvert.Enabled = false;
            btnSelectFiles.Enabled = false;
            btnSelectFolder.Enabled = false;
            progressBar.Maximum = lstFiles.Items.Count;
            progressBar.Value = 0;
            lstLog.Items.Clear();

            var files = new List<string>();
            foreach (var item in lstFiles.Items) files.Add(item.ToString()!);
            var preset = _presetMap[cmbCompression.Text];
            var outputDir = txtOutputDir.Text;

            var result = await Task.Run(() =>
            {
                var log = new List<string>();
                int ok = 0, fail = 0;
                dynamic? app = null;
                try
                {
                    log.Add("正在启动 Illustrator...");
                    Type? illustratorType = Type.GetTypeFromProgID("Illustrator.Application");
                    if (illustratorType == null) { log.Add("错误: 未找到 Illustrator，请确认已安装。"); return log; }
                    app = Activator.CreateInstance(illustratorType);
                    if (app == null) { log.Add("错误: Illustrator 启动失败。"); return log; }
                    log.Add("Illustrator 已就绪。");

                    Type? optsType = Type.GetTypeFromProgID("Illustrator.PDFSaveOptions");
                    if (optsType == null) { log.Add("错误: 未找到 PDFSaveOptions。"); return log; }

                    foreach (var aiPath in files)
                    {
                        string pdfName = Path.GetFileNameWithoutExtension(aiPath) + ".pdf";
                        string pdfPath = Path.Combine(outputDir, pdfName);
                        try
                        {
                            log.Add($"转换: {Path.GetFileName(aiPath)}");
#pragma warning disable CS8600, CS8602
                            dynamic doc = app.Open(aiPath);
                            dynamic opts = Activator.CreateInstance(optsType);
                            opts.pDFPreset = preset;
                            doc.SaveAs(pdfPath, opts);
                            doc.Close();
#pragma warning restore CS8600, CS8602
                            ok++;
                            log.Add($"  完成 -> {pdfName}");
                        }
                        catch (Exception ex)
                        {
                            fail++;
                            log.Add($"  失败: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Add($"错误: {ex.Message}");
                }
                finally
                {
                    if (app != null) try { app.Quit(); } catch { }
                }
                log.Add($"完成: 成功 {ok}，失败 {fail}");
                return log;
            });

            foreach (var line in result) lstLog.Items.Add(line);
            progressBar.Value = progressBar.Maximum;
            btnConvert.Enabled = true;
            btnSelectFiles.Enabled = true;
            btnSelectFolder.Enabled = true;
        }

        private void btnClearFiles_Click(object sender, EventArgs e)
        {
            lstFiles.Items.Clear();
            lstLog.Items.Clear();
            progressBar.Value = 0;
        }

        private void lstFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lstFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null || !e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data is not string[] paths) return;
            
            var searchOption = chkRecursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var path in paths)
            {
                if (string.IsNullOrEmpty(path)) continue;
                if (File.Exists(path) && Path.GetExtension(path).ToLowerInvariant() == ".ai")
                {
                    if (!lstFiles.Items.Contains(path))
                        lstFiles.Items.Add(path);
                }
                else if (Directory.Exists(path))
                {
                    foreach (var f in Directory.GetFiles(path, "*.ai", searchOption))
                        if (!lstFiles.Items.Contains(f))
                            lstFiles.Items.Add(f);
                }
            }
            if (lstFiles.Items.Count > 0 && string.IsNullOrEmpty(txtOutputDir.Text))
            {
                var firstItem = lstFiles.Items[0]?.ToString();
                if (!string.IsNullOrEmpty(firstItem))
                    txtOutputDir.Text = Path.GetDirectoryName(firstItem)!;
            }
        }
    }
}
