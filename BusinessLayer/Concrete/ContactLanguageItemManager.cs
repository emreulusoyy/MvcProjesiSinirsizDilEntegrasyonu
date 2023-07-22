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
    public class ContactLanguageItemManager : IContactLanguageItemService
    {
        IContactLanguageItemDAL _contactLanguageItemDAL;

        public ContactLanguageItemManager(IContactLanguageItemDAL contactLanguageItemDAL)
        {
            _contactLanguageItemDAL = contactLanguageItemDAL;
        }

        public void TDelete(ContactLanguageItem entity)
        {
            _contactLanguageItemDAL.Delete(entity);
        }

        public ContactLanguageItem TGetByID(int id)
        {
            return _contactLanguageItemDAL.GetByID(id);
        }

        public List<ContactLanguageItem> TGetList()
        {
            return _contactLanguageItemDAL.GetList();
        }

        public List<ContactLanguageItem> TGetList(Expression<Func<ContactLanguageItem, bool>> filter)
        {
            return _contactLanguageItemDAL.GetList(filter);
        }

        public void TInsert(ContactLanguageItem entity)
        {
            _contactLanguageItemDAL.Insert(entity);
        }

        public void TUpdate(ContactLanguageItem entity)
        {
            _contactLanguageItemDAL.Update(entity);
        }
    }
}
