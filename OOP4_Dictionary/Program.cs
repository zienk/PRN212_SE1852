using OOP4_Dictionary;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Category laptop = new Category();
laptop.Id = 1;
laptop.Name = "Danh mục Laptop";

Product dell = new Product()
{
    Id = 1,
    Name = "Dell 1",
    Quantity = 10,
    Price = 15000000
};
laptop.AddProduct(dell);

Product dell2 = new Product()
{
    Id = 2,
    Name = "Dell 2",
    Quantity = 30,
    Price = 17000000
};
laptop.AddProduct(dell2);

Product hp1 = new Product()
{
    Id = 3,
    Name = "HP 1",
    Quantity = 5,
    Price = 12000000
};
laptop.AddProduct(hp1);

Product hp2 = new Product()
{
    Id = 4,
    Name = "HP 2",
    Quantity = 7,
    Price = 12000000
};
laptop.AddProduct(hp2);

Console.WriteLine("Ds sản phẩm của danh mục Laptop:");
laptop.PrintAllProducts();

Console.WriteLine("Mời bạn nhập mã sp muốn tìm:");
int pid = int.Parse(Console.ReadLine());
Product p = laptop.GetProduct(pid);
if (p == null)
{
    Console.WriteLine("Không tìm thấy sp có mã: " + pid);
}
else
{
    Console.WriteLine("Đã tìm thấy sp có mã: " + pid);
    Console.WriteLine(p);
}

Console.WriteLine("Ds chưa sắp xếp");
laptop.PrintAllProducts();
Dictionary<int, Product> sortedproducts = laptop.SortProduct();
Console.WriteLine("Ds sau khi sắp xếp");
foreach(KeyValuePair<int, Product> item in sortedproducts)
{
    Product x = item.Value;
    Console.WriteLine(x);
}

//Hãy sắp xếp tăng dần theo value nếu value = nhau, thì sắp xếp theo quantity giảm dần
Dictionary<int, Product> complexSorts = laptop.SortProduct();
Console.WriteLine("Ds sau khi sắp xếp");
foreach (KeyValuePair<int, Product> item in complexSorts)
{
    Product x = item.Value;
    Console.WriteLine(x);
}

Product px = new Product();
px.Id = 1;
px.Name = "MAC";
px.Quantity = 80;
px.Price = 500;

laptop.EditProduct(px);
Console.WriteLine("---Ds sản phẩm sau khi sửa---");
laptop.PrintAllProducts();

/*
 * Xóa tất cả sp bán ế trong quý 1 năm 2025
 * Ế: chỉ bán được 1 đơn hàng
 */

int pid_remove = 1;
laptop.RemoveProduct(pid_remove);
Console.WriteLine("---Ds sản phẩm sau khi xóa---");
laptop.PrintAllProducts();