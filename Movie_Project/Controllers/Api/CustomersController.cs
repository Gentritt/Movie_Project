﻿using AutoMapper;
using Movie_Project.DTO;
using Movie_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Movie_Project.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
		public CustomersController()
		{
            _context = new ApplicationDbContext();
		}
        //GET/api/customers
        public IHttpActionResult GetCustomers(string query = null)

		{
            var customersQuery = _context.Customers.Include(c => c.MembershipType);
            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
            return Ok(customerDtos);

		}
        //Get/api/customers/1
        public IHttpActionResult GetCustomer(int id)
		{
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));

		}

        //Post/api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
		{
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);


		}

        //Put/api/customers/1
        [HttpPut]
        public void UpdateCustomer (int id,CustomerDto customerDto)
		{
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto,customerInDb);
            //customerInDb.Name = customerDto.Name;
            //customerInDb.IssubscribedToNewsletter = customerDto.IssubscribedToNewsletter;
            //customerInDb.Birthdate = customerDto.Birthdate;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
            _context.SaveChanges();

		}

        //Delete/api/customers/1
        [HttpDelete]
        public void DeleteCustomer (int id)
		{
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
