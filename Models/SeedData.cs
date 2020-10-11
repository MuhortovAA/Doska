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
                context.Catalogs.AddRange(
                    new Catalog
                    {
                        //id = 1,
                        idSubtitle = 1,
                        idTitle = 1
                    }
                );
            }
            if (!context.Subtitles.Any())
            { 
                context.Subtitles.AddRange(data.GetSubtitles());
            }
            if (!context.Titles.Any())
            {
                context.Titles.AddRange(data.GetTitles());
            }
            if (!context.Catalogs.Any() && !context.Subtitles.Any() && !context.Titles.Any())
            {
                context.SaveChanges();
            }
        }
    }
}
