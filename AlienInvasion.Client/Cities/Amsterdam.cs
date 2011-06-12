using System;
using System.Collections.Generic;
using AlienInvasion.Client.AlienInvaders;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion.Client.Cities
{
	internal class Amsterdam : ICity
	{
		public Amsterdam()
		{
			_defenceWeapons = new IDefenceWeapon[]
						{
							new ObliteratorCannon(this),
							new Peashooter1000Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter1000Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new ObliteratorCannon(this),
						};
		}

		public string Name
		{
			get
			{
				return "Amsterdam";
			}
		}

		public string Briefing
		{
			get
			{
				return @"
Amsterdam is under alien attack!

You will face 30 waves of alien invaders.  Each wave will have a random number of 1-14 small flying saucers.

Amsterdam is armed with 2 Obliterator Cannons, 2 Peashooter 1000s and 4 Peashooter 500s.  Note that the order in which these weapons will be
passed in on the IAlienInvasionWave is as following:

ObliteratorCannon
Peashooter1000Blaster
Peashooter500Blaster
Peashooter500Blaster
Peashooter1000Blaster
Peashooter500Blaster
Peashooter500Blaster
ObliteratorCannon

";
			}
		}

		public int Waves
		{
			get
			{
				return 30;
			}
		}

		public int Id
		{
			get
			{
				return 3;
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
			int numberOfInvaders = random.Next(14) + 1;

			var invaders = new List<IAlienInvader>();

			for (int invader = 0; invader < numberOfInvaders; invader++)
			{
				invaders.Add(new AlienInvader(FlyingSaucerSize.Small));
			}

			return new AlienInvasionWave(this, invaders.ToArray(), _defenceWeapons);
		}
	}
}
