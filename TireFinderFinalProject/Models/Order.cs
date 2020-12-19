using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TireFinderFinalProject.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the Quantity amount or number of orders")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please enter Price")]
        public double Price { get; set; }
    }
}
