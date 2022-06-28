using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDevelopment.Shared.Models
{
    public class ValueObjective
    {
        public int ID { get; set; }


        public int? ValueID { get; set; }

        public virtual Value? Value { get; set; }

        public int? ObjectiveID { get; set; }

        public virtual Objective? Objective { get; set; }

        public string? UserId { get; set; }

    }
}
