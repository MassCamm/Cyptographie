using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Crypto
{
    class CryptageNet
    {
		private string _texte;
		RSAParameters privateKeys;
		RSAParameters publicKeys;
		byte[] textebyte, donneescrypte, donneesdecrypte;
		public CryptageNet(string Texte)
		{
			textebyte = Encoding.Default.GetBytes (Texte);
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
			privateKeys = rSACryptoServiceProvider.ExportParameters(false);
			publicKeys = rSACryptoServiceProvider.ExportParameters(true);
		}

		public string CrypterNet()
        {
			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				rsa.ImportParameters(publicKeys);
				donneescrypte = rsa.Encrypt(textebyte, false);

				return Convert.ToBase64String(donneescrypte);
			}

			//var messageBytes = System.Text.Encoding.UTF8.GetBytes(this._texte);
			//return System.Convert.ToBase64String(messageBytes);
		}
		public string decode(string texte)
		{
			textebyte = Encoding.Default.GetBytes(texte);
			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				rsa.ImportParameters(privateKeys);
				donneesdecrypte = rsa.Decrypt(textebyte, false);

				return Convert.ToBase64String(donneesdecrypte);
			}
			//var dataBytes = System.Convert.FromBase64String(this._texte);
			//return System.Text.Encoding.UTF8.GetString(dataBytes);
		}
	}
}
