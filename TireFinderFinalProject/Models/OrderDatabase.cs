using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TireFinderFinalProject.Models
{
    public class OrderDatabase : DbContext 
    {

        public DbSet<Order> Orders { get; set; }
        public DbSet<Order> Tires { get; set; }

        public OrderDatabase(DbContextOptions<OrderDatabase> options) : base(options)
        {
        }
    }
}
