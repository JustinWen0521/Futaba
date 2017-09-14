using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace ftd.utility
{
    public class FtpService
    {
        /// <summary>
        /// 透過FTP上傳檔案
        /// </summary>
        public static bool uploadFile(Stream stream, string ftpIP, string fileName, string id, string pwd)
        {
            Stream ftpStream = null;
            StreamReader sourceStream = null;
            try
            {
                sourceStream = new StreamReader(stream);
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());

                FtpWebRequest Request = (FtpWebRequest)WebRequest.Create("ftp://" + ftpIP + fileName);
                Request.Credentials = new NetworkCredential(id, pwd);
                Request.UseBinary = true;
                Request.Method = WebRequestMethods.Ftp.UploadFile;
                Request.KeepAlive = true;
                Request.Timeout = (60000 * 1); //60000 * 1,表示1分鐘

                ftpStream = Request.GetRequestStream();
                ftpStream.Write(fileContents, 0, fileContents.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (ftpStream != null)
                {
                    ftpStream.Close();
                }
                if (sourceStream != null)
                {
                    sourceStream.Close();
                }
            }

            return true;
        }

        /// <summary>
        /// 透過FTP下載檔案
        /// </summary>
        public static String downloadFile(string ftpIP, string fileName, string id, string pwd)
        {
            string xmlString = "";
            MemoryStream stream = null;
            FtpWebResponse downloadResponse = null;
            try
            {
                FtpWebRequest Request = (FtpWebRequest)WebRequest.Create("ftp://" + ftpIP + fileName);
                Request.Credentials = new NetworkCredential(id, pwd);
                Request.UseBinary = true;
                Request.Method = WebRequestMethods.Ftp.DownloadFile;
                Request.KeepAlive = true;
                Request.Timeout = (60000 * 1); //60000 * 1,表示1分鐘

                downloadResponse = (FtpWebResponse)Request.GetResponse();
                Stream downloadStream = downloadResponse.GetResponseStream();

                stream = new MemoryStream();
                byte[] chunk = new byte[4096];
                int bytesRead;
                while ((bytesRead = downloadStream.Read(chunk, 0, chunk.Length)) > 0)
                {
                    stream.Write(chunk, 0, bytesRead);
                }

                xmlString = Encoding.UTF8.GetString(stream.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                if (downloadResponse != null)
                {
                    downloadResponse.Close();
                }
            }

            return xmlString;
        }

        /// <summary>
        /// 搬移FTP Server上的檔案
        /// </summary>
        public static bool moveFile(string ftpIP, string oldFileName, string newFileName, string id, string pwd)
        {
            try
            {
                // delete the old one
                deleteFile(ftpIP, newFileName, id, pwd);

                FtpWebRequest Request = (FtpWebRequest)WebRequest.Create("ftp://" + ftpIP + oldFileName);
                Request.Credentials = new NetworkCredential(id, pwd);
                Request.UseBinary = true;
                Request.Method = WebRequestMethods.Ftp.Rename;
                Request.KeepAlive = true;
                Request.Timeout = (60000 * 1); //60000 * 1,表示1分鐘

                Request.RenameTo = newFileName;

                using (StreamReader sr = new StreamReader(Request.GetResponse().GetResponseStream()))
                {
                    string result = sr.ReadToEnd();

                    if (result != null && !"".equalIgnoreCase(result.Trim()))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// 列出FTP Server上的檔案清單
        /// </summary>
        public static List<string> listFile(string ftpIP, string path, string id, string pwd)
        {
            StreamReader reader = null;
            Stream responseStream = null;
            FtpWebResponse response = null;
            List<string> files = new List<string>();

            try
            {
                FtpWebRequest Request = (FtpWebRequest)WebRequest.Create("ftp://" + ftpIP + path);
                Request.Credentials = new NetworkCredential(id, pwd);
                Request.UseBinary = true;
                Request.Method = WebRequestMethods.Ftp.ListDirectory;
                Request.KeepAlive = true;
                Request.Timeout = (60000 * 1); //60000 * 1,表示1分鐘

                response = (FtpWebResponse)Request.GetResponse();
                responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream);

                string line = "";
                string[] segments = response.ResponseUri.Segments;
                do
                {
                    line = reader.ReadLine();
                    if (!String.IsNullOrEmpty(line))
                    {
                        string filename = line.Replace(segments[segments.Length - 1], "");
                        files.Add(filename);
                    }
                } while (!string.IsNullOrEmpty(line));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (responseStream != null)
                {
                    responseStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }

            return files;
        }

        public static bool deleteFile(string ftpIP, string fileName, string id, string pwd)
        {
            try
            {
                FtpWebRequest Request = (FtpWebRequest)WebRequest.Create("ftp://" + ftpIP + fileName);
                Request.Credentials = new NetworkCredential(id, pwd);
                Request.UseBinary = true;
                Request.Method = WebRequestMethods.Ftp.DeleteFile;
                Request.KeepAlive = true;
                Request.Timeout = (60000 * 1); //60000 * 1,表示1分鐘

                using (StreamReader sr = new StreamReader(Request.GetResponse().GetResponseStream()))
                {
                    string result = sr.ReadToEnd();

                    if (result != null && !"".equalIgnoreCase(result.Trim()))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
