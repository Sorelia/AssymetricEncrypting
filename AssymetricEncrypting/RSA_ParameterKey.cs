using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AssymetricEncrypting
{
    class RSA_ParameterKey
    {
        private RSAParameters _publicKey;
        private RSAParameters _privateKey;


        /// <summary>
        /// Assigns a new key
        /// </summary>
        public void AssignNewKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                _publicKey = rsa.ExportParameters(false);
                _privateKey = rsa.ExportParameters(true);
            }
        }

        /// <summary>
        /// Encrypts the data
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] text)
        {
            byte[] data;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_publicKey);

                data = rsa.Encrypt(text, true);
            }
            return data;
        }

        /// <summary>
        /// Decrypts the data
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] text)
        {
            byte[] data;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_privateKey);
                data = rsa.Decrypt(text, true);
            }
            return data;
        }
    }
}
