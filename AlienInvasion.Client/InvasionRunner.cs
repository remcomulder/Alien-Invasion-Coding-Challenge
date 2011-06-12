using System;
using System.Linq;
using System.Text;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion.Client
{
	public class InvasionRunner
	{
		public void InvadeEarthCityWithDefender(string userNames, CompetitorType competitorType, IEarthDefender defender, bool simulationOnly)
		{
			if (competitorType == CompetitorType.NotSpecified)
				throw new Exception("You need to specify what kind of competitor you are (testing manually, TDD, or continuous tester).  Please set the TypeOfCompetitor value!");

			if (userNames == "PLEASE FILL ME IN" || string.IsNullOrEmpty(userNames))
				throw new Exception("You need to fill in your username(s)");

			userNames = string.Format("({0}) {1}", competitorType, userNames);

			KnownCities.ResetCities();

			var command = new ServerCommand();
			int currentCityId = command.GetCurrentCityId(userNames);

			if (currentCityId >= KnownCities.All.Length)
			{
				Console.WriteLine("You have finished the game.");
				return;
			}
			
			var outputText = new StringBuilder();
			bool defenceFailed = false;

			for (int cityId = 0; cityId <= currentCityId; cityId++)
			{
				var city = KnownCities.All[cityId];
				defenceFailed = invadeCity(city, defender, outputText, cityId != currentCityId);

				if (defenceFailed)
					break;
			}

			if (simulationOnly)
			{
				Console.WriteLine("Simulation complete.");
				return;
			}

			var nextCity = command.ReportInvasionResultAndGetNextCity(userNames, defenceFailed);

			Console.WriteLine(outputText.ToString());

			if (defenceFailed == false)
			{
				var briefing = new InvasionBriefing();
				briefing.ShowBriefingForCity(nextCity);
			}
		}

		private bool invadeCity(ICity city, IEarthDefender defender, StringBuilder outputText, bool singleWave)
		{
			var random = new Random();
			for (int wave = 1; wave <= (singleWave? 1 : city.Waves); wave++)
			{
				describeWave(wave, outputText, singleWave);

				AlienInvasionWave invasionWave = city.GetInvasionWave(random);
				outputText.AppendLine(string.Format("{0} alien invader{1} closing in on {2}...", invasionWave.AlienInvaders.Length, (invasionWave.AlienInvaders.Length > 1) ? "s are" : " is", city.Name));

				bool systemFailed = false;
				DefenceStrategy strategy = null;

				try
				{
					strategy = defender.DefendEarth(invasionWave);
				}
				catch (Exception ex)
				{
					outputText.AppendLine("The defence code threw an exception: " + ex);
					outputText.AppendLine("The defence system is down ... we're all going to die!");
					systemFailed = true;
				}

				if (strategy == null && systemFailed == false)
					outputText.AppendLine("We didn't get a defence strategy from the software!");

				int aliensLeft = invasionWave.AlienInvaders.Length;

				if (systemFailed == false && strategy != null)
				{
					aliensLeft = executeDefenceStrategy(invasionWave, strategy, outputText);
				}

				if (aliensLeft == 0)
				{
					outputText.AppendLine("All aliens in this wave were successfully destroyed!");
				}
				else
				{
					outputText.AppendLine(string.Format("Oh no! {0} alien{1} made it past our defences!", aliensLeft, (aliensLeft > 1) ? "s" : string.Empty));
					outputText.AppendLine("A large part of " + city.Name + " has been destroyed!  We need better quality software ...");
					return true;
				}

				foreach (ExecutableDefenceWeapon asset in city.DefenceWeapons)
					asset.WaveFinished();
			}

			outputText.AppendLine("You have successfully defended " + city.Name.ToUpper() + " from alien attack.");

			return false;
		}

		private void describeWave(int wave, StringBuilder outputText, bool singleWave)
		{
			outputText.AppendLine("------------------------------------");

			if (singleWave)
			{
				outputText.AppendLine("Attack wave on previous city");
			}
			else
			{
				outputText.AppendLine("Wave " + wave);
			}
			outputText.AppendLine("------------------------------------");
		}

		private int executeDefenceStrategy(AlienInvasionWave invasionWave, DefenceStrategy strategy, StringBuilder outputText)
		{
			if (strategy.WeaponsToFireAtThisWave.Any(a => a is ExecutableDefenceWeapon == false))
				throw new Exception("The defence strategy you return from your code can only make use of the weapons supplied to it in the IAlienInvasionWave");

			var invaders = invasionWave.AlienInvaders.Cast<AlienInvader>().ToList();
			var assets = strategy.WeaponsToFireAtThisWave.Cast<ExecutableDefenceWeapon>().ToList();

			while (assets.Count > 0)
			{
				assets.First().Execute(invasionWave.City, invaders, outputText);
				assets.RemoveAt(0);
			}

			return invaders.Count;
		}
	}
}
