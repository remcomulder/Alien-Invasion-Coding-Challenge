using AlienInvasion.Client.AlienInvaders;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion.Client
{
	public interface IAlienInvasionWave
	{
		IAlienInvader[] AlienInvaders { get; }
		IDefenceWeapon[] WeaponsAvailableForDefence { get; }
	}

	internal class AlienInvasionWave : IAlienInvasionWave
	{
		public AlienInvasionWave(ICity city, IAlienInvader[] alienInvaders, IDefenceWeapon[] weaponsAvailableForDefence)
		{
			City = city;
			AlienInvaders = alienInvaders;
			WeaponsAvailableForDefence = weaponsAvailableForDefence;
		}

		public ICity City { get; private set; }
		public IAlienInvader[] AlienInvaders { get; private set; }
		public IDefenceWeapon[] WeaponsAvailableForDefence { get; private set; }
	}
}
