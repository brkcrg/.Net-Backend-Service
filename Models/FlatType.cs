using System;
using System.Collections.Generic;

#nullable disable

namespace InsaatAPI.Models
{
    public partial class FlatType
    {
        public FlatType()
        {
            CustomerRequests = new HashSet<CustomerRequest>();
            Flats = new HashSet<Flat>();
        }

        public int FlatTypeId { get; set; }
        public string FlatTypeName { get; set; }

        public virtual ICollection<CustomerRequest> CustomerRequests { get; set; }
        public virtual ICollection<Flat> Flats { get; set; }
    }
}
