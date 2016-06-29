using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;


namespace PublicClass
{
    public class FTPFileUpDown
    {
        private static DataTable dt = SqlHelper.Query("select Value from TSC_MDM_ConfigValue where ConfigName in ('FTPIP','FTPusername','FTPpwd')").Tables[0];
        private static string serverIP = dt.Rows[0][0].ToString();
        private static string userName = dt.Rows[1][0].ToString();
        private static string password = dt.Rows[2][0].ToString();

        /// <summary>
        /// 上传文件至FTP文件夹内
        /// </summary>
        /// <param name="filename">选择的文件路径</param>
        /// <param name="FolderName">从数据库中获取的FTP文件夹名称</param>
        /// <returns></returns>
        public static FtpStatusCode UploadFileInFTP(string filename, string FolderName)
        {
            Stream requestStream = null;
            FileStream fileStream = null;
            FtpWebResponse uploadResponse = null;
            FtpWebRequest uploadRequest = null;

            string uploadurl;

            try
            {

                uploadurl = "ftp://" + serverIP + "/" + FolderName + "/" + Path.GetFileName(filename);
                uploadRequest = (FtpWebRequest)WebRequest.Create(uploadurl);
                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
                uploadRequest.Proxy = null;
                NetworkCredential nc = new NetworkCredential();
                nc.UserName = userName;
                nc.Password = password;
                uploadRequest.Credentials = nc;
                requestStream = uploadRequest.GetRequestStream();
                fileStream = File.Open(filename, FileMode.Open);

                byte[] buffer = new byte[1024];
                int bytesRead;

                while (true)
                {
                    bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    requestStream.Write(buffer, 0, bytesRead);
                }

                requestStream.Close();
                uploadResponse = (FtpWebResponse)uploadRequest.GetResponse();
                return uploadResponse.StatusCode;
            }
            catch (Exception e)
            {
                logger(e.InnerException.Message);
            }
            finally
            {
                if (uploadResponse != null)
                {
                    uploadResponse.Close();
                }
                if (fileStream != null)
                {
                    fileStream.Close();
                }
                if (requestStream != null)
                {
                    requestStream.Close();
                }

            }
            return FtpStatusCode.Undefined;
        }

        /// <summary>
        /// 上传文件至FTP文件夹内
        /// </summary>
        /// <param name="filename">选择的文件路径</param>
        /// <param name="FolderName">从数据库中获取的FTP文件夹名称</param>
        /// <returns></returns>
        public static int UploadFtp(string filename, string FolderName)
        {
            FtpWebRequest reqFTP = null;

            string url;

            try
            {
                FileInfo fileInf = new FileInfo(filename);

                url = "ftp://" + serverIP + "/" + FolderName + "/" + Path.GetFileName(filename);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                reqFTP.Credentials = new NetworkCredential(userName, password);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                reqFTP.UseBinary = true;
                reqFTP.ContentLength = fileInf.Length;

                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;

                FileStream fs = fileInf.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                Stream strm = reqFTP.GetRequestStream();

                contentLen = fs.Read(buff, 0, buffLength);

                while (contentLen != 0)
                {

                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                strm.Close();
                fs.Close();
                return 0;
            }
            catch (Exception ex)
            {
                if (reqFTP != null)
                {
                    reqFTP.Abort();
                }
                logger(ex.InnerException.Message);
                return -2;
            }
        }

        /// <summary>
        /// 下载文件至选定文件夹
        /// </summary>
        /// <param name="filename">保存目标文件名（绝对路径）</param>
        /// <param name="FolderName">目标FTP文件夹名称</param>
        /// <returns></returns>
        public static int DownloadFtp(string filename, string FolderName)
        {
            FtpWebRequest reqFTP;

            string url;

            try
            {

                url = "ftp://" + serverIP + "/" + FolderName + "/" + Path.GetFileName(filename);

                FileStream outputStream = new FileStream(filename, FileMode.Create);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.KeepAlive = false;
                reqFTP.Credentials = new NetworkCredential(userName, password);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
                return 0;
            }
            catch (Exception ex)
            {
                logger(ex.InnerException.Message);
                return -2;
            }
        }
        public static void logger(string message)
        {
            try
            {
                string logpath = Environment.CurrentDirectory + @"\Log.txt";

                if (!File.Exists(logpath))
                {
                    File.CreateText(logpath);
                }
                using (StreamWriter sw = new StreamWriter(logpath, true, Encoding.UTF8))
                {
                    sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + message);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// 删除FTP指定文件夹内指定文件
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <param name="FolderName">FTP内文件夹名</param>
        public static void FTPDeleteFileName(string filename, string FolderName)
        {
            try
            {
                FtpWebRequest reqFTP;

                string url;


                url = "ftp://" + serverIP + "/" + FolderName + "/" + Path.GetFileName(filename);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                reqFTP.UseBinary = true;
                reqFTP.KeepAlive = false;
                reqFTP.Credentials = new NetworkCredential(userName, password);
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message == "远程服务器返回错误: (550) 文件不可用(例如，未找到文件，无法访问文件)。")
                {

                }
                else
                {
                    MessageBox.Show(ex.Message, "删除错误");
                }
                
            }
        }
        /// <summary>
        /// 检查FTP指定文件夹中是否存在指定文件
        /// </summary>
        /// <param name="FolderName">文件夹名</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static bool FTPFileCheckExist(string FolderName, string filename)
        {
            bool success = false;
            FtpWebRequest ftpWebRequest = null;
            WebResponse webResponse = null;
            StreamReader reader = null;
            try
            {
                
                string url = "ftp://" + serverIP + "/" + FolderName;
                ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                ftpWebRequest.Credentials = new NetworkCredential(userName, password);
                ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                ftpWebRequest.KeepAlive = false;
                webResponse = ftpWebRequest.GetResponse();
                reader = new StreamReader(webResponse.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (Path.GetFileName(line) == filename)
                    {
                        success = true;
                        break;
                    }
                    line = reader.ReadLine();
                }
            }
            catch (Exception)
            {
                success = false;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (webResponse != null)
                {
                    webResponse.Close();
                }
            }
            return success;
        }
    }
}
