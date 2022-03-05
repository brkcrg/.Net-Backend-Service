using System;
using System.Collections.Generic;

#nullable disable

namespace InsaatAPI.Models
{
    public partial class Sale
    {
        public int SalesId { get; set; }
        public DateTime? SalesDate { get; set; }
        public int? CustomerId { get; set; }
        public int? FlatId { get; set; }
        public decimal? Price { get; set; }
        public int? EmployeeId { get; set; }
        public string Notes { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Flat Flat { get; set; }
    }
}
