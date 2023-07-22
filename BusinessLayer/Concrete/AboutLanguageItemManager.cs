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
    public class AboutLanguageItemManager : IAboutLanguageItemService
    {
        IAboutLanguageItemDAL _aboutLanguageItemDAL;

        public AboutLanguageItemManager(IAboutLanguageItemDAL aboutLanguageItemDAL)
        {
            _aboutLanguageItemDAL = aboutLanguageItemDAL;
        }

        public void TDelete(AboutLanguageItem entity)
        {
            _aboutLanguageItemDAL.Delete(entity);
        }

        public AboutLanguageItem TGetByID(int id)
        {
            return _aboutLanguageItemDAL.GetByID(id);
        }

        public List<AboutLanguageItem> TGetList()
        {
            return _aboutLanguageItemDAL.GetList();
        }

        public List<AboutLanguageItem> TGetList(Expression<Func<AboutLanguageItem, bool>> filter)
        {
            return _aboutLanguageItemDAL.GetList(filter);
        }

        public void TInsert(AboutLanguageItem entity)
        {
            _aboutLanguageItemDAL.Insert(entity);
        }

        public void TUpdate(AboutLanguageItem entity)
        {
            _aboutLanguageItemDAL.Update(entity);
        }
    }
}
