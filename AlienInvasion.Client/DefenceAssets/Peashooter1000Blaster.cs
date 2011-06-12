using System.Collections.Generic;

namespace AlienInvasion.Client.DefenceAssets
{
	internal class Peashooter1000Blaster : ExecutableDefenceWeapon
	{
		public Peashooter1000Blaster(ICity city) : base(city)
		{
		}

		public override DefenceWeaponType DefenceWeaponType
		{
			get
			{
				return DefenceWeaponType.Peashooter1000Blaster;
			}
		}

		protected override void DoExecute(IList<AlienInvader> invaders)
		{
			_turnsUntilLoaded = 1;

			if (CheckForNoInvaders(invaders))
				return;

			BlastNext(invaders);
		}
	}
}
