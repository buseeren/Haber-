using App.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public class Service<T> : IService<T> where T : class
    {

        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }



        public int Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _repository.Find(where);
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int Save(T entity)
        {
            return _repository.Save(entity);
        }

        public int Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
