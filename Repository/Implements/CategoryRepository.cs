using BO;
using DAL;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implements
{
    public class CategoryRepository : ICategoryRepository
    {
        CategoryDAO _categoryDAO = new CategoryDAO();

        public List<Category> GetCategories()
        {
            return _categoryDAO.GetCategories();
        }
    }
}
