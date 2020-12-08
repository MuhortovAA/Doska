using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doska.Models.ViewModels;

namespace Doska.Models
{
    public class AppIdentityDbContext:IdentityDbContext<IdentityUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options):base(options)
        {

        }
        public DbSet<Doska.Models.ViewModels.ViewModel> ViewModel { get; set; }
        public DbSet<Doska.Models.ViewModels.EditModel> EditModel { get; set; }
    }
}
