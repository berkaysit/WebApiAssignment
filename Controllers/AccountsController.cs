﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAssignment.Interfaces;
using WebApiAssignment.Models;
using WebApiAssignment.Services;

namespace WebApiAssignment.Controllers
{
    public class AccountsController : ApiController
    {
        // Create Interfaces
        private readonly IAccountService _accountService;
        ICustomerService _cService = new CustomerService();

        static CustomerList customers;

        public AccountsController()
        {
            _accountService = new AccountService();
        }

        // POST: api/Accounts
        // Payload example: {"CustomerID": 1, "InitialCredit": 444}
        public HttpResponseMessage Post([FromBody] AccountCreationPayload accCreation)
        {
            try
            {
                // Get static customer list from service
                customers = _cService.Customers();

                // Create a new account for given customer
                var newAcc = _accountService.CreateNewAccount(accCreation.CustomerID, accCreation.InitialCredit, customers.CList);

                // If customer do not exist, do nothing and response error message
                if (newAcc == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "CustomerID: " + accCreation.CustomerID.ToString() + " not found!");
                }
                else
                {
                    // If customer exist return response with Status 201, 
                    var respMsg = Request.CreateResponse(HttpStatusCode.Created, customers);
                    respMsg.Headers.Location = new Uri(Request.RequestUri.ToString());
                    return respMsg;
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
