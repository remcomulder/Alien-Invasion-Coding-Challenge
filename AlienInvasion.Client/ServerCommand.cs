using System;
using System.Collections.Generic;
using System.Text;

namespace AlienInvasion.Client
{
	public class ServerCommand
	{
		public int GetCurrentCityId(string userNames)
		{
			var webAction = new WebAction();
			var encryption = new SymmetricEncryption("blahblah");
			var encryptedUserName = encryption.Encrypt(userNames);
			byte[] currentCity = webAction.HttpPostForm("http://localhost:21822/alieninvasion/SignOnToDefendEarth", new Dictionary<string, string> { { "userName", encryptedUserName } });

			if (currentCity == null)
			{
				throw new Exception("Unable to connect to the alien invasion server");
			}

			if (currentCity.Length != 4)
			{
				throw new Exception("An error occurred while communicating with the alien invasion server: " + Encoding.ASCII.GetString(currentCity));
			}

			return BitConverter.ToInt32(currentCity, 0);
		}

		public int ReportInvasionResultAndGetNextCity(string userNames, bool failedToDefend)
		{
			var webAction = new WebAction();
			var encryption = new SymmetricEncryption("blahblah" + failedToDefend);
			var encryptedUserName = encryption.Encrypt(userNames);
			byte[] currentCity = webAction.HttpPostForm("http://localhost:21822/alieninvasion/ReportInvasionResultAndGetNextCity", new Dictionary<string, string> { { "userName", encryptedUserName }, { "failedToDefend", failedToDefend.ToString() } });

			if (currentCity.Length != 4)
			{
				throw new Exception("An error occurred while communicating with the alien invasion server: " + Encoding.ASCII.GetString(currentCity));
			}

			return BitConverter.ToInt32(currentCity, 0);
		}
	}
}
