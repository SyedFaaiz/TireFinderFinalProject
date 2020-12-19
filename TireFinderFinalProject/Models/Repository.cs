using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TireFinderFinalProject.Models
{
    public class Repository
    {
        // need list of responses 
        private static List<User> _users;
        private static List<Tier> _tiers;


        // need to initialize the list - otherwise Null Pointer Exception
        // Constructor 

        static Repository()
        {
            _users = new List<User>();
            _tiers = initDataTiers();
        }

        public static void AddUser(User user)
        {
            _users.Add(user);
        }

        public static IEnumerable<User> Users => _users;

        private static List<Tier> initDataTiers()
        {
            return new List<Tier>
            {
                new Tier{DisplayName = "225/45/25",ItemNumber = 1, ImageURL = "",Model = "BMW",MakeImageURL = ""},
                new Tier{DisplayName = "240/45/16",ItemNumber = 2, ImageURL = "",Model = "AUDI",MakeImageURL = ""},
                new Tier{DisplayName = "235/45/16",ItemNumber = 3, ImageURL = "",Model = "VW",MakeImageURL = ""},
                new Tier{DisplayName = "245/45/17",ItemNumber = 4, ImageURL = "",Model = "Mercedes",MakeImageURL = ""},
                new Tier{DisplayName = "235/45/17",ItemNumber = 5, ImageURL = "",Model = "VW",MakeImageURL = ""},
                new Tier{DisplayName = "215/45/17",ItemNumber = 6, ImageURL = "",Model = "Honda",MakeImageURL = ""},
                new Tier{DisplayName = "245/45/16",ItemNumber = 7, ImageURL = "",Model = "Hyundai",MakeImageURL = ""},
                new Tier{DisplayName = "215/45/15",ItemNumber = 8, ImageURL = "",Model = "BMW",MakeImageURL = ""},
                new Tier{DisplayName = "255/45/16",ItemNumber = 9, ImageURL = "",Model = "BMW",MakeImageURL = ""},
                new Tier{DisplayName = "235/45/17",ItemNumber = 10, ImageURL = "",Model = "AUDI",MakeImageURL = ""},
                new Tier{DisplayName = "240/45/17",ItemNumber = 11, ImageURL = "",Model = "lamborghini",MakeImageURL = ""},
            };
        }
    }
}
/*
 *
 *  public int Id { get; set; }

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
 */
