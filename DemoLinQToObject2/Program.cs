using DemoLinQToObject2;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

ListProduct lp = new ListProduct();

//Giả lập dữ liệu:
lp.gen_sample_products();

Console.WriteLine("Ds Products:");
lp.PrintProducts();

Console.WriteLine("Ds products có giá từ 80 đến 100");
lp.FilterProductByPrice(80, 100);

Console.WriteLine("Ds products có giá từ 20 đến 70 và sắp xếp desc");
lp.FilterProductByPriceDesc(20, 70);

Console.WriteLine("Ds product có so luong tu a den b va chi hien ID va Name");
lp.FilterProductByQuantity(10, 50);