using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Subtitle> Subtitles { get; set; }
        public DbSet<Title> Titles { get; set; }
    }
    //public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    //{

    //    public ApplicationDbContext CreateDbContext(string[] args) => Program.CreateHostBuilder(args).ConfigureServices.GetRequiredService<ApplicationDbContext>();
    //}
}
