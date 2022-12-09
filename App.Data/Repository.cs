using App.Core;
using App.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly NewsDBContext _context;
        private readonly DbSet<T> _dbset;

        public Repository(NewsDBContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        

        public int Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = _dbset.Find(id);
            _dbset.Remove(entity);
            return _context.SaveChanges();
        }

       

        public T Find(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault();
        }

        public List<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public int Save(T entity)
        {
            _dbset.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
