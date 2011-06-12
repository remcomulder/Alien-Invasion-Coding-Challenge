using System;
using System.Collections.Generic;
using AlienInvasion.Client.AlienInvaders;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion.Client.Cities
{
	internal class Berlin : ICity
	{
		public Berlin()
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
				return "Berlin";
			}
		}

		public string Briefing
		{
			get
			{
				return @"
Berlin is under alien attack!

You will face 20 waves of alien invaders.  Each wave will have a random number of 1-5 small flying saucers, and 1 single large flying saucer.

The large flying saucer will take 3 times as much damage to destroy as a small one.  This means that you'll need to hit it with an Obliterator
Cannon (also destroying up to 2 small saucers with it), 3 Peashooter blasters, or some combination of both of these weapons.

Berlin is armed with a single Obliterator Cannon, alongside 10 Peashooter 500 blasters.
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
				return 4;
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
			int largeInvaderSlot = random.Next(numberOfInvaders);
			var invaders = new List<IAlienInvader>();

			for (int invader = 0; invader < numberOfInvaders; invader++)
			{
				invaders.Add(new AlienInvader((invader == largeInvaderSlot)? FlyingSaucerSize.Large : FlyingSaucerSize.Small));
			}

			return new AlienInvasionWave(this, invaders.ToArray(), _defenceWeapons);
		}
	}
}
