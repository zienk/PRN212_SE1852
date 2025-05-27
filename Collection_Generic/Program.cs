using System.Numerics;
using System.Text;
using OOP2;

/*
 * Ứng dụng Generic để quản lí nv, thực hiện các thao tác CRUD
 * C - Create -> Thêm mới
 * R - Read (Retrieve) -> truy vấn: Xem, sắp xếp, lọc...
 * U - Update -> Chỉnh sửa dữ liệu
 * D - Delete -> Xóa dữ liệu
 */
//Câu 1: Tạo 5 nhân viên, 4 fulltime, 1 parttime

Console.OutputEncoding = Encoding.UTF8;

List<Employee> employees = new List<Employee>();

FulltimeEmployee fe1 = new FulltimeEmployee()
{
    Id = 1,
    Name = "Name 1",
    IdCard = "123",
    BirthDay = new DateTime(1980, 1, 1)
};
employees.Add(fe1);

FulltimeEmployee fe2 = new FulltimeEmployee()
{
    Id = 2,
    Name = "Name 2",
    IdCard = "456",
    BirthDay = new DateTime(1982, 2, 2)
};
employees.Add(fe2);

FulltimeEmployee fe3 = new FulltimeEmployee()
{
    Id = 3,
    Name = "Name 3",
    IdCard = "789",
    BirthDay = new DateTime(1983, 3, 3)
};
employees.Add(fe3);

FulltimeEmployee fe4 = new FulltimeEmployee()
{
    Id = 4,
    Name = "Name 4",
    IdCard = "444",
    BirthDay = new DateTime(1984, 4, 4)
};
employees.Add(fe4);

ParttimeEmployee pe1 = new ParttimeEmployee()
{
    Id = 5,
    Name = "Name 5",
    IdCard = "555",
    WorkingHours = 3,
    BirthDay = new DateTime(1995, 5, 5)
};
employees.Add(pe1);

//Câu 2: Xuất toàn bộ thông tin nhân sự (R)
Console.WriteLine("Thông tin toàn bộ nhân sự:");
//Cách 1: Dùng expression body (Lambda Expression)
employees.ForEach(e => Console.WriteLine(e));
//Cách 2: Dùng for thông thường
Console.WriteLine("---------------");
foreach (var e in employees)
{
    Console.WriteLine(e);
}
//Câu 3: Sắp xếp nv theo năm sinh tăng dần
//Cũng là R (Read/Retrieve)
for (int i = 0; i < employees.Count; i++)
{
    for (int j = i + 1; j < employees.Count; j++)
    {
        Employee ei = employees[i];
        Employee ej = employees[j];
        if (ei.BirthDay < ej.BirthDay)
        {
            employees[i] = ej;
            employees[j] = ei;
        }
    }
}
Console.WriteLine("----------Employees sau khi sắp xếp:");
employees.ForEach(e => Console.WriteLine(e));

//Câu 4: Sửa thông tin nhân viên (U - Update)
Console.WriteLine("------Nhập Id nhân viên cần sửa thông tin----");
int idToUpdate;
idToUpdate = int.Parse(Console.ReadLine());
Employee employee = employees.FirstOrDefault(e => e.Id == idToUpdate);
if (employee != null)
{
    Console.Write("Nhập tên mới: ");
    employee.Name = Console.ReadLine();
    Console.Write("Nhập id card mới: ");
    employee.IdCard = Console.ReadLine();
    Console.Write("Nhập ngày tháng năm sinh mới (dd/MM/yyyy): ");
    employee.BirthDay = DateTime.Parse(Console.ReadLine());
}
else
{
    Console.WriteLine("Không tìm thấy nhân viên với Id: " + idToUpdate);
}

//foreach (var e in employees)
//{
//    if (e.Id == idToUpdate)
//    {
//        Console.WriteLine("Nhap ten: ");
//        e.Name = Console.ReadLine();
//        Console.WriteLine("Nhap id card: ");
//        e.IdCard = Console.ReadLine();
//        Console.WriteLine("Nhap ngay thang nam sinh: ");
//        e.BirthDay = DateTime.Parse(Console.ReadLine());
//    }
//}

//In lại ds sau khi update
Console.WriteLine("Danh sách sau khi update");
employees.ForEach(e => Console.WriteLine(e));

//Câu 5: Xóa thông tin nhân viên (D - Delete)
Console.WriteLine("------Nhập Id nhân viên cần xóa thông tin----");
int idToDelete;
idToDelete = int.Parse(Console.ReadLine());
employee = employees.FirstOrDefault(e => e.Id == idToDelete);
if (employee != null)
{
    employees.Remove(employee);
    Console.WriteLine("Đã xóa nhân viên có Id: " + idToDelete);
}
else
{
    Console.WriteLine("Không tìm thấy nhân viên với Id: " + idToDelete);
}

//In lại ds sau khi delete
Console.WriteLine("Danh sách sau khi delete");
employees.ForEach(e => Console.WriteLine(e));