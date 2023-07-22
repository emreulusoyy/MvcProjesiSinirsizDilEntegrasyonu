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
    public class SubcriberManager : ISubcriberService
    {
        private readonly ISubcriberDAL _subcriberDAL;

        public SubcriberManager(ISubcriberDAL subcriberDAL)
        {
            _subcriberDAL = subcriberDAL;
        }

        public void TDelete(Subscriber entity)
        {
            _subcriberDAL.Delete(entity);
        }

        public Subscriber TGetByID(int id)
        {
            return _subcriberDAL.GetByID(id);
        }

        public List<Subscriber> TGetList()
        {
            return _subcriberDAL.GetList();
        }

        public List<Subscriber> TGetList(Expression<Func<Subscriber, bool>> filter)
        {
            return _subcriberDAL.GetList(filter);
        }

        public void TInsert(Subscriber entity)
        {
            _subcriberDAL.Insert(entity);
        }

        public void TUpdate(Subscriber entity)
        {
            _subcriberDAL.Update(entity);
        }
    }
}
