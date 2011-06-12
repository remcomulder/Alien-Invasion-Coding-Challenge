using AlienInvasion.Client.AlienInvaders;

namespace AlienInvasion.Client
{
	internal class AlienInvader: IAlienInvader
	{
		internal AlienInvader(FlyingSaucerSize size)
		{
			Size = size;

			switch (size)
			{
				case FlyingSaucerSize.Small:
					Health = 1;
					break;
				case FlyingSaucerSize.Large:
					Health = 3;
					break;
				case FlyingSaucerSize.Huge:
					Health = 8;
					break;
			}
		}

		public FlyingSaucerSize Size
		{
			get;
			private set;
		}

		public int Health
		{
			get;
			set;
		}
	}
}
