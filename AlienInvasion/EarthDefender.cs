using System;
using System.Collections.Generic;
using System.Linq;
using AlienInvasion.Client;
using AlienInvasion.Client.AlienInvaders;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion
{
	public class EarthDefender : IEarthDefender
	{
		private IList<Cannon> _cannons;

		public DefenceStrategy DefendEarth(IAlienInvasionWave invasionWave)
		{
			if (_cannons == null || cannonsDoNotMatchAssets(invasionWave.WeaponsAvailableForDefence))
				_cannons = invasionWave.WeaponsAvailableForDefence.Select(a => new Cannon(a)).OrderBy(c => c.DefenceWeapon.DefenceWeaponType.ToString()).ToList();

			foreach (var cannon in _cannons)
				cannon.Reload();

			var invaders = invasionWave.AlienInvaders.Select(a => new Invader(a)).ToList();
			var assetsToUse = new List<IDefenceWeapon>();

			foreach (var cannon in _cannons)
			{
				if (cannon.BlastNext(invaders))
					assetsToUse.Add(cannon.DefenceWeapon);

				if (invaders.Count == 0)
					break;
			}

			return new DefenceStrategy(assetsToUse);
		}

		private bool cannonsDoNotMatchAssets(IDefenceWeapon[] weaponsAvailableForDefence)
		{
			return (_cannons.Any(c => weaponsAvailableForDefence.Contains(c.DefenceWeapon) == false));
		}

		private class Invader
		{
			public Invader(IAlienInvader invader)
			{
				Health = getInitialInvaderHealth(invader);
				AlienInvader = invader;
			}

			public int Health { get; set; }
			public IAlienInvader AlienInvader { get; set; }

			private int getInitialInvaderHealth(IAlienInvader invader)
			{
				switch (invader.Size)
				{
					case FlyingSaucerSize.Huge:
						return 8;
					case FlyingSaucerSize.Large:
						return 3;
					case FlyingSaucerSize.Small:
						return 1;
				}

				throw new Exception();
			}
		}

		private partial class Cannon
		{
			private readonly int _damage;
			private readonly int _reloadTime;
			private int _timeToReload;

			public Cannon(IDefenceWeapon weapon)
			{
				switch (weapon.DefenceWeaponType)
				{
					case Client.DefenceAssets.DefenceWeaponType.ObliteratorCannon:
						_reloadTime = 1;
						_damage = 5;
						break;
					case Client.DefenceAssets.DefenceWeaponType.Peashooter1000Blaster:
						_reloadTime = 1;
						_damage = 1;
						break;
					case Client.DefenceAssets.DefenceWeaponType.Peashooter500Blaster:
						_reloadTime = 2;
						_damage = 1;
						break;
				}

				DefenceWeapon = weapon;
			}

			public IDefenceWeapon DefenceWeapon
			{
				get;
				private set;
			}

			public void Reload()
			{
				if (_timeToReload > 0)
					_timeToReload--;
			}

			public bool BlastNext(IList<Invader> invaders)
			{
				if (_timeToReload > 0)
					return false;

				int damageLeft = _damage;

				while (damageLeft > 0 && invaders.Any())
				{
					var invader = invaders.First();
					invader.Health--;

					if (invader.Health <= 0)
						invaders.RemoveAt(0);

					damageLeft--;
				}

				_timeToReload = _reloadTime;

				return true;
			}
		}
	}
}
