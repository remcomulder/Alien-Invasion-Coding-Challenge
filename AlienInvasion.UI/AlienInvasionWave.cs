using AlienInvasion.Client;
using AlienInvasion.Client.AlienInvaders;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion.UI
{
	internal class AlienInvasionWave: IAlienInvasionWave
	{
		public AlienInvasionWave(IAlienInvader[] invaders, IDefenceWeapon[] weapons)
		{
			AlienInvaders = invaders;
			WeaponsAvailableForDefence = weapons;
		}

		public IAlienInvader[] AlienInvaders
		{
			get; private set;
		}

		public IDefenceWeapon[] WeaponsAvailableForDefence
		{
			get; private set;
		}
	}
}
