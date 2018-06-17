using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using Squader.DomainModel.Users;
using Squader.DomainModel.Announcements;
using System.Threading.Tasks;
using System.Threading;
using Squader.DomainModel.Teams;

namespace Squader.Infrastructure.DAL
{
    public class ApplicationDbContext : DbContext, IContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext() { }

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
        
        
        public  async Task<int> SaveChangesAsync()
        {
            return await this.SaveChangesAsync(CancellationToken.None);
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<UserTeam> UserTeams  { get; set; }



    }
}
