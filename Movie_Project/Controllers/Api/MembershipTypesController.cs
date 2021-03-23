using Movie_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movie_Project.Controllers.Api
{
    public class MembershipTypesController : ApiController
    {
        private static ApplicationDbContext _context;
		public MembershipTypesController()
		{
            _context = new ApplicationDbContext();
		}


        public IHttpActionResult GetMemberships()
		{
            var memberships = _context.MembershipTypes.ToList();
            return Ok(memberships);
		}

        public IHttpActionResult getMembership(int id)
		{
            var membership = _context.MembershipTypes.SingleOrDefault(x => x.Id == id);
            if (membership == null)
                return NotFound();

            return Ok(membership);
		}

        [HttpPost]

        public MembershipType CreateMemberShip(MembershipType membership)
		{
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.MembershipTypes.Add(membership);
            _context.SaveChanges();
            return membership;
		}

        [HttpDelete]
        public void DeleteMembership(int id)
		{
            var membership = _context.MembershipTypes.SingleOrDefault(x => x.Id == id);
            if (membership == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.MembershipTypes.Remove(membership);
            _context.SaveChanges();

		}

    }
}
