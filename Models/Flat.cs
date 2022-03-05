using System;
using System.Collections.Generic;

#nullable disable

namespace InsaatAPI.Models
{
    public partial class Flat
    {
        public Flat()
        {
            Sales = new HashSet<Sale>();
        }

        public int FlatId { get; set; }
        public string FlatNo { get; set; }
        public int? ProjectId { get; set; }
        public int? FlatTypeId { get; set; }
        public int? FlatStatusId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual FlatStatus FlatStatus { get; set; }
        public virtual FlatType FlatType { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
