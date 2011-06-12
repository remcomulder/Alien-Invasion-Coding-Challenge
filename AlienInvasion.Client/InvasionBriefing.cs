using System;

namespace AlienInvasion.Client
{
	public class InvasionBriefing
	{
		public void ShowBriefing(CompetitorType competitorType, string userNames)
		{
			if (competitorType == CompetitorType.NotSpecified)
				throw new Exception("You need to specify what kind of competitor you are (testing manually, TDD, or continuous tester).  Please set the TypeOfCompetitor value!");

			if (userNames == "PLEASE FILL ME IN" || string.IsNullOrEmpty(userNames))
				throw new Exception("You need to fill in your username(s)");

			userNames = string.Format("({0}) {1}", competitorType, userNames);

			var cityQuery = new ServerCommand();
			int currentCityId = cityQuery.GetCurrentCityId(userNames);

			ShowBriefingForCity(currentCityId);
		}

		internal void ShowBriefingForCity(int cityId)
		{
			if (cityId >= KnownCities.All.Length)
			{
				Console.WriteLine("Congratulations!!!! You have finished the game!");
				return;
			}

			var city = KnownCities.All[cityId];
			Console.WriteLine("You are defending the city of " + city.Name.ToUpper());
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine(city.Briefing);
		}
	}
}
