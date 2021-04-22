using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AssymetricEncrypting
{
    class RSA_CSPKey
    {
        const string container = "MyContainer";

#pragma warning disable CA1416 // Validate platform compatibility
        /// <summary>
        /// Assigns a new key
        /// </summary>
        public void AssignKey()
        {

            CspParameters cspParams = new CspParameters(1);
            cspParams.KeyContainerName = container;
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";

            var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = true };
        }

        /// <summary>
        /// Deletes the key
        /// </summary>
        public void DeleteKey()
        {
            var csParams = new CspParameters { KeyContainerName = container };

            var rsa = new RSACryptoServiceProvider(csParams) { PersistKeyInCsp = false };

            rsa.Clear();
        }


        /// <summary>
        /// Encrypts the data
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] text)
        {
            byte[] data;

            var cspParams = new CspParameters { KeyContainerName = container };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                data = rsa.Encrypt(text, false);
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

            var cspParams = new CspParameters { KeyContainerName = container };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                data = rsa.Decrypt(text, false);
            }

            return data;
        }
#pragma warning restore CA1416 // Validate platform compatibility
    }
}
