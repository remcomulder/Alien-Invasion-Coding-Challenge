namespace AlienInvasion.Client
{
	public interface IEarthDefender
	{
		DefenceStrategy DefendEarth(IAlienInvasionWave invasionWave);
	}
}
