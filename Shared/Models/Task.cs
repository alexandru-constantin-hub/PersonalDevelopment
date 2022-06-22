﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDevelopment.Shared.Models
{
    public class Tak
    {
            
            public int Id { get; set; }

            public string Name { get; set; }

            public string? Description { get; set; }

            public DateTime? StartDate { get; set; }
        
            public DateTime? TimeLimit { get; set; }

            [Range(0, 100)]
            public int? CompletedProcentage { get; set; }

            public string? Status { get; set; }
        
            public string? Category { get; set; }
        

            public string? UserId { get; set; }

    }
}
