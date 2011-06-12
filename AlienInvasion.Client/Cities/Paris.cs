using System;
using System.Collections.Generic;
using AlienInvasion.Client.AlienInvaders;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion.Client.Cities
{
	internal class Paris : ICity
	{
		public Paris()
		{
			_defenceWeapons = new IDefenceWeapon[]
						{
							new ObliteratorCannon(this),
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
				return "Paris";
			}
		}

		public string Briefing
		{
			get
			{
				return @"
Paris is under alien attack!

You will face 20 waves of alien invaders.  Each wave will have a random number of 1-10 small flying saucers.

Paris is armed with a single ObliteratorCannon, alongside 10 'Peashooter 500' blasters.

The Obliterator cannon is able to destroy 5 small saucers in one shot.  It reloads quickly and can fire in every wave.

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
				return 2;
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
			int numberOfInvaders = random.Next(10) + 1;

			var invaders = new List<IAlienInvader>();

			for (int invader = 0; invader < numberOfInvaders; invader++)
			{
				invaders.Add(new AlienInvader(FlyingSaucerSize.Small));
			}

			return new AlienInvasionWave(this, invaders.ToArray(), _defenceWeapons);
		}
	}
}
