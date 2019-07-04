using System.Collections.Generic;
using WebApiAssignment.Interfaces;
using WebApiAssignment.Models;

namespace WebApiAssignment.Services
{
    public class CustomerService : ICustomerService
    {
        // Keeps static list for both controller
        public static CustomerList customers = new CustomerList();

        // Set Default Customers into List (to set already existing customers)
        public CustomerList Customers()
        {
            if (customers.CList != null)
            {
                return customers;
            }
            else
            {
                customers.CList = new List<Customer>()
            {
                new Customer(customerID:1, customerName: "Lennon", customerSurName: "Alby ", accountList: new List<Account>()),
                new Customer(customerID:2, customerName: "Amelie ", customerSurName: "Rose", accountList: new List<Account>()),
                new Customer(customerID:3, customerName: "Eliza ", customerSurName: "Colton", accountList: new List<Account>())
            };

                return customers;
            }
        }
    }
}