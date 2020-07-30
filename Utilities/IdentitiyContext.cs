using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoffeeManagement.Utilities
{
    public class IdentitiyContext : IdentityDbContext<User, Role, Int32>
    {
        public IdentitiyContext(DbContextOptions<IdentitiyContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("cUser");
        }
    }
}
