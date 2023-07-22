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
    public class EmployeeLanguageItemManager : IEmployeeLanguageItemService
    {
        IEmployeeLanguageItemDAL _employeeLanguageItemDAL;

        public EmployeeLanguageItemManager(IEmployeeLanguageItemDAL employeeLanguageItemDAL)
        {
            _employeeLanguageItemDAL = employeeLanguageItemDAL;
        }

        public void TDelete(EmployeeLanguageItem entity)
        {
            _employeeLanguageItemDAL.Delete(entity);
        }

        public EmployeeLanguageItem TGetByID(int id)
        {
            return _employeeLanguageItemDAL.GetByID(id);
        }

        public List<EmployeeLanguageItem> TGetList()
        {
            return _employeeLanguageItemDAL.GetList();
        }

        public List<EmployeeLanguageItem> TGetList(Expression<Func<EmployeeLanguageItem, bool>> filter)
        {
            return _employeeLanguageItemDAL.GetList(filter);
        }

        public void TInsert(EmployeeLanguageItem entity)
        {
            _employeeLanguageItemDAL.Insert(entity);
        }

        public void TUpdate(EmployeeLanguageItem entity)
        {
            _employeeLanguageItemDAL.Update(entity);
        }
    }
}
