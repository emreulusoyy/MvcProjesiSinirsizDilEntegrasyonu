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
    public class SubProductManager : ISubProductService
    {
        private readonly ISubProductDAL _subProductDAL;

        public SubProductManager(ISubProductDAL subProductDAL)
        {
            _subProductDAL = subProductDAL;
        }

        public void TDelete(SubProduct entity)
        {
            _subProductDAL.Delete(entity);
        }

        public SubProduct TGetByID(int id)
        {
            return _subProductDAL.GetByID(id);
        }

        public List<SubProduct> TGetList()
        {
            return _subProductDAL.GetList();
        }

        public List<SubProduct> TGetList(Expression<Func<SubProduct, bool>> filter)
        {
            return _subProductDAL.GetList(filter);
        }

        public void TInsert(SubProduct entity)
        {
            _subProductDAL.Insert(entity);
        }

        public void TUpdate(SubProduct entity)
        {
            _subProductDAL.Update(entity);
        }
    }
}
