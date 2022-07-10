using Microsoft.EntityFrameworkCore;
using Insoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insoft.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        
        public DbSet<Cita> Citas { get; set; }
    }
}
