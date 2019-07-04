using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAssignment.Models
{
    public class Customer
    {
        public Customer(List<Account> AccountList)
        {
            this.AccountList = AccountList;
        }
        public Customer(int customerID, string customerName, string customerSurName, List<Account> accountList)
        {
            this.CustomerID = customerID;
            this.CustomerName = customerName;
            this.CustomerSurName = customerSurName;
            this.AccountList = accountList;
        }

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurName { get; set; }
        public List<Account> AccountList { get; set; }
    }
}
