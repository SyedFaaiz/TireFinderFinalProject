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



        // need to initialize the list - otherwise Null Pointer Exception
        // Constructor 

        static Repository()
        {
            _users = new List<User>();

        }

        public static void AddUser(User user)
        {
            _users.Add(user);
        }

        public static IEnumerable<User> Users => _users;

    }
}
