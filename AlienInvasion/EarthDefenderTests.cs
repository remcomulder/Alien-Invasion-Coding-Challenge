using System;
using System.Collections.Generic;
using System.Linq;
using AlienInvasion.Client;
using AlienInvasion.Client.AlienInvaders;
using AlienInvasion.Client.DefenceAssets;
using NUnit.Framework;
using Rhino.Mocks;

namespace AlienInvasion
{
	[TestFixture]
	public class EarthDefenderTests
	{
		[Test]
		public void WhenLondonIsBeingInvaded()
		{
			var random = new Random();
			var weapons = new List<IDefenceWeapon>
			              	{
			              		CreateDefenceWeapon(DefenceWeaponType.Peashooter1000Blaster),
			              		CreateDefenceWeapon(DefenceWeaponType.Peashooter1000Blaster),
			              		CreateDefenceWeapon(DefenceWeaponType.Peashooter1000Blaster),
			              		CreateDefenceWeapon(DefenceWeaponType.Peashooter1000Blaster),
			              		CreateDefenceWeapon(DefenceWeaponType.Peashooter1000Blaster)
			              	};

			var defender = new EarthDefender();

			for (var wave = 1; wave <= 20; wave++)
			{
				var numberOfInvaders = random.Next(5) + 1;
				var invasionWave = CreateInvasionWave(numberOfInvaders, weapons);
				var defenceStrategy = defender.DefendEarth(invasionWave);

				Assert.That(defenceStrategy.WeaponsToFireAtThisWave.Count(), Is.EqualTo(numberOfInvaders));
			}
		}

		private IAlienInvasionWave CreateInvasionWave(int numberOfInvaders, IEnumerable<IDefenceWeapon> weaponsAvailable)
		{
			var invaders = new List<IAlienInvader>();

			for (var i = 0; i < numberOfInvaders; i++)
			{
				var invader = MockRepository.GenerateStub<IAlienInvader>();
				invader.Stub(x => x.Size).Return(FlyingSaucerSize.Small);
				invaders.Add(invader);
			}

			var invasionWave = MockRepository.GenerateStub<IAlienInvasionWave>();
			invasionWave.Stub(x => x.WeaponsAvailableForDefence).Return(weaponsAvailable.ToArray());
			invasionWave.Stub(x => x.AlienInvaders).Return(invaders.ToArray());

			return invasionWave;
		}

		private IDefenceWeapon CreateDefenceWeapon(DefenceWeaponType weaponType)
		{
			var weapon = MockRepository.GenerateStub<IDefenceWeapon>();
			weapon.Stub(x => x.DefenceWeaponType).Return(weaponType);
			return weapon;
		}
	}
}
