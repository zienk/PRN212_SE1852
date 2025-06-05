using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinQToObject2
{
    public class ListProduct
    {
        List<Product> products;

        public ListProduct()
        {
            products = new List<Product>();
        }

        public void gen_sample_products()
        {
            products.Add(new Product() { Id = 1, Name = "P1", Quantity = 10, Price=11 });
            products.Add(new Product() { Id = 2, Name = "P2", Quantity = 20, Price = 22 });
            products.Add(new Product() { Id = 3, Name = "P3", Quantity = 30, Price = 33 });
            products.Add(new Product() { Id = 4, Name = "P4", Quantity = 40, Price = 44 });
            products.Add(new Product() { Id = 5, Name = "P5", Quantity = 50, Price = 55 });
            products.Add(new Product() { Id = 6, Name = "P6", Quantity = 60, Price = 66 });
            products.Add(new Product() { Id = 7, Name = "P7", Quantity = 70, Price = 77 });
            products.Add(new Product() { Id = 8, Name = "P8", Quantity = 80, Price = 88 });
            products.Add(new Product() { Id = 9, Name = "P9", Quantity = 90, Price = 99 });
            products.Add(new Product() { Id = 10, Name = "P10", Quantity = 100, Price = 100 });
        }

        public void PrintProducts()
        {
            products.ForEach(p => Console.WriteLine(p));
        }

        public void FilterProductByPrice(double price1, double price2)
        {
            var results = products.Where(p => p.Price >= price1 && p.Price <= price2);
            results.ToList().ForEach(p => Console.WriteLine(p));
        }

        public void FilterProductByPriceDesc(double price1, double price2)
        {
            var results = from p in products
                          where p.Price >= price1 && p.Price <= price2
                          orderby p.Price descending
                          select p;
            results.ToList().ForEach (p => Console.WriteLine(p));
        }

        public void FilterProductByQuantity(int q1, int q2)
        {
            var results = from p in products
                          where p.Quantity >= q1 && p.Quantity <= q2
                          //orderby p.Quantity descending
                          select new { p.Id, p.Name };
            foreach (var item in results)
            {
                Console.WriteLine(item.Id + "\t" + item.Name);
            }
        }

    }
}
