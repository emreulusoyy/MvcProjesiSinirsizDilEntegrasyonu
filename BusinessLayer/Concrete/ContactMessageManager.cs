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
    public class ContactMessageManager : IContactMessageService
    {
        private readonly IContactMessageDAL _contactMessageDAL;

        public ContactMessageManager(IContactMessageDAL contactMessageDAL)
        {
            _contactMessageDAL = contactMessageDAL;
        }

        public void TDelete(ContactMessage entity)
        {
            _contactMessageDAL.Delete(entity);
        }

        public ContactMessage TGetByID(int id)
        {
            return _contactMessageDAL.GetByID(id);
        }

        public List<ContactMessage> TGetList()
        {
            return _contactMessageDAL.GetList();
        }

        public List<ContactMessage> TGetList(Expression<Func<ContactMessage, bool>> filter)
        {
            return _contactMessageDAL.GetList(filter);
        }

        public void TInsert(ContactMessage entity)
        {
            _contactMessageDAL.Insert(entity);
        }

        public void TUpdate(ContactMessage entity)
        {
            _contactMessageDAL.Update(entity);
        }
    }
}
