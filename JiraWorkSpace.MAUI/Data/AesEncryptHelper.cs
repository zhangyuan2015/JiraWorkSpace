using System.Security.Cryptography;
using System.Text;

namespace JiraWorkSpace.MAUI.Data
{
    public static class AesEncryptHelper
    {
        /// <summary>  
        /// AES加密算法  
        /// </summary>  
        /// <param name="encryptStr">需要加密的字符串</param>  
        /// <param name="encryptKey">密钥</param>  
        /// <returns></returns>  
        public static string Encrypt(string encryptStr, string encryptKey)
        {
            if (string.IsNullOrWhiteSpace(encryptStr) || string.IsNullOrWhiteSpace(encryptKey))
                return encryptStr;
            try
            {
                byte[] keyArray = Encoding.UTF8.GetBytes(encryptKey);
                byte[] toEncryptArray = Encoding.UTF8.GetBytes(encryptStr);

                using (RijndaelManaged rDel = new RijndaelManaged { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    using (ICryptoTransform cTransform = rDel.CreateEncryptor())
                    {
                        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log4NetHelper.Error("Encrypt err", ex);
                return encryptStr;
            }
        }

        /// <summary>  
        /// AES解密算法  
        /// </summary>  
        /// <param name="decryptStr">需要解密的字符串</param>  
        /// <param name="decryptKey">密钥</param>  
        /// <returns></returns>  
        public static string Decrypt(string decryptStr, string decryptKey)
        {
            if (string.IsNullOrWhiteSpace(decryptStr) || string.IsNullOrWhiteSpace(decryptKey))
                return decryptStr;
            try
            {
                byte[] keyArray = Encoding.UTF8.GetBytes(decryptKey);
                byte[] toEncryptArray = Convert.FromBase64String(decryptStr);

                using (RijndaelManaged rDel = new RijndaelManaged { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    using (ICryptoTransform cTransform = rDel.CreateDecryptor())
                    {
                        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                        return Encoding.UTF8.GetString(resultArray);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log4NetHelper.Error("Decrypt err", ex);
                return decryptStr;
            }
        }
    }
}