using BusinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public void InnitializeDataset()
        {
            _productRepository.InnitializeDataset();
        }

        public bool SaveProduct(Product product)
        {
            return _productRepository.SaveProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }

        public bool UpdateProduct(Product p)
        {
            return _productRepository.UpdateProduct(p);
        }

    }
}
