using Doska.Services;
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
            JsonFileCatalogService contextJson = app.ApplicationServices.GetRequiredService<JsonFileCatalogService>();

            DataDoska data = new DataDoska(contextJson);

            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            //if (!context.Catalogs.Any())
            //{
            //    context.Catalogs.AddRange(data.GetCatalog_1()); ;
            //}
            if (!context.Subtitles.Any())
            {
                int count = 0;
                foreach (Catalog catalog in data.GetCatalogs())
                {
                    count++;
                    context.Titles.Add(new Title { NameTitle = catalog.Title });
                    context.SaveChanges();
                    foreach (SubtitleJson sub in catalog.Subtitles)
                    {
                        context.Subtitles.Add(new Subtitle { NameSubtitle = sub.NameSubtitle, idTitle = count });
                        context.SaveChanges();
                    }
                }
                //foreach (Subtitle item in data.GetSubtitles_1())
                //{
                //    context.Subtitles.Add(item);
                //    context.SaveChanges();
                //}
                //context.Subtitles.AddRange(data.GetSubtitles_1());
            }
            //if (!context.Titles.Any())
            //{
            //    foreach (Title item in data.GetTitles())
            //    {
            //        context.Titles.Add(item);
            //        context.SaveChanges();
            //    }
            //    //context.Titles.AddRange(data.GetTitle_1());
            //}
            //if (!context.Catalogs.Any() && !context.Subtitles.Any() && !context.Titles.Any())
            //{
            //    context.SaveChanges();
            //}
        }
    }
}
