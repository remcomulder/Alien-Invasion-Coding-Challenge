using AlienInvasion.Client;
using NUnit.Framework;

/*

Earth is under alien attack!

It's up to you to write the software that will operate Earth's defences!

Inside this codebase, you will find class named 'EarthDefender'.  This is where you will write your code.  The aliens will attack in multiple waves,
with each wave calling into the DefendEarth method to obtain a strategy for how the defences will operate.

As part of the method call, you will be provided with an IAlienInvasionWave containing a list of the aliens that make up the wave (along with their
respective sizes), and the weapons that exist for the city you are defending.

The strategy you need to return is nothing more than a collection of weapons that will be fired against the wave of alien invaders.  You need to take
care which weapons you choose in this strategy, as weapons that are unloaded or unavailable will not fire against the invaders - making the city
vulnerable to attack.  If there are any aliens left in an attack wave after all selected weapons have fired, then your defence is considered to be
a failure and 20% of the city you are defending will be destroyed, resulting in a 20% reduction of the score you would otherwise obtain for that city.

If your code successfully destroys all aliens in every invasion wave against a city, then the city is considered to be saved and you will win 100
points (minus any deductions for areas of the city that were destroyed).  You will then automatically move on to defend the next city.

As you progress through defending cities, aliens will continue to launch singular invasion waves against the previous cities you have defended.
This means you will need to be careful to maintain the code you have already written, as any regression will risk damage to your score.  Be advised
that only one actual instance of the EarthDefender will be used across all of these waves, so if you wish to retain any state within the class,
you'll need to intelligently reset it when the aliens start attacking a different city.

Be weary of writing bad code - you'll find you quickly dig a hole for yourself if you do!

Before you begin writing the invasion code, first run the AlienInvasionRequester.SignOnToDefendEarth test - this will sign you up for the challenge
and will brief you for the first city you are defending.  You can rerun this test at any time to be briefed again on the city you are defending.

You can also run the SimulateAlienInvasion test at any time to help get an understanding of how the waves operate and what sort of data you will
need to work with in your code - though be aware that this test will not verify that your code is working correctly!
 
For those who are writing code using test-driven-development:  There is a basic test class already created for you to start adding your code to.  You
can find this in 'EarthDefenderTests.cs' inside this project.  You can ignore the AlienInvasion.UI project as with your automated tests, the UI will be
useless to you.
 
For those who are testing your code without any automated tests:  The AlienInvasion.UI project contains all the code necessary to show a UI 
allowing you to build an invasion wave and pass this into the EarthDefender.  However, this UI does have a limitation in that it can only simulate one
invasion wave at a time.  As you approach the later cities, you may need to upgrade it to do more advanced testing.

The defence code for the first city (London) has already been written for you as a working example.  This means you're already free to run the invasion
code past the first level to see how it operates.
 
You will have 60 minutes to defend as many cities as possible.  Your score will be published on the leaderboard in real time where everyone can see it.

Good luck!

*/

namespace AlienInvasion
{
	[TestFixture]
	public class AlienInvasionRequester
	{
		// Set this value to your name(s) before running any of the tests below
		const string UserNames = "PLEASE FILL ME IN";

		// Set this value to indicate the type of testing you are doing (i.e. Manual, TDD, or ContinuousTDD)
		const CompetitorType TypeOfCompetitor = CompetitorType.NotSpecified;

		/// <summary>
		/// Run this test when you are ready to receive your briefing to defend earth.  If at any time you want to see the briefing again, just re-run this test.
		/// </summary>
		[Test]
		[Explicit]
		public void SignOnToDefendEarth()
		{
			var briefing = new InvasionBriefing();
			briefing.ShowBriefing(TypeOfCompetitor, UserNames);
		}

		/// <summary>
		/// Run this test when you want to simulate an alien invasion against your code.  The simulation will call into your code with parameters that are identical
		/// to those that will be passed in during a real invasion, but no checks will be performed against the output of your code.
		/// This is a useful test for helping you to get an understanding of how the invasion will be behave, so that you can prepare for it.
		/// </summary>
		[Test]
		[Explicit]
		public void SimulateAlienInvasion()
		{
			var invasionRunner = new InvasionRunner();
			invasionRunner.InvadeEarthCityWithDefender(UserNames, TypeOfCompetitor, new EarthDefender(), true);
		}

		/// <summary>
		/// Run this test when you want to request an alien invasion.  ONLY DO THIS AFTER YOU HAVE TESTED YOUR CODE!  If your code fails to stop the invasion,
		/// you will lose 20% of your score for the city you are defending!
		/// </summary>
		[Test]
		[Explicit]
		public void RequestAlienInvasion()
		{
			var invasionRunner = new InvasionRunner();
			invasionRunner.InvadeEarthCityWithDefender(UserNames, TypeOfCompetitor, new EarthDefender(), false);
		}
	}
}
