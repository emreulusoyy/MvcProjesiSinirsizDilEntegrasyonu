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
    public class HomeLanguageItemManager : IHomeLanguageItemService
    {
        IHomeLanguageItemDAL _homeLanguageItemDAL;

        public HomeLanguageItemManager(IHomeLanguageItemDAL homeLanguageItemDAL)
        {
            _homeLanguageItemDAL = homeLanguageItemDAL;
        }

        public void TDelete(HomeLanguageItem entity)
        {
            _homeLanguageItemDAL.Delete(entity);
        }

        public HomeLanguageItem TGetByID(int id)
        {
            return _homeLanguageItemDAL.GetByID(id);
        }

        public List<HomeLanguageItem> TGetList()
        {
            return _homeLanguageItemDAL.GetList();
        }

        public List<HomeLanguageItem> TGetList(Expression<Func<HomeLanguageItem, bool>> filter)
        {
            return _homeLanguageItemDAL.GetList(filter);
        }

        public void TInsert(HomeLanguageItem entity)
        {
            _homeLanguageItemDAL.Insert(entity);
        }

        public void TUpdate(HomeLanguageItem entity)
        {
            _homeLanguageItemDAL.Update(entity);
        }
    }
}
