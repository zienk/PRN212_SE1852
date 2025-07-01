using DemoMyStoreLINQ2SQL;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;


string connectionString = "server=DESKTOP-OB3R068\\SQLEXPRESS;database=MyStore;uid=sa;pwd=12345";

MyStoreDataContext context = new MyStoreDataContext(connectionString);

//Câu 1 dùng LINQ2SQL để lấy toàn bộ ds Categories

var categories = context.Categories;
foreach (var c in categories)
{
    Console.WriteLine($"{c.CategoryID}\t{c.CategoryName}");
}
Console.WriteLine();

//Câu 2: Tìm chi tiết 1 danh mục khi biết CategoryId
int categoryId = 5;

Category category = context.Categories
                            .FirstOrDefault(c => c.CategoryID == categoryId);
if (category == null)
{
    Console.WriteLine($"Ko tim thay danh muc co ma = {categoryId}");
}
else
{
    Console.WriteLine($"Tim thay danh muc co ma = {categoryId}, chi tiet:");
    Console.WriteLine(category.CategoryID+"\t"+category.CategoryName);
}
Console.WriteLine();
//Câu 3: Thêm mới 1 danh mục 

//Category cnew = new Category();
//cnew.CategoryName = "Danh mục mới";
//context.Categories.InsertOnSubmit(cnew);
//context.SubmitChanges();

//Câu 4: Thêm mới nhiều danh mục cùng lúc

//List<Category> categories1 = new List<Category>();
//categories1.Add(new Category { CategoryName = "Laptop" });
//categories1.Add(new Category { CategoryName = "TV" });
//categories1.Add(new Category { CategoryName = "Phụ kiện" });
//context.Categories.InsertAllOnSubmit(categories1);
//context.SubmitChanges();

//Câu 5: Sửa tên danh mục
//Nguyên tắc: Phải tìm thấy mới sửa
Category catUpdate = (from x in context.Categories
                     where x.CategoryID == 10
                     select x).FirstOrDefault();

Category catUpdate2 = context.Categories
                            .FirstOrDefault(x => x.CategoryID == 10);

if (catUpdate2 != null)
{
    catUpdate2.CategoryName = "Ní hảo";
    context.SubmitChanges();
}

//Câu 6: Xoá danh mục
//Nguyên tắc: Phải tìm thấy mới xóa
Category catDelete = context.Categories
                            .FirstOrDefault(x => x.CategoryID == 12);
if (catDelete != null)
{
    context.Categories.DeleteOnSubmit(catDelete);
    context.SubmitChanges();
    
}

//Câu 7: Xóa tất cả danh mục mà không chứa bất kỳ sản phẩm nào
var categoriesWithoutProducts = from x in context.Categories
                                join CategoryId in Categories 
                                


