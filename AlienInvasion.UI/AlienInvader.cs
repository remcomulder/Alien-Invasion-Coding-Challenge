using AlienInvasion.Client;
using AlienInvasion.Client.AlienInvaders;

namespace AlienInvasion.UI
{
	internal class AlienInvader: IAlienInvader
	{
		public AlienInvader(FlyingSaucerSize size)
		{
			Size = size;
		}

		public FlyingSaucerSize Size
		{
			get;
			private set;
		}
	}
}
