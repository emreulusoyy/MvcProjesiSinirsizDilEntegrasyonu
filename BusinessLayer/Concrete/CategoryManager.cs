using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void TDelete(Category entity)
        {
            _categoryDAL.Delete(entity);
        }

        public Category TGetByID(int id)
        {
            return _categoryDAL.GetByID(id);
        }

        public List<Category> TGetList()
        {
            return _categoryDAL.GetList();
        }

        public List<Category> TGetList(Expression<Func<Category, bool>> filter)
        {
            return _categoryDAL.GetList(filter);
        }

        public void TInsert(Category entity)
        {
            _categoryDAL.Insert(entity);
        }

        public void TUpdate(Category entity)
        {
            _categoryDAL.Update(entity);
        }
    }
}
