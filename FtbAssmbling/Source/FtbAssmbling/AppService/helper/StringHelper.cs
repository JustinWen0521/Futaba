using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.helper
{
    public class StringHelper
    {
        /// <summary>
        /// 取出指定長度的字串, 並且避免指定長度超過字串長度的問題
        /// </summary>
        /// <param name="str">欲處理字串</param>
        /// <param name="startIdx">開始位置(從0開始)</param>
        /// <param name="length">取出字數</param>
        /// <returns></returns>
        public static string SubString(string str, int startIdx, int length)
        {
            if (str == null || "".equalIgnoreCase(str.Trim()))
            {
                return "";
            }

            str = str.Trim();
            if (str.Length <= startIdx)
            {
                return "";
            }

            if (str.Length - startIdx < length)
            {
                length = str.Length - startIdx;
            }

            return str.Substring(startIdx, length);
        }

        /// <summary>
        /// 字串轉Byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// Byte[]轉字串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
