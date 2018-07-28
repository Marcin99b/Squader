using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Squader.Common.Extensions;
using Squader.Common.Settings;

namespace Squader.Infrastructure.DAL
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var sqlSettings = configuration.GetSettings<SqlSettings>();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>(); 
                
            optionsBuilder.UseSqlite(sqlSettings.ConnectionString);

            return new ApplicationDbContext(optionsBuilder.Options, sqlSettings);
        }
    }
}
