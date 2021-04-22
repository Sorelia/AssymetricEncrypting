using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AssymetricEncrypting
{
    class RSA_XMLKey
    {

        /// <summary>
        /// Assigns a new key, in an xml document
        /// deletes old creates new
        /// </summary>
        /// <param name="puKeyPath"></param>
        /// <param name="prKeyPath"></param>
        public void AssignKey(string puKeyPath, string prKeyPath)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                if (File.Exists(puKeyPath))
                {
                    File.Delete(puKeyPath);
                }

                if (File.Exists(prKeyPath))
                {
                    File.Delete(prKeyPath);
                }

                var puKeyFolder = Path.GetDirectoryName(puKeyPath);
                var prKeyFolder = Path.GetDirectoryName(prKeyPath);

                if (!Directory.Exists(puKeyFolder))
                {
                    Directory.CreateDirectory(puKeyFolder);
                }
                if (!Directory.Exists(prKeyFolder))
                {
                    Directory.CreateDirectory(prKeyFolder);
                }

                File.WriteAllText(puKeyPath, rsa.ToXmlString(false));
                File.WriteAllText(prKeyPath, rsa.ToXmlString(true));
            }
        }

        /// <summary>
        /// Encrypts the data
        /// </summary>
        /// <param name="puKeyPath"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public byte[] Encrypt(string puKeyPath, byte[] text)
        {
            byte[] data;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(puKeyPath));

                data = rsa.Encrypt(text, false);
            }

            return data;
        }
        
        /// <summary>
        /// Decrypts the data
        /// </summary>
        /// <param name="prKeyPath"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public byte[] Decrypt(string prKeyPath, byte[] text)
        {
            byte[] data;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(prKeyPath));
                data = rsa.Decrypt(text, false);
            }
            return data;
        }
    }
}