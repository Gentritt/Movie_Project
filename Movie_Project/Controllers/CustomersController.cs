using Movie_Project.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Movie_Project.ViewModels;

namespace Movie_Project.Controllers
{
    
    public class CustomersController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(x=> x.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult New()
		{
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewmodel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
                

            };
            return View("CustomerForm",viewmodel);

		}
        
        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewmodel = new NewCustomerViewModel
				{
					Customer = customer,
					MembershipTypes = _context.MembershipTypes.ToList()
				};
				return View("CustomerForm", viewmodel);
			}
			if (customer.Id == 0)
                _context.Customers.Add(customer);

            else
            {
                var customerinDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerinDb.Name = customer.Name;
                customerinDb.IssubscribedToNewsletter = customer.IssubscribedToNewsletter;
                customerinDb.MembershipTypeId = customer.MembershipTypeId;
                customerinDb.Birthdate = customer.Birthdate;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Details(int id)
		{
            var customer = _context.Customers.Include(x=> x.MembershipType).SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View (customer);
		}

        public ActionResult Edit(int id)
		{
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewmodel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewmodel);
		}


    }
}