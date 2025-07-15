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

        public bool SaveProduct(Product product)
        {
            if (product == null) return false;

            Product productExisting = _context.Products
                .FirstOrDefault(p => p.ProductId == product.ProductId);

            if (productExisting != null) return false;

            _context.Products.Add(product);
            return _context.SaveChanges() > 0; 
        }

        public bool UpdateProduct(Product product) {
            if (product == null) return false;

            Product productExisting = _context.Products
                .FirstOrDefault(p => p.ProductId == product.ProductId);

            if (productExisting == null) return false;

            productExisting.ProductName = product.ProductName;
            productExisting.UnitsInStock = product.UnitsInStock;
            productExisting.UnitPrice = product.UnitPrice;
            productExisting.CategoryId = product.CategoryId;

            return _context.SaveChanges() > 0; //SaveChanges trả về số bản ghi đã thay đổi
        }

        public bool DeleteProduct(int productId)
        {
            Product productExisting = _context.Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (productExisting == null) return false;

            _context.Products.Remove(productExisting);
            
            return _context.SaveChanges() > 0;
        }


    }
}