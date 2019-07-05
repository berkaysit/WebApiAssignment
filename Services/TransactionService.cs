using System;
using System.Collections.Generic;
using WebApiAssignment.Models;
using WebApiAssignment.Interfaces;
using System.Linq;

namespace WebApiAssignment.Services
{
    public class TransactionService : ITransactionService
    {
        public Boolean MakeTransfer(int accountNo, int initialCredit, List<Customer> customers)
        {
            // Find the account
            var customer = customers.FirstOrDefault(c => c.AccountList.Any(acc => acc.AccountNo == accountNo));
            //var theAcc = customers.Find(x => x.CustomerID == customerID).AccountList.Find(a => a.AccountNo == accountNo);
            if (customer != null)
            {
                var theAccount = customer.AccountList.FirstOrDefault(a => a.AccountNo == accountNo);

                // Execute transfer process
                // Add initialCredit to account's existing amount.
                theAccount.AccountBalance += initialCredit;

                // Add transfer to account's transfers
                theAccount.TransactionList.Add(CreateTransferObject(initialCredit, accountNo));
                return true;
            }
            else { return false; }
        }

        static Transaction CreateTransferObject(int initialCredit, int accountNo)
        {
            var transaction = new Transaction();
            transaction.TransferAmount = initialCredit;
            transaction.TransferDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            // transaction.AccountNo is not mandatory since Account model already have AccountNo; I just want to picturize master-detail relation
            transaction.AccountNo = accountNo;
            return transaction;
        }
    }
}