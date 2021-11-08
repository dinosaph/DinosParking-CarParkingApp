using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DinosParking.Models;

namespace DinosParking.Data
{
    public class DinosParkingContext : DbContext
    {
        public DinosParkingContext (DbContextOptions<DinosParkingContext> options)
            : base(options)
        {
        }

        public DbSet<DinosParking.Models.Ticket> Ticket { get; set; }

        public DbSet<DinosParking.Models.ParkingSpot> ParkingSpot { get; set; }
    }
}
