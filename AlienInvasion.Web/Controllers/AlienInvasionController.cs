using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AlienInvasion.Server;

namespace AlienInvasion.Web.Controllers
{
    public class AlienInvasionController : Controller
    {
        public ActionResult Index()
        {
			IList<AlienInvasionUser> users;

			using (var db = new AlienInvasionDatabase())
				users = db.GetAlienInvasionUsers().OrderByDescending(x => x.Score).ToList();

            return View(users);
        }

		[HttpPost]
		public ActionResult SignOnToDefendEarth(string userName)
		{
			var encryption = new SymmetricEncryption("blahblah");
			var decryptedUserName = encryption.Decrypt(userName);

			var server = new AlienInvasionServer();
			var cityId = server.GetCurrentCity(decryptedUserName);

			return File(BitConverter.GetBytes(cityId), "application/x-alien-invasion-city");
		}

		[HttpPost]
		public ActionResult ReportInvasionResultAndGetNextCity(string userName, bool failedToDefend)
		{
			var encryption = new SymmetricEncryption("blahblah" + failedToDefend);
			var decryptedUserName = encryption.Decrypt(userName);

			var server = new AlienInvasionServer();
			var cityId = server.ReportInvasionResultAndGetNextCity(decryptedUserName, failedToDefend);

			return File(BitConverter.GetBytes(cityId), "application/x-alien-invasion-city");
		}
	}
}
