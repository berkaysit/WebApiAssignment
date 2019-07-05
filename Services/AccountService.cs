using System;
using System.Collections.Generic;
using WebApiAssignment.Interfaces;
using WebApiAssignment.Models;
using System.Threading;


namespace WebApiAssignment.Services
{
    public class AccountService : IAccountService
    {
        private static int generatedAccountNumber = 0;

        // Create a new account for given customerID. Check if account will have an initial credit after creation.
        public Account CreateNewAccount(int customerID, int initialCredit, List<Customer> customers)
        {
            // Find given customer
            var customer = customers.Find(x => x.CustomerID == customerID);
            if (customer == null)
            {
                return null;
            }
            // Create a new account
            Account newAccount = new Account(0, new List<Transaction>());
            // Set the new account's initial values
            newAccount.AccountNo = GenerateNewAccountNumber();
            newAccount.AccountBalance = 0;
            // Add new account into given customer's accounts
            customer.AccountList.Add(newAccount);

            //customers.Add(customer);

            // Check if initialCredit is greater than 0
            if (initialCredit > 0)
            {
                // Perform transfer operations
                // Make the transaction
                TransactionService.MakeTransfer(customerID, newAccount.AccountNo, initialCredit, customers);
            }
            else
            {
                // Transfer not required
                Console.WriteLine("Para sıfır! Aktarmadım!");
            }
            return newAccount;
        }
        // Generate a sequence / get the next value to use as a unique account number
        static int GenerateNewAccountNumber()
        {
            return Interlocked.Increment(ref generatedAccountNumber);
        }
    }
}