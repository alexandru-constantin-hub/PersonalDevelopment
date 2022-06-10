using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDevelopment.Shared.Models
{
    public class ValueObjectiveTak
    {
        [Key]
        public int Id { get; set; }
        
        public int? ValueID { get; set;}
        
        public virtual Value? Value { get; set; }

        public int? ObjectiveID { get; set; }

        public virtual Objective? Objective { get; set; }

        public int? TakID { get; set; }

        public virtual Tak? Tak { get; set; }

    }
}
