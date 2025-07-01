using LucyDemoLINQ2SQL;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string connectionString = "server=DESKTOP-OB3R068\\SQLEXPRESS;database=Lucy_SalesData;uid=sa;pwd=12345";
Lucy_SalesDataDataContext context = new Lucy_SalesDataDataContext(connectionString);

//Câu 1: Xuất ds khách hàng có mua hàng
//Có mua hàng tức là -> có đơn hàng
var ds1 = from c in context.Customers
          where c.Orders.Count() > 0
          select c;

Console.WriteLine("Danh sách khách hàng có mua hàng:");
foreach (var c in ds1)
{
    Console.WriteLine($"{c.CustomerID}\t{c.CompanyName}");
}

//Câu 2: Lọc ra 3 khách hàng mua hàng nhiều nhất (chi nhiều tiền nhất) cho công ty
//Từ đó để ra chính sách nâng khách hàng VIP
var ds2 = (from c in context.Customers
           join o in context.Orders on c.CustomerID equals o.CustomerID
           join od in context.Order_Details on o.OrderID equals od.OrderID
           group new { od, c } by new { c.CustomerID} into g
           select new
           {
               CustomerID = g.Key.CustomerID,
               TotalSpent = g.Sum(x => x.od.UnitPrice * x.od.Quantity * (1 - (decimal)x.od.Discount))
           })
           .OrderByDescending(x => x.TotalSpent)
           .Take(3);
           
            //select new
           //{
           //    CustomerID = g.Key.CustomerID,
           //    CompanyName = g.Key.CompanyName,
           //    TotalSpent = g.Sum(x => x.od.UnitPrice * x.od.Quantity * (1 - (decimal)x.od.Discount))
           //})
           //.OrderByDescending(x => x.TotalSpent)
           //.Take(3);

Console.WriteLine("Top 3 khách hàng chi nhiều tiền nhất:");
foreach (var c in ds2)
{
    //Console.WriteLine($"{c.CustomerID}\t{c.CompanyName}\t{c.TotalSpent:C}");
    Console.WriteLine(c);
}


