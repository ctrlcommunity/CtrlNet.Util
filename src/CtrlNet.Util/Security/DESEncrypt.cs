﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace CtrlNet.Util.Security
{
    /// <summary>
    ///     DES加密解密
    /// </summary>
    public class DESEncrypt
    {
        public static string key = "xxxxx11111asqpso[saask..as';sasasa112";

        #region ========加密========
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text">需要加密的内容</param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, key);
        }
        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text">需要加密的内容</param> 
        /// <param name="sKey">秘钥</param> 
        /// <returns></returns> 
        public static string Encrypt(string Text, string sKey)
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                return string.Empty;
            }
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(Md5.Hash(sKey).ToUpper().Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(Md5.Hash(sKey).ToUpper().Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion

        #region ========解密========
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text">需要解密的内容</param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                return Decrypt(Text, key);
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text">需要解密的内容</param> 
        /// <param name="sKey">秘钥</param> 
        /// <returns></returns> 
        public static string Decrypt(string Text, string sKey)
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                return string.Empty;
            }
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(Md5.Hash(sKey).ToUpper().Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(Md5.Hash(sKey).ToUpper().Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion
    }
}
