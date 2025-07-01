using BusinessObject;
using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO productsDAO = new ProductDAO();

        public List<Product> GetProducts()
        {
            return productsDAO.GetProducts();
        }

        public void InnitializeDataset()
        {
            productsDAO.InnitializeDataset();
        }

        public bool SaveProduct(Product product)
        {
            return productsDAO.SaveProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return productsDAO.DeleteProduct(id);
        }

        public bool UpdateProduct(Product p)
        {
            return productsDAO.UpdateProduct(p);
        }
    }
}
