using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductDAO
    {

        MyStoreContext _context = new MyStoreContext();

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

    }
}
