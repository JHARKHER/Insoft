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
        public virtual DbSet<sp_s_Reg> sp_s_Reg { get; set; }
    }
}
