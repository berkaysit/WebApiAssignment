﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAssignment.Interfaces;
using WebApiAssignment.Models;
using WebApiAssignment.Services;

namespace WebApiAssignment.Controllers
{
    public class CustomersController : ApiController
    {
        // SOLID: Liskov
        ICustomerService cService = new CustomerService();
        static CustomerList customers;

        // GET: api/Customers
        // List all customers
        [HttpGet]
        public List<Customer> GetCustomers()
        {
            customers = cService.Customers();
            return customers.CList;
        }

        // GET: api/Customers/3
        // List given customer details
        [HttpGet]
        public HttpResponseMessage GetCustomer(int id)
        {
            try
            {
                customers = cService.Customers();
                var customer = customers.CList.FirstOrDefault((c) => c.CustomerID == id);

                // If customer not exist, return Status 404 and a descriptive message
                if (customer == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "CustomerID: " + id.ToString() + " not found!");
                }
                else
                {
                    // If customer exits, return Status 200 and customer object
                    return Request.CreateResponse(HttpStatusCode.OK, customer);
                }
            }
            catch (Exception ex)
            {
                //throw;
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
