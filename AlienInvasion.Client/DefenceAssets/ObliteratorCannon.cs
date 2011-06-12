using System.Collections.Generic;

namespace AlienInvasion.Client.DefenceAssets
{
	internal class ObliteratorCannon: ExecutableDefenceWeapon
	{
		public ObliteratorCannon(ICity city) : base(city)
		{
		}

		protected override void DoExecute(IList<AlienInvader> invaders)
		{
			_turnsUntilLoaded = 1;

			if (CheckForNoInvaders(invaders))
				return;

			int damageLeft = 5;

			while (damageLeft > 0 && invaders.Count > 0)
			{
				BlastNext(invaders);
				damageLeft--;
			}
		}

		public override DefenceWeaponType DefenceWeaponType
		{
			get { return DefenceWeaponType.ObliteratorCannon; }
		}
	}
}
