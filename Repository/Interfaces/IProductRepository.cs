using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public List<Product> GetProductsByCategory(int categoryId);
    }
}
