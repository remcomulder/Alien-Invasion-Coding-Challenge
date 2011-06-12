using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AlienInvasion.Client;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion.UI
{
	public partial class TestForm : Form
	{
		private readonly IList<FlyingSaucerSize> _invaders = new List<FlyingSaucerSize>();
		private readonly IList<IDefenceWeapon> _weapons = new List<IDefenceWeapon>();

		public TestForm()
		{
			InitializeComponent();

			AlienSizeComboBox.Items.Clear();

			foreach (var size in Enum.GetNames(typeof(FlyingSaucerSize)))
				AlienSizeComboBox.Items.Add(size);

			WeaponComboBox.Items.Clear();

			foreach (var weaponTypeName in GetWeaponTypes().Select(w => w.Name))
				WeaponComboBox.Items.Add(weaponTypeName);
		}

		private IEnumerable<Type> GetWeaponTypes()
		{
			return Assembly
						.GetCallingAssembly()
						.GetTypes()
						.Where(t => t.GetInterfaces().Contains(typeof(IDefenceWeapon)) && t.IsInterface == false);
		}

		private void AddAlienButton_Click(object sender, EventArgs e)
		{
			if (AlienSizeComboBox.SelectedIndex < 0)
				return;

			_invaders.Add((FlyingSaucerSize)AlienSizeComboBox.SelectedIndex);

			AliensList.DataSource = null;
			AliensList.DataSource = _invaders;
		}

		private void AddWeaponButton_Click(object sender, EventArgs e)
		{
			if (WeaponComboBox.SelectedIndex < 0)
				return;

			var selectedWeaponType = GetWeaponTypes().Single(t => t.Name == WeaponComboBox.Text);
			var instance = selectedWeaponType.GetConstructor(new Type[0]).Invoke(new object[0]);

			_weapons.Add((IDefenceWeapon)instance);

			WeaponsList.DataSource = null;
			WeaponsList.DataSource = _weapons;
		}

		private void RunWaveButton_Click(object sender, EventArgs e)
		{
			var wave = new AlienInvasionWave(_invaders.Select(x => new AlienInvader(x)).ToArray(), _weapons.ToArray());

			var defender = new EarthDefender();
			var strategy = defender.DefendEarth(wave);
			var sb = new StringBuilder();

			foreach (var asset in strategy.WeaponsToFireAtThisWave)
			{
				sb.AppendLine(asset.DefenceWeaponType.ToString());	
			}

			WeaponsToFireText.Text = sb.ToString();
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			_invaders.Clear();
			_weapons.Clear();

			AliensList.DataSource = null;
			WeaponsList.DataSource = null;
			WeaponsToFireText.Clear();
		}
	}
}
