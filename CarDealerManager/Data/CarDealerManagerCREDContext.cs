using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarDealerManager.Models;

namespace CarDealerManager.Data
{
    public class CarDealerManagerCREDContext : DbContext
    {
        public CarDealerManagerCREDContext (DbContextOptions<CarDealerManagerCREDContext> options)
            : base(options)
        {
        }

        public DbSet<CarDealerManager.Models.Customer> Customer { get; set; }

        public DbSet<CarDealerManager.Models.Supplier> Supplier { get; set; }

        public DbSet<CarDealerManager.Models.Car> Car { get; set; }

        public DbSet<CarDealerManager.Models.Store> Store { get; set; }
    }
}
