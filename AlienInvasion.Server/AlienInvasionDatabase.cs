using System.Collections.Generic;
using AlienInvasion.Server.Database;

namespace AlienInvasion.Server
{
	public class AlienInvasionDatabase: BaseDatabase
	{
		public void SaveAlienInvasionUser(AlienInvasionUser user)
		{
			if (user.Id > 0)
			{
				updateAlienInvasionUser(user);
				return;
			}

			const string commandText = @"
				insert into alienInvasionUser (name, score, currentCity, failuresOnCurrentCity) values (@name, @score, @currentCity, @failuresOnCurrentCity)
				";

			executeNonQuery(commandText, new[]
			                                   	{
													new Parameter { Name = "@name", Value = user.Name },
													new Parameter { Name = "@score", Value = user.Score },
													new Parameter { Name = "@currentCity", Value = user.CurrentCity },
													new Parameter { Name = "@failuresOnCurrentCity", Value = user.FailuresOnCurrentCity },
			                                   	});
		}

		private void updateAlienInvasionUser(AlienInvasionUser user)
		{
			const string commandText = @"
				update alienInvasionUser set name = @name, score = @score, currentCity = @currentCity, failuresOnCurrentCity = @failuresOnCurrentCity where id = @id
				";

			executeNonQuery(commandText, new[]
			                                   	{
													new Parameter { Name = "@id", Value = user.Id },
													new Parameter { Name = "@name", Value = user.Name },
													new Parameter { Name = "@score", Value = user.Score },
													new Parameter { Name = "@currentCity", Value = user.CurrentCity },
													new Parameter { Name = "@failuresOnCurrentCity", Value = user.FailuresOnCurrentCity },
			                                   	});
		}

		public IList<AlienInvasionUser> GetAlienInvasionUsers()
		{
			const string commandText = @"
				select * from AlienInvasionUser
				";

			return readObjectsFromQuery(commandText, reader => new AlienInvasionUser
														{
															Id = reader.ReadInt("Id"),
															Name = reader.ReadString("Name"),
															Score = reader.ReadInt("Score"),
															CurrentCity = reader.ReadInt("CurrentCity"),
															FailuresOnCurrentCity = reader.ReadInt("FailuresOnCurrentCity")
														});
		}
	}
}
