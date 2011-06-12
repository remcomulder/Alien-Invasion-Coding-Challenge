using System.Configuration;

namespace AlienInvasion.Server
{
	public static class AppConfig
	{
		public static string AlienInvasionDatabaseConnectionString = ConfigurationManager.AppSettings["AlienInvasionDatabaseConnectionString"];
	}
}
