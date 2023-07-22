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
    public class FooterManager : IFooterService
    {
        private readonly IFooterDAL _footerDAL;

        public FooterManager(IFooterDAL footerDAL)
        {
            _footerDAL = footerDAL;
        }

        public void TDelete(Footer entity)
        {
            _footerDAL.Delete(entity);
        }

        public Footer TGetByID(int id)
        {
            return _footerDAL.GetByID(id);
        }

        public List<Footer> TGetList()
        {
            return _footerDAL.GetList();
        }

        public List<Footer> TGetList(Expression<Func<Footer, bool>> filter)
        {
            return _footerDAL.GetList(filter);
        }

        public void TInsert(Footer entity)
        {
            _footerDAL.Insert(entity);
        }

        public void TUpdate(Footer entity)
        {
            _footerDAL.Update(entity);
        }
    }
}
