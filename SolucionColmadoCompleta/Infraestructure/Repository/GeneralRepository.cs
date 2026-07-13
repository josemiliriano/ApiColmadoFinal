using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Infraestructure.Repository
{
    public class GeneralRepository<T> where T : class
    {
        private readonly MyDataContext _context;
        public GeneralRepository(MyDataContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public void Deleter(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public T SoftDelete(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public List<T> GetAllByCondition(Expression<Func<T, bool>> isDelete)
        {
            return _context.Set<T>().Where(isDelete).ToList();

        }
        public bool Exists(Expression<Func<T, bool>> name)
        {
            return _context.Set<T>().Any(name);
        }

    }
}
