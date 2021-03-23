using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_Project.Controllers
{
    public class MemberShipTypeController : Controller
    {
        // GET: MemberShipType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
		{

            return View("MembershipTypeForm");
		}

    }
}