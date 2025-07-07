using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDAO
    {
        MyStoreContext _context = new MyStoreContext();

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

    }
}
