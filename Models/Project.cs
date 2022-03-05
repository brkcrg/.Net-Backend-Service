using System;
using System.Collections.Generic;

#nullable disable

namespace InsaatAPI.Models
{
    public partial class Project
    {
        public Project()
        {
            Flats = new HashSet<Flat>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int? CityID { get; set; }
        public int? ProjectStatusId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual City ProjectNavigation { get; set; }
        public virtual ProjectStatus ProjectStatus { get; set; }
        public virtual ICollection<Flat> Flats { get; set; }
    }
}
