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
    public class CategoryLanguageItemManager : ICategoryLanguageItemService
    {
        private readonly ICategoryLanguageItemDAL _categoryLanguageItemDAL;

        public CategoryLanguageItemManager(ICategoryLanguageItemDAL categoryLanguageItemDAL)
        {
            _categoryLanguageItemDAL = categoryLanguageItemDAL;
        }

        public void TDelete(CategoryLanguageItem entity)
        {
            _categoryLanguageItemDAL.Delete(entity);
        }

        public CategoryLanguageItem TGetByID(int id)
        {
            return _categoryLanguageItemDAL.GetByID(id);
        }

        public List<CategoryLanguageItem> TGetList()
        {
            return _categoryLanguageItemDAL.GetList();
        }

        public List<CategoryLanguageItem> TGetList(Expression<Func<CategoryLanguageItem, bool>> filter)
        {
            return _categoryLanguageItemDAL.GetList(filter);
        }

        public void TInsert(CategoryLanguageItem entity)
        {
            _categoryLanguageItemDAL.Insert(entity);
        }

        public void TUpdate(CategoryLanguageItem entity)
        {
            _categoryLanguageItemDAL.Update(entity);
        }
    }
}
