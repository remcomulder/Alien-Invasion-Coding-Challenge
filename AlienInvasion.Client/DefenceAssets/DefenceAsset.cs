using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlienInvasion.Client.DefenceAssets
{
	public interface IDefenceWeapon
	{
		DefenceWeaponType DefenceWeaponType { get; }
	}

	public enum DefenceWeaponType
	{
		Peashooter500Blaster,
		Peashooter1000Blaster,
		ObliteratorCannon
	}

	internal abstract class ExecutableDefenceWeapon: IDefenceWeapon
	{
		protected int _turnsUntilLoaded;
		private StringBuilder _outputText;

		public ExecutableDefenceWeapon(ICity city)
		{
			City = city;
		}

		public ICity City
		{
			get;
			private set;
		}

		public void Execute(ICity city, IList<AlienInvader> invaders, StringBuilder outputText)
		{
			_outputText = outputText;

			if (city != City)
			{
				LogAction(string.Format("Unable to fire - this asset is in {0}, but the enemy is in {1}!", City.Name, city.Name));
				return;
			}

			if (_turnsUntilLoaded > 0)
			{
				LogAction("Unable to fire - not loaded");
				return;
			}

			DoExecute(invaders);
		}

		public virtual void WaveFinished()
		{
			if (_turnsUntilLoaded > 0)
				_turnsUntilLoaded--;
		}

		protected abstract void DoExecute(IList<AlienInvader> invaders);
		public abstract DefenceWeaponType DefenceWeaponType { get; }

		public virtual bool CanFire
		{
			get { return _turnsUntilLoaded == 0; }
		}

		protected bool CheckForNoInvaders(IList<AlienInvader> invaders)
		{
			if (invaders.Count == 0)
			{
				LogAction("Shot at nothing - there are no invaders left to shoot at");
				return true;
			}

			return false;
		}

		protected void BlastNext(IList<AlienInvader> invaders)
		{
			var invader = invaders.First();
			invader.Health--;

			if (invader.Health <= 0)
			{
				LogAction(string.Format("Blasted a {0} alien to pieces", invader.Size));
				invaders.RemoveAt(0);
			}
			else
			{
				LogAction(string.Format("Damaged a {0} alien", invader.Size));
			}
		}

		public void LogAction(string action)
		{
			_outputText.AppendLine(string.Format("{0}: {1}", DefenceWeaponType, action));
		}
	}
}
