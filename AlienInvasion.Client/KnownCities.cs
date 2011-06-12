using System;
using System.Linq;
using System.Reflection;

namespace AlienInvasion.Client
{
	internal static class KnownCities
	{
		private static ICity[] _cities;

		public static void ResetCities()
		{
			_cities = null;
		}

		public static ICity[] All
		{
			get
			{
				if (_cities == null)
				{
					_cities = Assembly
						.GetCallingAssembly()
						.GetTypes()
						.Where(t => t.GetInterfaces().Contains(typeof(ICity)) && t.IsInterface == false)
						.Select(t => t.GetConstructor(new Type[0]).Invoke(new object[0]))
						.Cast<ICity>()
						.OrderBy(c => c.Id).ToArray();
				}

				return _cities;
			}
		}
	}
}