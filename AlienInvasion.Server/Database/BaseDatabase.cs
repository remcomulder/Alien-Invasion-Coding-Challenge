using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AlienInvasion.Server.Database
{
	public abstract class BaseDatabase: IDisposable
	{
		[ThreadStatic]
		protected static SqlConnection _connection;

		[ThreadStatic]
		private static int _connectionLevel;

		public BaseDatabase()
		{
			if (_connectionLevel == 0)
			{
				_connection = new SqlConnection(AppConfig.AlienInvasionDatabaseConnectionString);
				_connection.Open();
			}
			_connectionLevel++;
		}

		public void Dispose()
		{
			_connectionLevel--;

			if (_connectionLevel == 0)
			{
				_connection.Close();
			}
		}

		protected static object executeScalarSql(string sql, IEnumerable<Parameter> parameters = null)
		{
			using (SqlCommand cmd = new SqlCommand(sql, _connection))
			{
				cmd.CommandType = CommandType.Text;

				if (parameters != null)
					addParametersToCommand(parameters, cmd);

				return cmd.ExecuteScalar();
			}
		}

		protected static void executeNonQuery(string sql, IEnumerable<Parameter> parameters)
		{
			using (SqlCommand cmd = new SqlCommand(sql, _connection))
			{
				addParametersToCommand(parameters, cmd);
				cmd.CommandType = CommandType.Text;
				cmd.ExecuteNonQuery();
			}
		}

		protected static IList<T> readObjectsFromQuery<T>(string queryText, Func<IDataReader, T> mappingFunction)
		{
			return readObjectsFromQuery(queryText, new Parameter[0], mappingFunction);
		}

		protected static IList<T> readObjectsFromQuery<T>(string queryText, IEnumerable<Parameter> parameters, Func<IDataReader, T> mappingFunction)
		{
			using (var cmd = new SqlCommand(queryText, _connection))
			{
				addParametersToCommand(parameters, cmd);
				cmd.CommandType = CommandType.Text;
				using (IDataReader reader = cmd.ExecuteReader())
				{
					return mapRecordsFromQueryOutput(reader, mappingFunction);
				}
			}
		}

		private static IList<T> mapRecordsFromQueryOutput<T>(IDataReader reader, Func<IDataReader, T> mappingFunction)
		{
			var mapResult = new List<T>();

			while (reader.Read())
			{
				mapResult.Add(mappingFunction.Invoke(reader));
			}

			return mapResult;
		}

		private static void addParametersToCommand(IEnumerable<Parameter> parameters, SqlCommand cmd)
		{
			foreach (Parameter param in parameters)
			{
				if (param.Value is DateTime)
				{
					alignDateParameterWithDatabaseConstraints(param);
				}
				else if (param.Value == null)
				{
					param.Value = DBNull.Value;
				}
				cmd.Parameters.AddWithValue(param.Name, param.Value);
			}
		}

		private static readonly DateTime _minimumSqlDateTime = new DateTime(1753, 1, 1);
		private static readonly DateTime _maximumSqlDateTime = new DateTime(9999, 12, 31, 11, 59, 59);
		private static void alignDateParameterWithDatabaseConstraints(Parameter param)
		{
			var dateParam = (DateTime) param.Value;

			if (dateParam < _minimumSqlDateTime)
			{
				param.Value = _minimumSqlDateTime;
			}
			else if (dateParam > _maximumSqlDateTime)
			{
				param.Value = _maximumSqlDateTime;
			}
		}

		protected class Parameter
		{
			public Parameter()
			{

			}

			public Parameter(string name, object value)
			{
				Name = name;
				Value = value;
			}

			public string Name
			{
				get;
				set;
			}

			public object Value
			{
				get;
				set;
			}
		}
	}
}
