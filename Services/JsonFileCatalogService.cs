using Doska.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;

namespace Doska.Services
{
    public class JsonFileCatalogService
    {
        public JsonFileCatalogService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "catalogs.json"); }
        }

        public IEnumerable<Catalog> GetCatalogs()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return System.Text.Json.JsonSerializer.Deserialize<Catalog[]>(jsonFileReader.ReadToEnd(), null
                    //new JsonSerializerOptions
                    //{
                    //    PropertyNameCaseInsensitive = true
                    //}
                    );
            }
        }
        //public void WriteCatalogs()
        //{
        //    using (FileStream fs = File.OpenWrite(JsonFileName))
        //    {
        //        string output = JsonConvert.SerializeObject(repository.Catalogs);
        //        byte[] bytes = Encoding.Default.GetBytes(output);
        //        fs.Write(bytes, 0, bytes.Length);
        //    }
        //}

        //public void AddRating(string productId, int rating)
        //{
        //    var products = GetProducts();

        //    if (products.First(x => x.Id == productId).Ratings == null)
        //    {
        //        products.First(x => x.Id == productId).Ratings = new int[] { rating };
        //    }
        //    else
        //    {
        //        var ratings = products.First(x => x.Id == productId).Ratings.ToList();
        //        ratings.Add(rating);
        //        products.First(x => x.Id == productId).Ratings = ratings.ToArray();
        //    }

        //    using (var outputStream = File.OpenWrite(JsonFileName))
        //    {
        //        JsonSerializer.Serialize<IEnumerable<Product>>(
        //            new Utf8JsonWriter(outputStream, new JsonWriterOptions
        //            {
        //                SkipValidation = true,
        //                Indented = true
        //            }),
        //            products
        //        );
        //    }
        //}
    }


}
