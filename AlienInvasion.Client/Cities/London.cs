using System;
using System.Collections.Generic;
using AlienInvasion.Client.AlienInvaders;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion.Client.Cities
{
	internal class London: ICity
	{
		public London()
		{
			_defenceWeapons = new IDefenceWeapon[]
						{
							new Peashooter1000Blaster(this),
							new Peashooter1000Blaster(this),
							new Peashooter1000Blaster(this),
							new Peashooter1000Blaster(this),
							new Peashooter1000Blaster(this),
						};
		}

		public string Name
		{
			get { return "London"; }
		}

		public string Briefing
		{
			get { return @"
London is under alien attack!

You will face 20 waves of alien invaders.  Each wave will have a random number of 1-5 small flying saucers.

London is armed with 5 'Peashooter 1000' blasters.  One shot from one blaster will destroy one saucer, and each blaster can fire in every wave.

If your software fails to return a coherent strategy or throws any kind of exception, we'll all be doomed!
"; }
		}

		public int Waves
		{
			get { return 20; }
		}

		public int Id
		{
			get { return 0; }
		}

		public IDefenceWeapon[] DefenceWeapons
		{
			get { return _defenceWeapons; }
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
