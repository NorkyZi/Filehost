using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfFilehosting
{
    public class Filehost : IFilehost
    {
        public DTO getFile(string ind, long curByte)
        {
            string[] listFiles = Directory.GetFiles("D:\\server\\");
            string fileName = "";
            for (int i = 0; i < listFiles.Length; i++)
            {
                if (listFiles[i].Contains(ind))
                {
                    fileName = listFiles[i];
                    break;
                }
            }

            if (fileName == "")
                return null;

            string sep = "&++&";
            string substr = sep + ind;
            int n = fileName.IndexOf(substr);
            string orignFileName = fileName.Remove(n, substr.Length);

            substr = "D:\\server\\";
            n = orignFileName.IndexOf(substr);
            orignFileName = orignFileName.Remove(n, substr.Length);

            DTO dto = new DTO();
            FileInfo info = new FileInfo(fileName);
            long length = info.Length;
            const int bufferSize = 32768;

            using (var fs = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                long size;
                if ((length - curByte) < bufferSize)
                    size = length - curByte;
                else size = bufferSize;
                try
                {
                    var buff = new byte[size];
                    fs.Position = curByte;
                    fs.Read(buff, 0, buff.Length);
                    dto.Name = orignFileName;
                    dto.Size = fs.Length;
                    dto.Data = buff;
                }
                catch{}
                finally
                {
                    if (fs != null)
                        fs.Close();
                }

            }
           
            return dto;
        }

        public void sendFile(DTO file)
        {
            string path = "D:\\server\\" + file.Name;
            DirectoryInfo di = Directory.CreateDirectory("D:\\server\\");
            var stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            stream.Write(file.Data, 0, file.Data.Length);
            if (stream != null)
                stream.Close();
        }

        public string getFileInd(string fileName)
        {
            string path = "D:\\server\\";
            string newPath = path + fileName; 
            if (File.Exists(newPath))
            {
                string result = String.Format(@"{0}", System.Guid.NewGuid());
                string[] listPath = newPath.Split('.');
                string newFileName = listPath[0] + "&++&" + result + "." + listPath[1];
                File.Move(newPath, newFileName);
                return result;
            }
            return "";
        }

   }
}
