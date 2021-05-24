using Microsoft.AspNetCore.Http;
using sspAssignment3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sspAssignment3.ViewModels
{
    public class NCVM //Stands for Nurse Create View Model
    {
        //This viewmodel is used in order to allow the user to upload a picture when creating a Nurse
        //The reason we didn't use the Photo property in the original Nurse model is because we want to save space
        //IFormFile has several functions we do not need; we only need CopyTo(target)
        //Using an IFormFile object in a Nurse model will end up bloating every Nurse object we create with useless functions
        //Therefore, we use a viewmodel for things we do not want to save in the actual database
        
        //ID property isn't defined here because it is automatically added by the add method

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Please Enter a Valid Email Address")]
        public string Email { get; set; }
      
        [Required(ErrorMessage = "Please Select a Section")]
        public SectionEnum Section { get; set; }

        public IFormFile Photo { get; set; }
    }
}
