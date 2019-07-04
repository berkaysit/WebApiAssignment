using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAssignment.Models
{
    public class Transaction
    {
        public Transaction()
        {
            this.TransferAmount = 0;
            this.TransferDate = null;
        }
        public int TransferAmount { get; set; }
        public string TransferDate { get; set; }
    }
}
