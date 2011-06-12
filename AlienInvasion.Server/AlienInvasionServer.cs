using System;
using System.Collections.Generic;
using System.Linq;

namespace AlienInvasion.Server
{
	public class AlienInvasionServer
	{
		public int GetCurrentCity(string userName)
		{
			return getUser(userName).CurrentCity;
		}

		private AlienInvasionUser getUser(string userName)
		{
			IList<AlienInvasionUser> users;

			using (var db = new AlienInvasionDatabase())
			{
				users = db.GetAlienInvasionUsers();
			}

			AlienInvasionUser user = users.SingleOrDefault(u => string.Compare(u.Name, userName, true) == 0);
			if (user == null)
			{
				user = createUser(userName);
			}

			return user;
		}

		private AlienInvasionUser createUser(string userName)
		{
			using (var db = new AlienInvasionDatabase())
			{
				var user = new AlienInvasionUser
				                        	{
				                        		Name = userName,
				                        		FailuresOnCurrentCity = 0,
				                        		CurrentCity = 0,
				                        		Score = 0
				                        	};
				db.SaveAlienInvasionUser(user);

				return user;
			}
		}

		public int ReportInvasionResultAndGetNextCity(string userName, bool failedToDefend)
		{
			var user = getUser(userName);

			if (failedToDefend)
			{
				user.FailuresOnCurrentCity += 1;
			}
			else
			{
				user.CurrentCity++;
				user.Score += Math.Max(0, 100 - user.FailuresOnCurrentCity * 20);
				user.FailuresOnCurrentCity = 0;
			}

			using (var db = new AlienInvasionDatabase())
			{
				db.SaveAlienInvasionUser(user);
			}

			return user.CurrentCity;
		}
	}
}
