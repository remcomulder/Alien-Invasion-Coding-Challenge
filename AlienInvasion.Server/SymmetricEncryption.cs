using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace AlienInvasion.Server
{
	/// <summary>
	/// Simple symmetric encryption using the .NET Rijndael provider
	/// </summary>
	public class SymmetricEncryption
	{
		public SymmetricEncryption()
		{
		}

		public SymmetricEncryption(string password)
		{
			GenerateKey(password);
		}

		public string Password
		{
			set
			{
				GenerateKey(value);
			}
		}

		private byte[] Key;
		private byte[] Vector;

		private void GenerateKey(string password)
		{
			SHA384Managed sha = new SHA384Managed();
			byte[] b = sha.ComputeHash(new ASCIIEncoding().GetBytes(password));

			Key = new byte[32];
			Vector = new byte[16];

			Array.Copy(b, 0, Key, 0, 32);
			Array.Copy(b, 32, Vector, 0, 16);
		}

		public string Encrypt(string plainText, string password)
		{
			GenerateKey(password);
			return Encrypt(plainText);
		}

		public string Encrypt(string plainText)
		{
			if (Key == null)
			{
				throw new InvalidOperationException("Password must be provided or set.");
			}

			byte[] data = new ASCIIEncoding().GetBytes(plainText);

			RijndaelManaged crypto = new RijndaelManaged();
			ICryptoTransform encryptor = crypto.CreateEncryptor(Key, Vector);

			MemoryStream memoryStream = new MemoryStream();
			CryptoStream crptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

			crptoStream.Write(data, 0, data.Length);
			crptoStream.FlushFinalBlock();

			crptoStream.Close();
			memoryStream.Close();

			return Convert.ToBase64String(memoryStream.ToArray());
		}

		public string Decrypt(string encryptedText, string password)
		{
			GenerateKey(password);
			return Decrypt(encryptedText);
		}

		public string Decrypt(string encryptedText)
		{
			if (Key == null)
			{
				throw new InvalidOperationException("Password must be provided or set.");
			}

			byte[] cipher = Convert.FromBase64String(encryptedText);

			RijndaelManaged crypto = new RijndaelManaged();
			ICryptoTransform encryptor = crypto.CreateDecryptor(Key, Vector);

			MemoryStream memoryStream = new MemoryStream(cipher);
			CryptoStream crptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Read);

			byte[] data = new byte[cipher.Length];
			int dataLength = crptoStream.Read(data, 0, data.Length);

			memoryStream.Close();
			crptoStream.Close();

			return (new ASCIIEncoding()).GetString(data, 0, dataLength);
		}
	}
}