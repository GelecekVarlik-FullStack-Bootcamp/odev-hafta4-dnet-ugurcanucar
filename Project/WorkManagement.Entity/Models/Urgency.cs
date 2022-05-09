using System;
using System.Collections.Generic;

#nullable disable

namespace WorkManagement.Entity.Models
{
    public partial class Urgency
    {
        public Urgency()
        {
            Requests = new HashSet<Request>();
        }

        public int UrgencyId { get; set; }
        public string UrgencyName { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
