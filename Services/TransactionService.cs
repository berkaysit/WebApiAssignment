using System;
using System.Collections.Generic;
using WebApiAssignment.Models;

namespace WebApiAssignment.Services
{
    public class TransactionService
    {
        public static void MakeTransfer(int customerID, int accountNo, int initialCredit, List<Customer> customers)
        {
            // Find the account
            var theAcc = customers.Find(x => x.CustomerID == customerID).AccountList.Find(a => a.AccountNo == accountNo);

            // Execute transfer process
            // Add initialCredit to account's existing balance.
            theAcc.AccountBalance += initialCredit;
            // Add transfer to account's transfers
            theAcc.TransactionList.Add(CreateTransferObject(initialCredit));
        }

        static Transaction CreateTransferObject(int initialCredit)
        {
            var transaction = new Transaction();
            transaction.TransferAmount = initialCredit;
            transaction.TransferDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            return transaction;
        }
    }
}