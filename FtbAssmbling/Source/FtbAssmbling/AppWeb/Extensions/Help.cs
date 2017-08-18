using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace ftd.mvc.Extensions
{
    public static class Help
    {
        public static byte[] ZipFile(byte[] Data, string FileName)
        {
            try
            {
                #region
                //using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                //{
                //    originalFileStream.CopyTo(compressionStream);
                //    Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                //        fileToCompress.Name, fileToCompress.Length.ToString(), compressedFileStream.Length.ToString());
                //}
                #endregion

                MemoryStream outputMemStream = new MemoryStream();
                ZipOutputStream zipStream = new ZipOutputStream(outputMemStream);

                zipStream.SetLevel(9); //0-9, 9 being the highest level of compression
                byte[] bytes = Data;

                // loops through the PDFs I need to create
                {
                    var newEntry = new ZipEntry(FileName);
                    newEntry.DateTime = DateTime.Now;

                    zipStream.PutNextEntry(newEntry);

                    MemoryStream inStream = new MemoryStream(bytes);
                    StreamUtils.Copy(inStream, zipStream, new byte[4096]);
                    inStream.Close();
                    zipStream.CloseEntry();

                }

                zipStream.IsStreamOwner = false;    // False stops the Close also Closing the underlying stream.
                zipStream.Close();          // Must finish the ZipOutputStream before using outputMemStream.

                outputMemStream.Position = 0;

                //return File(outputMemStream.ToArray(), "application/octet-stream", "reports.zip");
                return outputMemStream.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static byte[] UnZipFiles(byte[] Data, string password)
        {
            try
            {
                byte[] bufferArray = new byte[4096];
                MemoryStream inStream = new MemoryStream(Data);
                using (var unzip = new ZipInputStream(inStream))
                {
                    if (password != null && password != string.Empty) unzip.Password = password;
                    ZipEntry entry = unzip.GetNextEntry();
                    using (var output = new MemoryStream())
                    {
                        var readLength = 0;
                        while (true)
                        {
                            readLength = unzip.Read(bufferArray, 0, bufferArray.Length);
                            if (readLength > 0)
                            {
                                output.Write(bufferArray, 0, readLength);
                            }
                            else
                            {
                                break;
                            }
                        }
                        unzip.Close();
                        unzip.Dispose();
                        return output.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public static byte[] DownSize(byte[] Data, int DefalutWidth, string Type)//Stream InputStream)
        {
            try
            {
                MemoryStream InputStream = new MemoryStream(Data);
                System.Drawing.Image image = System.Drawing.Image.FromStream(InputStream);//context.Request.Files[0].InputStream);
                int newwidthimg = 300;
                if (DefalutWidth > 0)
                    newwidthimg = DefalutWidth;

                if ((float)image.Size.Width < newwidthimg) //當圖片寬度小於預設寬度時，不壓縮直接回傳byte array
                    return Data;

                float AspectRatio = (float)image.Size.Width / (float)image.Size.Height;
                int newHeight = Convert.ToInt32(newwidthimg / AspectRatio);
                Bitmap thumbnailBitmap = new Bitmap(newwidthimg, newHeight);
                Graphics thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
                thumbnailGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                thumbnailGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                thumbnailGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newwidthimg, newHeight);
                thumbnailGraph.DrawImage(image, imageRectangle);
                //thumbnailBitmap.Save(xx, System.Drawing.Imaging.ImageFormat.Jpeg);

                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                switch (Type.ToUpper())
                {
                    case "JPG":
                        thumbnailBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "TIF":
                        thumbnailBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "PNG":
                        thumbnailBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case "BMP":
                        thumbnailBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "GIF":
                        thumbnailBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "GPEG":
                        thumbnailBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    default:
                        thumbnailBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                }
                //thumbnailBitmap.Save(HttpContext.Current.Server.MapPath("../DownloadedFiles/") + "123.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Position = 0;
                byte[] data = new byte[stream.Length];
                data = stream.ToArray();
                thumbnailGraph.Dispose();
                thumbnailBitmap.Dispose();
                image.Dispose();

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 計算兩個日期時間差
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Tuple<int, int> Cal2DateDifference_YM(DateTime date1, DateTime date2)
        {
            int years, months;
            // 因為只需取量，不決定誰大誰小，所以如果date1 < date2時要交換將大的擺前面
            if (date1 < date2)
            {
                DateTime tmp = date2;
                date2 = date1;
                date1 = tmp;
            }

            years = date1.Year - date2.Year;
            months = date1.Month - date2.Month;

            if (months < 0)
            {
                years--;
                months += 12;
            }

            return Tuple.Create(years, months);
        }
    }
}