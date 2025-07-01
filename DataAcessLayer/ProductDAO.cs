using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class ProductDAO
    {
        static List<Product> products = new List<Product>();

        public void InnitializeDataset()
        {
            products.Add(new Product() { Id = 1, Name = "Coca", Quantity = 10, Price = 100 });
            products.Add(new Product() { Id = 2, Name = "Pepsi", Quantity = 8, Price = 150 });
            products.Add(new Product() { Id = 3, Name = "CCLemon", Quantity = 20, Price = 70 });
            products.Add(new Product() { Id = 4, Name = "7UP", Quantity = 17, Price = 200 });
            products.Add(new Product() { Id = 5, Name = "Coffe", Quantity = 15, Price = 250 });
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public bool SaveProduct(Product product)
        {
            Product old = products.FirstOrDefault(x => x.Id == product.Id);
            if (old != null)
                return false; //Thêm mới thất bại vì trùng mã sp
            products.Add(product); //Thêm mới
            return true; // Thêm mới thành công
        }

        public bool UpdateProduct(Product p)
        {
            Product old = products.FirstOrDefault(x => x.Id == p.Id);
            if (old == null)
                return false;//sửa thất bại vì ko tìm thấy mã sản phẩm
            old.Name = p.Name;
            old.Quantity = p.Quantity;
            old.Price = p.Price;
            return true;
        }

        public bool DeleteProduct(int id)
        {
            Product old = products.FirstOrDefault(x => x.Id == id);
            if (old == null)
                return false; //xoa that bai vi ko tim thay ma sp
            products.Remove(old);
            return true;
        }
        

    }
}
