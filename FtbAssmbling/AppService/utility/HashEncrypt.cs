using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ftd.utility
{
    public class HashEncrypt
    {
        /// <summary>
        /// 加密文字(預設使用SHA256)
        /// </summary>
        /// <param name="plainText">原始文字</param>
        /// <param name="hashAlgorithm">加密演算法(預設為SHA256)</param>
        /// <returns>加密後文字</returns>
        public static string ComputeHash(string plainText, EncryptType hashAlgorithm)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(plainText);

            // implement Encrypt Algorithm
            HashAlgorithm hash = new SHA256Managed();
            switch (hashAlgorithm)
            {
                case EncryptType.MD5:
                    hash = new MD5CryptoServiceProvider();
                    break;
                case EncryptType.SHA1:
                    hash = new SHA1Managed();
                    break;
                case EncryptType.SHA256:
                    hash = new SHA256Managed();
                    break;
                case EncryptType.SHA512:
                    hash = new SHA512Managed();
                    break;
                default:
                    hash = new SHA256Managed();
                    break;
            }

            byte[] hashBytes = hash.ComputeHash(textBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }

    public enum EncryptType
    {
        MD5,
        SHA1,
        SHA256,
        SHA512
    }
}
