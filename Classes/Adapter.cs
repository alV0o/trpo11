using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace trpo11.Classes
{
    public interface IProductSource
    {
        public List<Product> GetProducts(string filename);
    }
    public class CsvLoaderAdapter : IProductSource
    {
        CsvLoader csvLoader = new();
        public List<Product> GetProducts(string filename)
        {
            return csvLoader.GetProducts();
        }
    }

    public class JsonLoader : IProductSource
    {
        public List<Product> GetProducts(string filename)
        {
            string jsonString = File.ReadAllText(filename);
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(filename);

            return new List<Product>();
        }
    }

    public class CsvLoader
    {
        
        public List <Product> GetProducts()
        {
            return new List<Product>();
        }
    }
}
