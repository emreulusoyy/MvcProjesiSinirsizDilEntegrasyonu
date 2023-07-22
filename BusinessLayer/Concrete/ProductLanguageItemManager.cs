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
    public class ProductLanguageItemManager : IProductLanguageItemService
    {
        private readonly IProductLanguageItemDAL _productLanguageItemDAL;

        public ProductLanguageItemManager(IProductLanguageItemDAL productLanguageItemDAL)
        {
            _productLanguageItemDAL = productLanguageItemDAL;
        }

        public void TDelete(ProductLanguageItem entity)
        {
            _productLanguageItemDAL.Delete(entity);
        }

        public ProductLanguageItem TGetByID(int id)
        {
            return _productLanguageItemDAL.GetByID(id);
        }

        public List<ProductLanguageItem> TGetList()
        {
            return _productLanguageItemDAL.GetList();
        }

        public List<ProductLanguageItem> TGetList(Expression<Func<ProductLanguageItem, bool>> filter)
        {
            return _productLanguageItemDAL.GetList(filter);
        }

        public void TInsert(ProductLanguageItem entity)
        {
            _productLanguageItemDAL.Insert(entity);
        }

        public void TUpdate(ProductLanguageItem entity)
        {
            _productLanguageItemDAL.Update(entity);
        }
    }
}
