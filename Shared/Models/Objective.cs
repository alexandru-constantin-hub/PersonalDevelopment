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

        public DateTime? TimeLimit { get; set; }

        public int CompletedProcentage { get; set; } = 0;

        public bool Specific { get; set; } = false;

        public bool Measurable { get; set; } = false;

        public bool Achievable { get; set; } = false;

        public bool Relevant { get; set; } = false;

        public bool Time { get; set; } = false;

        public string? ImageLink { get; set; }

        public string? UserId { get; set; }

    }
}
