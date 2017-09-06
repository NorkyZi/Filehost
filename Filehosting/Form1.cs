using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Filehosting.Filehost;

using System.IO;
using System.Threading;

namespace Filehosting
{
    delegate void setPos(int value);
    delegate void setDefaultTab1();
    delegate void setDefaultTab2();
    delegate void setIndex(string ind);
    delegate void download();

    public partial class Form1 : Form
    {
        private string filePathD = "";
        private DialogResult result = 0;
        private string fileNameS;
        private int wl;
        private Thread threadSend, threadDown;

        void setPos(int value, ProgressBar pb)
        {
            if (pb.InvokeRequired)
                pb.Invoke(new Action<int>((s) => pb.Value = value), value);
            else
                pb.Value = value;
        }

        void setDefaultTab1()
        {
            if (progressBar.InvokeRequired)
                progressBar.Invoke(new Action<int>((s) => progressBar.Value = 0), 0);
            else
                progressBar.Value = 0;

            if (progressBar.InvokeRequired)
                progressBar.Invoke(new Action<int>((s) => progressBar.Style = ProgressBarStyle.Marquee), ProgressBarStyle.Marquee);
            else
                progressBar.Style = ProgressBarStyle.Marquee;

            if (btnSelect.InvokeRequired)
                btnSelect.Invoke(new Action<bool>((s) => btnSelect.Enabled = true), true);
            else
                btnSelect.Enabled = true;

            if (tbFileName.InvokeRequired)
                tbFileName.Invoke(new Action<string>((s) => tbFileName.Text = ""), "");
            else
                tbFileName.Text = "";

            if (lSize.InvokeRequired)
                lSize.Invoke(new Action<string>((s) => lSize.Text = ""), "");
            else
                lSize.Text = "";
        }

        void setDefaultTab2()
        {
            if (progressBarDownload.InvokeRequired)
                progressBarDownload.Invoke(new Action<int>((s) => progressBarDownload.Value = 0), 0);
            else
                progressBarDownload.Value = 0;

            if (progressBarDownload.InvokeRequired)
                progressBarDownload.Invoke(new Action<int>((s) => progressBarDownload.Style = ProgressBarStyle.Marquee), ProgressBarStyle.Marquee);
            else
                progressBarDownload.Style = ProgressBarStyle.Marquee;

            if (btnDownload.InvokeRequired)
                btnDownload.Invoke(new Action<bool>((s) => btnDownload.Enabled = true), true);
            else
                btnDownload.Enabled = true;

            if (btnSelectPath.InvokeRequired)
                btnSelectPath.Invoke(new Action<bool>((s) => btnSelectPath.Enabled = true), true);
            else
                btnSelectPath.Enabled = true;

            if (tbFileNameD.InvokeRequired)
                tbFileNameD.Invoke(new Action<string>((s) => tbFileNameD.Text = ""), "");
            else
                tbFileNameD.Text = "";

            if (tbFileNameD.InvokeRequired)
                tbFileNameD.Invoke(new Action<bool>((s) => tbFileNameD.Enabled = true), true);
            else
                tbFileNameD.Enabled = true;

            if (lProcess.InvokeRequired)
                lProcess.Invoke(new Action<bool>((s) => lProcess.Enabled = false), false);
            else
                lProcess.Enabled = false;
        }

        void setInd(string ind)
        {
            if (lDownload.InvokeRequired)
                lDownload.Invoke(new Action<bool>((s) => lDownload.Enabled = true), true);
            else
                lDownload.Enabled = true;


            if (tbInd.InvokeRequired)
                tbInd.Invoke(new Action<string>((s) => tbInd.Text = ind), ind);
            else
                tbInd.Text = ind;
        }

        public Form1()
        {
            InitializeComponent();
            ofd1.Multiselect = false;
            btnSendFile.Enabled = false;
            progressBar.Enabled = false;
            wl = lSize.Width;
            lDownload.Enabled = false;
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.Title = "Выберите файл";
            fbd1.Description = "Выберете необходимую папку для сохранения файла";
            fbd1.ShowNewFolderButton = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                result = ofd1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                
                tbFileName.Text = ofd1.FileName;
                fileNameS = tbFileName.Text;
                Stream stream = null;
                try
                {
                    stream = ofd1.OpenFile();
                    lSize.Text = getSize(stream.Length);
                    lSize.Location = new Point(lSize.Location.X - lSize.Width + wl, lSize.Location.Y);
                    wl = lSize.Width;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
                btnSendFile.Enabled = true;
            }
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            fbd1.ShowDialog();
            filePathD = fbd1.SelectedPath;
            tbPath.Text = filePathD + "\\";
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            btnSendFile.Enabled = false;
            btnSelect.Enabled = false;
            progressBar.Style = ProgressBarStyle.Blocks;
            threadSend = new Thread(new ThreadStart(send));
            threadSend.Start();
        }

        private void send()
        {
            Stream stream = null;
            long lenght = -1;
            string fileName = Path.GetFileName(fileNameS);
            long curByte = 0;
            
            try
            {
                stream = ofd1.OpenFile();
                lenght = (Int32)stream.Length;

                if (stream != null)
                {
                    const int bufferSize = 32768;
                    Filehost.FilehostClient client = new FilehostClient();
                    Filehost.DTO dto = new DTO();
                    curByte = client.getFileInfo(fileName);

                    if (curByte != 0)
                    {
                        MessageBox.Show("Файл " + fileName + " уже есть на сервере, но не закачан полностью. Он будет докачан!");
                    } 
                    dto.Name = fileName;
                    dto.Data = new byte[bufferSize];

                    while (true)
                    {
                        long size;
                        if ((lenght - curByte) < bufferSize)
                            size = lenght - curByte;
                        else size = bufferSize;
                        byte[] buffer = new byte[size];
                        stream.Position = curByte;
                        int bytesRead = stream.Read(buffer, 0, (int)size);
                        dto.Data = buffer;
                        if (bytesRead == 0)
                            break;

                        client.sendFile(dto);
                        curByte += size;

                        setPos(((int)(stream.Position * 100 / stream.Length)), progressBar);
                    } 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Процесс передачи файла остановен!\nПри повторной попытке передачи фала вы продолжите с момента остановки!");
            }
            finally
            {
                setDefaultTab1();

                if (stream != null)
                {
                    stream.Close();
                }
                if (curByte == lenght)
                {
                    Filehost.FilehostClient client = new FilehostClient();
                    string index = client.getFileInd(fileName);
                    setInd(index);
                    MessageBox.Show("Файл " + fileNameS + " был успешно отправлен!\nВы можете получить его по ссылке : " + index, "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            tbFileNameD.Enabled = false;
            btnSelectPath.Enabled = false;
            lProcess.Enabled = true;
            btnDownload.Enabled = false;
            progressBarDownload.Style = ProgressBarStyle.Blocks;
            threadDown = new Thread(new ThreadStart(download));
            threadDown.Start();
        }

        private void download()
        {
            Filehost.FilehostClient client = new FilehostClient();
            Filehost.DTO dto = new DTO();
            Stream stream = null;
            string oldPath = filePathD + "\\" + tbFileNameD.Text;
            long curByte = 0;

            try
            {
                stream = new FileStream(oldPath, FileMode.OpenOrCreate, FileAccess.Write);
                do
                {
                    dto = client.getFile(tbFileNameD.Text, curByte);
                    stream.Position = curByte;
                    stream.Write(dto.Data, 0, dto.Data.Length);
                    curByte += dto.Data.Length;
                    setPos((int)(curByte * 100 / dto.Size), progressBarDownload);
                    dto.Data = null;
                } while (curByte != dto.Size);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (curByte == dto.Size)
                    MessageBox.Show("Файл " + dto.Name + " был успешно загружен!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                string newPath = filePathD + "\\" + dto.Name;
                int i = 1;
                while (File.Exists(newPath))
                {
                    string[] strParse = dto.Name.Split('.');
                    newPath = filePathD + "\\" + strParse[0] + " (" + i.ToString() + ")." + strParse[1];
                }
                File.Move(oldPath, newPath);
                setDefaultTab2();
            }
        }

        private void tbFileNameD_TextChanged(object sender, EventArgs e)
        {
            if (tbFileNameD.Text != "")
                btnDownload.Enabled = true;
        }

        private string getSize(long byteCount)
        {
            string[] suf = { "Byte", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
        }

    }

}

