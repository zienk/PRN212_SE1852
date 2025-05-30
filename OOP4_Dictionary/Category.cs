using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4_Dictionary
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Product> Products { get; set; }

        public Category()
        {
            Products = new Dictionary<int, Product>();
        }

        //CRUD
        //Thêm mới 1 sp cho Category:
        public void AddProduct(Product p)
        {   
            //Nếu chưa tồn tại thì mới add
            if (Products.ContainsKey(p.Id) == false)
            {
                Products.Add(p.Id, p);
            }
            
        }

        //Lấy ds sp
        public void PrintAllProducts()
        {
            foreach (KeyValuePair<int, Product> item in Products)
            {
                Product p = item.Value;
                Console.WriteLine(p); //Tự động gọi ToString()
            }
        }

        //Lấy chi tiết 1 đối tượng
        public Product GetProduct(int id)
        {
            if (Products.ContainsKey(id) == false)
                return null;
            return Products[id];
        }

        public Dictionary<int, Product> SortProduct()
        {
            return Products
                .OrderBy(item => item.Value.Price)
                .ToDictionary<int , Product>();
        }

        //Sắp xếp tăng dần theo value nếu value = nhau, thì sắp xếp theo quantity giảm dần
        public Dictionary<int, Product> ComplexProduct()
        {
            return Products
                .OrderByDescending(item => item.Value.Quantity)
                .OrderBy(item => item.Value.Price)
                .ToDictionary<int, Product>();
        }

        public void EditProduct(Product product)
        {
            if (Products.ContainsKey(product.Id) == false)
            {
                return;
            }
            //Sửa dữ liệu tại ô nhớ có chứa p.Id;
            Products[product.Id] = product;
        }

        public bool RemoveProduct(int id)
        {
            if (Products.ContainsKey(Id) == false)
            {
                return false;
            }
            return Products.Remove(Id);
        }

    }
}
