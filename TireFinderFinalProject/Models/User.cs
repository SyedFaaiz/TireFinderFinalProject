using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TireFinderFinalProject.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

      
        public string PhoneNumber { get; set; }

    
    }
}
