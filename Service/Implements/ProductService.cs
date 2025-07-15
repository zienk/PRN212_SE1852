using BO;
using Repository.Implements;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepo;

        public ProductService()
        {
            _productRepo = new ProductRepository();
        }

        public bool DeleteProduct(int productId)
            => _productRepo.DeleteProduct(productId);

        public List<Product> GetProducts()
        {
            return _productRepo.GetProducts();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productRepo.GetProductsByCategory(categoryId);
        }

        public bool SaveProduct(Product product)
            => _productRepo.SaveProduct(product);

        public bool UpdateProduct(Product product)
            => _productRepo.UpdateProduct(product);
    }
}
