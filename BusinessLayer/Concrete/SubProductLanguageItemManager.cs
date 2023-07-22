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
    public class SubProductLanguageItemManager : ISubProductLanguageItemService
    {
        private readonly ISubProductLanguageItemDAL _subProductLanguageItemDAL;

        public SubProductLanguageItemManager(ISubProductLanguageItemDAL subProductLanguageItemDAL)
        {
            _subProductLanguageItemDAL = subProductLanguageItemDAL;
        }

        public void TDelete(SubProductLanguageItem entity)
        {
            _subProductLanguageItemDAL.Delete(entity);
        }

        public SubProductLanguageItem TGetByID(int id)
        {
            return _subProductLanguageItemDAL.GetByID(id);
        }

        public List<SubProductLanguageItem> TGetList()
        {
            return _subProductLanguageItemDAL.GetList();
        }

        public List<SubProductLanguageItem> TGetList(Expression<Func<SubProductLanguageItem, bool>> filter)
        {
            return _subProductLanguageItemDAL.GetList(filter);
        }

        public void TInsert(SubProductLanguageItem entity)
        {
            _subProductLanguageItemDAL.Insert(entity);
        }

        public void TUpdate(SubProductLanguageItem entity)
        {
            _subProductLanguageItemDAL.Update(entity);
        }
    }
}
