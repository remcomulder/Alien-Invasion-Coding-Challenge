using System;
using System.Collections.Generic;
using AlienInvasion.Client.AlienInvaders;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion.Client.Cities
{
	internal class Rome : ICity
	{
		public Rome()
		{
			_defenceWeapons = new IDefenceWeapon[]
						{
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
							new Peashooter500Blaster(this),
						};
		}

		public string Name
		{
			get
			{
				return "Rome";
			}
		}

		public string Briefing
		{
			get
			{
				return @"
Rome is under alien attack!

You will face 25 waves of alien invaders.  Each wave will have a random number of 1-5 small flying saucers.

Rome is armed with 10 'Peashooter 500' blasters.

The Peashooter 500 is identical to the Peashooter 1000, but after firing it will need to wait out a single wave to 
give it time to reload.  This means that if you try to shoot a Peashooter 500 two waves in a row, it will fail to fire.

Technical tip: The IAlienInvasionWave does not give you any information about whether a weapon is reloaded or not.  If you want
to track this, you'll need to store the state somewhere yourself.  Be aware that the physical instances of IDefenceWeapon are
reused across calls the DefendEarth method, which could be helpful in this.
";
			}
		}

		public int Waves
		{
			get
			{
				return 25;
			}
		}

		public int Id
		{
			get
			{
				return 1;
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
			int numberOfInvaders = random.Next(5) + 1;

			var invaders = new List<IAlienInvader>();

			for (int invader = 0; invader < numberOfInvaders; invader++)
			{
				invaders.Add(new AlienInvader(FlyingSaucerSize.Small));
			}

			return new AlienInvasionWave(this, invaders.ToArray(), _defenceWeapons);
		}
	}
}
