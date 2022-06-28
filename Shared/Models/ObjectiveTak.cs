using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDevelopment.Shared.Models
{
    public class ObjectiveTak
    {

        public int ID { get; set; }

        public int? ObjectiveID { get; set; }

        public virtual Objective? Objective { get; set; }

        public int? TakID { get; set; }

        public virtual Tak? Tak { get; set; }

        public string? UserId { get; set; }
    }
}
