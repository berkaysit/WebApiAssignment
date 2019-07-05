using System;
using System.Collections.Generic;
using WebApiAssignment.Models;

namespace WebApiAssignment.Interfaces
{
    interface ITransactionService
    {
        Boolean MakeTransfer(int accountNo, int initialCredit, List<Customer> customers);
    }
}
