using System;
using System.Collections.Generic;

#nullable disable

namespace InsaatAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerRequests = new HashSet<CustomerRequest>();
            Sales = new HashSet<Sale>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Gsm { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Tc { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int? GenderId { get; set; }
        public int? CityID { get; set; }
        public string CustomerNo { get; set; }
        public int? IncomeTypeId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual City CustomerNavigation { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual IncomeType IncomeType { get; set; }
        public virtual ICollection<CustomerRequest> CustomerRequests { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
