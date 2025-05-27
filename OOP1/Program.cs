
using OOP1;
using System.Text;

Category c1 = new Category(); //New là được cấp phát 1 ô nhớ, biến c1 quản lý ô nhớ đó
c1.Id = 1;
c1.Name = "Nước mắm";
Console.OutputEncoding = Encoding.UTF8;
c1.PrintInfo();

Employee emp1 = new Employee();

//Để thay đổi giá trị của thuộc tính:
emp1.Id = 1;
emp1.Name = "Tèo";
emp1.Phone = "113";
emp1.Email = "teo@gmail.com";
//Để lấy giá trị của thuộc tính
//Tự gọi get cho property Id
Console.WriteLine($"Employee ID = {emp1.Id}");
//Tự gọi get cho property Name
Console.WriteLine($"Employee Name = {emp1.Name}");
//Hoặc chúng ta gọi hàm
emp1.PrintInfo();
Console.WriteLine("-------------------------------");
Console.WriteLine(emp1); // Tự gọi hàm ToString

//Vừa tạo đối tượng vừa khởi tạo giá trị cho thuộc tính:
Employee employee2 = new Employee(2, "Tý Đại Bàng", "ty@yahoo.com", "0123456789");
//Xuất thông tin của emp2
Console.WriteLine(employee2);
//Hoặc ta có thể coding như sau:
Employee emp3 = new Employee()
{
    Id = 1,
    Name = "Tủn",
    Email = "tun@gmail.com",
    Phone = "1234567890"
};
//Xuất thông tin của emp3
Console.WriteLine(emp3);