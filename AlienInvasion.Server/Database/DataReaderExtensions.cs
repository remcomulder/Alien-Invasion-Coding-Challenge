using System;
using System.Data;

namespace AlienInvasion.Server.Database
{
	public static class DataReaderExtensions
	{
		public static int? ReadNullableInt(this IDataReader reader, string fieldName)
		{
			int ordinal = reader.GetOrdinal(fieldName);

			return reader.IsDBNull(ordinal) ? null : (int?) reader.GetInt32(ordinal);
		}

		public static int ReadInt(this IDataReader reader, string fieldName)
		{
			int ordinal = reader.GetOrdinal(fieldName);
			return reader.GetInt32(ordinal);
		}

		public static string ReadString(this IDataReader reader, string fieldName)
		{
			int ordinal = reader.GetOrdinal(fieldName);
			return reader.GetString(ordinal);
		}

		public static Guid ReadGuid(this IDataReader reader, string fieldName)
		{
			int ordinal = reader.GetOrdinal(fieldName);
			return new Guid(reader.GetString(ordinal));
		}

		public static string ReadNullableString(this IDataReader reader, string fieldName)
		{
			int ordinal = reader.GetOrdinal(fieldName);

			return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
		}

		public static DateTime ReadDateTime(this IDataReader reader, string fieldName)
		{
			int ordinal = reader.GetOrdinal(fieldName);
			return reader.GetDateTime(ordinal);
		}
	}
}
