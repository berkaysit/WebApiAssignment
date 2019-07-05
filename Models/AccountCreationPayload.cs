using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAssignment.Models
{
    public class AccountCreationPayload
    {
        public int CustomerID { get; set; }
        public int InitialCredit { get; set; }
    }
}