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
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _productDAL;

        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public void TDelete(Product entity)
        {
            _productDAL.Delete(entity);
        }

        public Product TGetByID(int id)
        {
            return _productDAL.GetByID(id);
        }

        public List<Product> TGetList()
        {
            return _productDAL.GetList();
        }

        public List<Product> TGetList(Expression<Func<Product, bool>> filter)
        {
            return _productDAL.GetList(filter);
        }

        public void TInsert(Product entity)
        {
            _productDAL.Insert(entity);
        }

        public void TUpdate(Product entity)
        {
            _productDAL.Update(entity);
        }
    }
}
