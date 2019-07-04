using System.Collections.Generic;

namespace WebApiAssignment.Models
{
    public class CustomerList
    {
        public List<Customer> CList { get; set; }

        public CustomerList()
        {

        }

        public CustomerList(List<Customer> list)
        {
            this.CList = list;
        }
    }
}
