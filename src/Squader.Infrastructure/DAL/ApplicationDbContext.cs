using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using Squader.DomainModel.Users;
using Squader.DomainModel.Announcements;
using System.Threading.Tasks;

namespace Squader.Infrastructure.DAL
{
    public class ApplicationDbContext : DbContext, IContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=squader.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        
        /*
        public  async Task SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        */

        public DbSet<User> Users { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

    }
}
