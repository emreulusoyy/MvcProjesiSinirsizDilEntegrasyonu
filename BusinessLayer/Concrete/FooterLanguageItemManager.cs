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
    public class FooterLanguageItemManager : IFooterLanguageItemService
    {
        private readonly IFooterLanguageItemDAL _footerLanguageItemDAL;

        public FooterLanguageItemManager(IFooterLanguageItemDAL footerLanguageItemDAL)
        {
            _footerLanguageItemDAL = footerLanguageItemDAL;
        }

        public void TDelete(FooterLanguageItem entity)
        {
            _footerLanguageItemDAL.Delete(entity);
        }

        public FooterLanguageItem TGetByID(int id)
        {
            return _footerLanguageItemDAL.GetByID(id);
        }

        public List<FooterLanguageItem> TGetList()
        {
            return _footerLanguageItemDAL.GetList();
        }

        public List<FooterLanguageItem> TGetList(Expression<Func<FooterLanguageItem, bool>> filter)
        {
            return _footerLanguageItemDAL.GetList(filter);
        }

        public void TInsert(FooterLanguageItem entity)
        {
            _footerLanguageItemDAL.Insert(entity);
        }

        public void TUpdate(FooterLanguageItem entity)
        {
            _footerLanguageItemDAL.Update(entity);
        }
    }
}
