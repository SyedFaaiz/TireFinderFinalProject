using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TireFinderFinalProject.Models
{
    public class Tier
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Item number")]
        public int ItemNumber { get; set; }

        [Required(ErrorMessage = "Please enter the Display Name")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Please enter Image Url")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Please enter Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter Item number")]
        public string MakeImageURL { get; set; }
    }
}
