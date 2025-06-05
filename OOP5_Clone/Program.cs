

using OOP5_Clone;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Customer c1 = new Customer();
c1.Id = 1;
c1.Name = "Obama";

Customer c2 = c1;
//Lúc này c1 và c2 cùng trỏ tới 1 ô nhớ
//1 ô nhớ có từ 2 đối tượng trở lên trỏ vào ==>alias
//c1 đổi làm c2 đổi và ngược lại

Customer c3 = c1.copy();
//lúc này sao chép toàn bộ dữ liệu tại ô nhớ c1 đang quản lý
//sang 1 ô nhớ mới hoàn toàn và giao cho c3 quản lý
//lúc này c3 đổi ko liên quan c1 và ngược lại


Product p1 = new Product()
{
    Id = 1,
    Name = "Coca",
    Quantity = 10,
    Price = 100
};

Product p2 = new Product()
{
    Id = 2,
    Name = "Pepsi",
    Quantity = 5,
    Price = 80
};

p1 = p2;

p2.Name = "Sting";
p2.Price = 123;

//Thì p1 cũng bị đổi dữ liệu, vì p1 và p2 cùng quản lý ô nhớ
//Mà p2 đổi thì hiển nhiên p1 bị đổi
Console.WriteLine("Thông tin của p1:");
Console.WriteLine(p1);

Product p3 = new Product()
{
    Id = 3,
    Name = "P3",
    Quantity = 20,
    Price = 50
};

Product p4 = new Product()
{
    Id = 3,
    Name = "P4",
    Quantity = 20,
    Price = 50
};

Product p5 = new Product()
{
    Id = 5,
    Name = "P5",
    Quantity = 20,
    Price = 50
};

p5 = p3;
p3 = p4;

//Hỏi: ô nhớ cấp phát cho p3 có bị tự động thu hồi hay không? vì sao?

//Problem: Muốn sao chép dữ liệu của 1 ô nhớ
Product p6 = new Product()
{
    Id = 1,
    Name = "P6",
    Quantity = 6,
    Price = 16
};

Product p7 = p6.copy();
//Lúc này HĐH sẽ cấp phát 1 ô nhớ mới cho p7 quản lí
//Và ô nhớ này có giá trị i chang giá trị của ô nhớ mà p6 đang quản lí
//Tức là p6, p7 quản lí 2 ô nhớ khác nhau hoàn toàn
//p6 đổi ko liên can gì p7 và ngc lại
//==> ko phải alias
Console.WriteLine("---P6----");
Console.WriteLine(p6);
Console.WriteLine("---P7----");
Console.WriteLine(p7);
p7.Name = "Nihaoma";
Console.WriteLine("---P6 Lần 2----");
Console.WriteLine(p6);
Console.WriteLine("---P7 Lần 2----");
Console.WriteLine(p7);










