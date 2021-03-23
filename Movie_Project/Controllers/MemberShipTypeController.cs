using Movie_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_Project.Controllers
{
    public class MemberShipTypeController : Controller
    {
        private static ApplicationDbContext _context;
		public MemberShipTypeController()
		{
            _context = new ApplicationDbContext();
		}
        // GET: MemberShipType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
		{

            return View("MembershipTypeForm");
		}

        [HttpPost]
        public ActionResult Save(MembershipType membershipType)
		{
            if (membershipType.Id == 0)
                _context.MembershipTypes.Add(membershipType);

			else
			{
                var membershipDb = _context.MembershipTypes.Single(c => c.Id == membershipType.Id);
                membershipDb.Name = membershipType.Name;
                membershipDb.DiscountRate = membershipType.DiscountRate;
                membershipDb.DurationInMonths = membershipType.DurationInMonths;
                membershipDb.SignUpFee = membershipType.SignUpFee;

              
			}
            _context.SaveChanges();
            return RedirectToAction("Index", "MemberShipType");
        }

    }
}