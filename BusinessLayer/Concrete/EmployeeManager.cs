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
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDAL _employeeDAL;

        public EmployeeManager(IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        public void TDelete(Employee entity)
        {
            _employeeDAL.Delete(entity);
        }

        public Employee TGetByID(int id)
        {
             return _employeeDAL.GetByID(id);
        }

        public List<Employee> TGetList()
        {
            return _employeeDAL.GetList();
        }

        public List<Employee> TGetList(Expression<Func<Employee, bool>> filter)
        {
            return _employeeDAL.GetList(filter);
        }

        public void TInsert(Employee entity)
        {
            _employeeDAL.Insert(entity);
        }

        public void TUpdate(Employee entity)
        {
            _employeeDAL.Update(entity);
        }
    }
}
