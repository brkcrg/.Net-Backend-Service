using System;
using System.Collections.Generic;

#nullable disable

namespace InsaatAPI.Models
{
    public partial class CustomerRequest
    {
        public int CustomerRequestId { get; set; }
        public int? CustomerId { get; set; }
        public int? FlatTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual FlatType FlatType { get; set; }
    }
}
