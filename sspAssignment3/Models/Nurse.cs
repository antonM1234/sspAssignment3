using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sspAssignment3.Models
{
    public class Nurse
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Please Enter a Valid Email Address")]//Regular expression for email validation
        public string Email { get; set; }

        //This property is defined as enum since we assume we have a fixed number of sections
        [Required(ErrorMessage = "Please Select a Section")]
        public SectionEnum Section { get; set; }

        //This property is needed to allow for photo uploading functionality when creating a Nurse
        public string Photo { get; set; }

    }
}
