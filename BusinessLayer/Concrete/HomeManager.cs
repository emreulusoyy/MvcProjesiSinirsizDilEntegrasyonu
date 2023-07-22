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
    public class HomeManager : IHomeService
    {
        IHomeDAL _homeDAL;

        public HomeManager(IHomeDAL homeDAL)
        {
            _homeDAL = homeDAL;
        }

        public void TDelete(Home entity)
        {
            _homeDAL.Delete(entity);
        }

        public Home TGetByID(int id)
        {
            return _homeDAL.GetByID(id);
        }

        public List<Home> TGetList()
        {
            return _homeDAL.GetList();
        }

        public List<Home> TGetList(Expression<Func<Home, bool>> filter)
        {
            return _homeDAL.GetList(filter);
        }

        public void TInsert(Home entity)
        {
            _homeDAL.Insert(entity);
        }

        public void TUpdate(Home entity)
        {
            _homeDAL.Update(entity);
        }
    }
}
