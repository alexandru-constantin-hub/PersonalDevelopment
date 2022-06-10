using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDevelopment.Shared.Models
{
    public class Objective
    {
       
        public int Id { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        public int? CompletedProcentage { get; set; }

        public string? UserId { get; set; }

    }
}
