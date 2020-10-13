using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            DataDoska data = new DataDoska();

            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Catalogs.Any())
            {
                context.Catalogs.AddRange(data.GetCatalog_1()); ;
            }
            if (!context.Subtitles.Any())
            {
                context.Subtitles.AddRange(data.GetSubtitles_1());
            }
            if (!context.Titles.Any())
            {
                context.Titles.AddRange(data.GetTitle_1());
            }
            if (!context.Catalogs.Any() && !context.Subtitles.Any() && !context.Titles.Any())
            {
                context.SaveChanges();
            }
        }
    }
}
