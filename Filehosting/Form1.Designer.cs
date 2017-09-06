namespace Filehosting
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpSend = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.lDownload = new System.Windows.Forms.Label();
            this.tbInd = new System.Windows.Forms.TextBox();
            this.lSize = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tpDownload = new System.Windows.Forms.TabPage();
            this.lProcess = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFileNameD = new System.Windows.Forms.TextBox();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.fbd1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tpSend.SuspendLayout();
            this.tpDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(8, 6);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(321, 44);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Выбрать файл";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Enabled = false;
            this.btnSendFile.Location = new System.Drawing.Point(8, 125);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(321, 44);
            this.btnSendFile.TabIndex = 1;
            this.btnSendFile.Text = "Отправить";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Файл для отправки: ";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(8, 87);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(255, 20);
            this.tbFileName.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpSend);
            this.tabControl1.Controls.Add(this.tpDownload);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(348, 292);
            this.tabControl1.TabIndex = 4;
            // 
            // tpSend
            // 
            this.tpSend.Controls.Add(this.label4);
            this.tpSend.Controls.Add(this.lDownload);
            this.tpSend.Controls.Add(this.tbInd);
            this.tpSend.Controls.Add(this.lSize);
            this.tpSend.Controls.Add(this.progressBar);
            this.tpSend.Controls.Add(this.btnSelect);
            this.tpSend.Controls.Add(this.label1);
            this.tpSend.Controls.Add(this.btnSendFile);
            this.tpSend.Controls.Add(this.tbFileName);
            this.tpSend.Location = new System.Drawing.Point(4, 22);
            this.tpSend.Name = "tpSend";
            this.tpSend.Padding = new System.Windows.Forms.Padding(3);
            this.tpSend.Size = new System.Drawing.Size(340, 266);
            this.tpSend.TabIndex = 0;
            this.tpSend.Text = "Отправить файл";
            this.tpSend.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Размер:";
            // 
            // lDownload
            // 
            this.lDownload.AutoSize = true;
            this.lDownload.Location = new System.Drawing.Point(8, 213);
            this.lDownload.Name = "lDownload";
            this.lDownload.Size = new System.Drawing.Size(126, 13);
            this.lDownload.TabIndex = 7;
            this.lDownload.Text = "Ссылка на скачивание:";
            // 
            // tbInd
            // 
            this.tbInd.Location = new System.Drawing.Point(8, 238);
            this.tbInd.Name = "tbInd";
            this.tbInd.ReadOnly = true;
            this.tbInd.Size = new System.Drawing.Size(319, 20);
            this.tbInd.TabIndex = 6;
            // 
            // lSize
            // 
            this.lSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lSize.AutoSize = true;
            this.lSize.Location = new System.Drawing.Point(327, 90);
            this.lSize.Name = "lSize";
            this.lSize.Size = new System.Drawing.Size(0, 13);
            this.lSize.TabIndex = 5;
            this.lSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(8, 178);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(321, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 4;
            // 
            // tpDownload
            // 
            this.tpDownload.Controls.Add(this.lProcess);
            this.tpDownload.Controls.Add(this.tbPath);
            this.tpDownload.Controls.Add(this.label3);
            this.tpDownload.Controls.Add(this.btnSelectPath);
            this.tpDownload.Controls.Add(this.progressBarDownload);
            this.tpDownload.Controls.Add(this.btnDownload);
            this.tpDownload.Controls.Add(this.label2);
            this.tpDownload.Controls.Add(this.tbFileNameD);
            this.tpDownload.Location = new System.Drawing.Point(4, 22);
            this.tpDownload.Name = "tpDownload";
            this.tpDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tpDownload.Size = new System.Drawing.Size(340, 266);
            this.tpDownload.TabIndex = 1;
            this.tpDownload.Text = "Загрузить файл";
            this.tpDownload.UseVisualStyleBackColor = true;
            // 
            // lProcess
            // 
            this.lProcess.AutoSize = true;
            this.lProcess.Enabled = false;
            this.lProcess.Location = new System.Drawing.Point(8, 71);
            this.lProcess.Name = "lProcess";
            this.lProcess.Size = new System.Drawing.Size(113, 13);
            this.lProcess.TabIndex = 7;
            this.lProcess.Text = "Состояние загрузки:";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(108, 181);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(223, 20);
            this.tbPath.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выбранный путь:";
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(8, 125);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(323, 41);
            this.btnSelectPath.TabIndex = 4;
            this.btnSelectPath.Text = "Выбрать папку для сохранения";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Enabled = false;
            this.progressBarDownload.Location = new System.Drawing.Point(8, 87);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(323, 23);
            this.progressBarDownload.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarDownload.TabIndex = 3;
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Location = new System.Drawing.Point(8, 216);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(323, 43);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Загрузить";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Введите идентификатор:";
            // 
            // tbFileNameD
            // 
            this.tbFileNameD.Location = new System.Drawing.Point(8, 40);
            this.tbFileNameD.Name = "tbFileNameD";
            this.tbFileNameD.Size = new System.Drawing.Size(323, 20);
            this.tbFileNameD.TabIndex = 0;
            this.tbFileNameD.TextChanged += new System.EventHandler(this.tbFileNameD_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 293);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Файлообменик";
            this.tabControl1.ResumeLayout(false);
            this.tpSend.ResumeLayout(false);
            this.tpSend.PerformLayout();
            this.tpDownload.ResumeLayout(false);
            this.tpDownload.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpSend;
        private System.Windows.Forms.TabPage tpDownload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFileNameD;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lSize;
        private System.Windows.Forms.Label lDownload;
        private System.Windows.Forms.TextBox tbInd;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.Windows.Forms.FolderBrowserDialog fbd1;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lProcess;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

