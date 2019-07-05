using System.Collections.Generic;
using WebApiAssignment.Models;

namespace WebApiAssignment.Interfaces
{
    public interface IAccountService
    {
        Account CreateNewAccount(int customerID, int initialCredit, List<Customer> customers);
    }
}
