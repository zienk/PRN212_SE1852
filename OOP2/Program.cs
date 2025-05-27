using OOP2;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

FulltimeEmployee teo = new FulltimeEmployee();
teo.Id = 1;
teo.Name = "Tèo";

Console.WriteLine(teo.CalculateSalary());

ParttimeEmployee ty = new ParttimeEmployee();
ty.WorkingHours = 2;
ty.Name = "Tý khốn khổ";
ty.Id = 2;

Console.WriteLine($"Lương của Tý = {ty.CalculateSalary}");

FulltimeEmployee obama = new FulltimeEmployee()
{
    Id = 100,
    Name = "Barac Obama",
    BirthDay = new DateTime(1960, 1, 25),
    IdCard = "123"
};
Console.WriteLine("====Thông tin của Obama====");
Console.WriteLine(obama);

ParttimeEmployee trump = new ParttimeEmployee()
{
    Id = 200,
    IdCard = "456",
    Name = "Donald Trump",
    BirthDay = new DateTime(1940, 12, 26),
    WorkingHours = 3
};
Console.WriteLine("====Thông tin của Trump====");
Console.WriteLine(trump);