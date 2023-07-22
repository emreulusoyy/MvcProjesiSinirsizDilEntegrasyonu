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
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageDAL _languageDAL;

        public LanguageManager(ILanguageDAL languageDAL)
        {
            _languageDAL = languageDAL;
        }

        public void TDelete(Language entity)
        {
            _languageDAL.Delete(entity);
        }

        public Language TGetByID(int id)
        {
            return _languageDAL.GetByID(id);
        }

        public List<Language> TGetList()
        {
            return _languageDAL.GetList();
        }

        public List<Language> TGetList(Expression<Func<Language, bool>> filter)
        {
            return _languageDAL.GetList(filter);
        }

        public void TInsert(Language entity)
        {
            _languageDAL.Insert(entity);
        }

        public void TUpdate(Language entity)
        {
            _languageDAL.Update(entity);
        }
    }
}
