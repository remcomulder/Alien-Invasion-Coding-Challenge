using System;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion.Client
{
	internal interface ICity
	{
		string Name { get; }
		string Briefing { get; }
		int Waves { get; }
		int Id { get; }
		IDefenceWeapon[] DefenceWeapons { get; }
		AlienInvasionWave GetInvasionWave(Random random);
	}
}
