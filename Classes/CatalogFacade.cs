using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trpo11.Classes
{
    public class ProductsData
    {
        public List<Product> Products { get; set; }
        public int Count { get; set; }
        public int AllSum { get; set; }
    }
    public class CatalogFacade
    {
        public ProductsData GetFullProducts(string type)
        {
            JsonLoader loader;
            if (type == "json") loader = new JsonLoader();
            else if (type == "csv") loader = new CsvLoaderAdapter();
            else throw new Exception("Неверный тип загрузчика");

            ProductsData productsData = new ProductsData();
            productsData.Products = loader.GetProducts();
            productsData.Count = productsData.Products.Count;

            foreach(var product in productsData.Products)
            {
                productsData.AllSum += product.Price;
            }

            return productsData;
        }
    }
}
