using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAssignment.Models
{
    public class Account
    {
        public Account(int accountBalance, List<Transaction> transactionList)
        {
            this.AccountBalance = accountBalance;
            this.TransactionList = transactionList;
        }
        public int AccountNo { get; set; }
        public int AccountBalance { get; set; }
        public List<Transaction> TransactionList { get; set; }
    }
}