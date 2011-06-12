using System.Collections.Generic;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion.Client
{
	public class DefenceStrategy
	{
		private IEnumerable<IDefenceWeapon> _weaponsToFireAtThisWave;

		public DefenceStrategy(IEnumerable<IDefenceWeapon> weaponsToFireAtThisWave)
		{
			_weaponsToFireAtThisWave = weaponsToFireAtThisWave;
		}

		public IEnumerable<IDefenceWeapon> WeaponsToFireAtThisWave
		{
			get { return _weaponsToFireAtThisWave; }
		}
	}
}
