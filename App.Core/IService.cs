using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public interface IService<T> where T : class
    {
        int Save(T entity);
        int Update(T entity);
        List<T> GetAll();
        int Delete(T entity);
        int Delete(int id);
        T Find(Expression<Func<T, bool>> where);
        T GetById(int id);
    }
}
