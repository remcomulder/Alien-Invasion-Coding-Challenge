using System;
using System.Collections.Generic;
using AlienInvasion.Client.AlienInvaders;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion.Client.Cities
{
	internal class Gineva : ICity
	{
		public Gineva()
		{
			_defenceWeapons = new IDefenceWeapon[]
						{
							new ObliteratorCannon(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new ObliteratorCannon(this),
							new Peashooter500Blaster(this),
						};
		}

		public string Name
		{
			get
			{
				return "Gineva";
			}
		}

		public string Briefing
		{
			get
			{
				return @"
Gineva is under alien attack!

You will face 20 waves of alien invaders.  Each wave will have a random number of 1-5 small flying saucers, and 1 single huge flying saucer.

The huge flying saucer will take 8 times as much damage to destroy as a small one.

Gineva is armed with two Obliterator Cannons, alongside 6 Peashooter 500 blasters.
";
			}
		}

		public int Waves
		{
			get
			{
				return 20;
			}
		}

		public int Id
		{
			get
			{
				return 5;
			}
		}

		public IDefenceWeapon[] DefenceWeapons
		{
			get
			{
				return _defenceWeapons;
			}
		}

		private readonly IDefenceWeapon[] _defenceWeapons;

		public AlienInvasionWave GetInvasionWave(Random random)
		{
			int numberOfInvaders = random.Next(6) + 1;
			int giganticInvaderSlot = random.Next(numberOfInvaders);
			var invaders = new List<IAlienInvader>();

			for (int invader = 0; invader < numberOfInvaders; invader++)
			{
				invaders.Add(new AlienInvader((invader == giganticInvaderSlot) ? FlyingSaucerSize.Huge : FlyingSaucerSize.Small));
			}

			return new AlienInvasionWave(this, invaders.ToArray(), _defenceWeapons);
		}
	}
}
