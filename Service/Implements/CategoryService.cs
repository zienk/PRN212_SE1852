using BO;
using Repository.Implements;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements
{
    public class CategoryService : ICategoryService
    {

        ICategoryRepository _categoryRepo;

        public CategoryService()
        {
            _categoryRepo = new CategoryRepository();
        }

        public List<Category> GetCategories()
        {
            return _categoryRepo.GetCategories();
        }
    }
}
