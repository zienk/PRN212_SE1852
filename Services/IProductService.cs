using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public void InnitializeDataset();
        public bool SaveProduct(Product product);

        public bool UpdateProduct(Product p);
        public bool DeleteProduct(int id);
    }
}
