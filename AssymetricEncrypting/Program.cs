using System;
using System.Text;

namespace AssymetricEncrypting
{
    class Program
    {
        static void Main(string[] args)
        {
            ///RSA_XML();
            ///RSA_CSP();
            RSA_Param();

            Console.ReadKey();
        }

        private static void RSA_XML()
        {
            var rsa = new RSA_XMLKey();

            const string puKeyPath = @"C:\Users\lion0005\Desktop\RSA\public\publicKey.xml";
            const string prKeyPath = @"C:\Users\lion0005\Desktop\RSA\private\privateKey.xml";

            rsa.AssignKey(puKeyPath, prKeyPath);
            Console.WriteLine("Write your text");
            string text = Console.ReadLine();
            var encryptedText = rsa.Encrypt(puKeyPath, Encoding.UTF8.GetBytes(text));
            var decryptedText = rsa.Decrypt(prKeyPath, encryptedText);

            Console.WriteLine("XML Encryption");
            Console.WriteLine();
            Console.WriteLine("your text: " + text);
            Console.WriteLine();
            Console.WriteLine("Encrypted Text: " + Convert.ToBase64String(encryptedText));
            Console.WriteLine();
            Console.WriteLine("Decrypted Text: " + Encoding.UTF8.GetString(decryptedText));
        }

        private static void RSA_CSP()
        {
            var rsa = new RSA_CSPKey();


            rsa.AssignKey();

            Console.WriteLine("Write your text");
            string text = Console.ReadLine();
            
            var encryptedText = rsa.Encrypt(Encoding.UTF8.GetBytes(text));
            var decryptedText = rsa.Decrypt(encryptedText);

            rsa.DeleteKey();

            Console.WriteLine("CSP Encryption");
            Console.WriteLine();
            Console.WriteLine("your text: " + text);
            Console.WriteLine();
            Console.WriteLine("Encrypted Text: " + Convert.ToBase64String(encryptedText));
            Console.WriteLine();
            Console.WriteLine("Decrypted Text: " + Encoding.UTF8.GetString(decryptedText));
        }

        private static void RSA_Param()
        {
            var rsa = new RSA_ParameterKey();

            rsa.AssignNewKey();

            Console.WriteLine("Write your text");
            string text = Console.ReadLine();
            var encryptedText = rsa.Encrypt(Encoding.UTF8.GetBytes(text));
            var decryptedText = rsa.Decrypt(encryptedText);

            Console.WriteLine("RSA Parameter");
            Console.WriteLine();
            Console.WriteLine("your text: " + text);
            Console.WriteLine();
            Console.WriteLine("Encrypted Text: " + Convert.ToBase64String(encryptedText));
            Console.WriteLine();
            Console.WriteLine("Decrypted Text: " + Encoding.UTF8.GetString(decryptedText));
        }
    }
}
