using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAssignment.Interfaces;
using WebApiAssignment.Models;
using WebApiAssignment.Services;

namespace WebApiAssignment.Controllers
{
    public class TransactionsController : ApiController
    {
        // Create Interfaces
        ICustomerService _cService = new CustomerService();
        ITransactionService _transService = new TransactionService();

        // POST: api/transactions
        // Payload example: {"AccountNo": 1, "TransferAmount": 4444}
    public HttpResponseMessage Post([FromBody] Transaction transaction)
        {
            // Get static customer list from service
            var customers = _cService.Customers().CList;
            // Find the account given
            var result = _transService.MakeTransfer(transaction.AccountNo, transaction.TransferAmount, customers);
            
            // If accountNo exist, return Status 201
            if (result == true)
            {
                var respMsg = Request.CreateResponse(HttpStatusCode.Created, customers);
                respMsg.Headers.Location = new Uri(Request.RequestUri.ToString());
                return respMsg;
            }
            else
            {
                //If accountNo does not exist, return Status 404 and a descriptive message
                return Request.CreateResponse(HttpStatusCode.NotFound, "AccounNo: " + transaction.AccountNo.ToString() + " not found!");
            }

        }
    }
}
