namespace AlienInvasion.Server
{
	public class AlienInvasionUser
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Score { get; set; }
		public int CurrentCity { get; set; }
		public int FailuresOnCurrentCity { get; set; }
	}
}
