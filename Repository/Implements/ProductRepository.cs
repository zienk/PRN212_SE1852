using BO;
using DAL;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implements
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO _productDAO = new ProductDAO();

        public List<Product> GetProducts()
        {
            return _productDAO.GetProducts();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDAO.GetProductsByCategory(categoryId);
        }
    }
}
