using System.Collections.Generic;

namespace AlienInvasion.Client.DefenceAssets
{
	internal class Peashooter500Blaster: ExecutableDefenceWeapon
	{
		public Peashooter500Blaster(ICity city) : base(city)
		{
		}

		public override DefenceWeaponType DefenceWeaponType
		{
			get { return DefenceWeaponType.Peashooter500Blaster; }
		}

		protected override void DoExecute(IList<AlienInvader> invaders)
		{
			_turnsUntilLoaded = 2;

			if (CheckForNoInvaders(invaders))
				return;

			BlastNext(invaders);
		}
	}
}
