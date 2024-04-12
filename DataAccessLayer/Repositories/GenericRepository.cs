using MyCVCore.DataAccessLayer.Abstract;
using MyCVCore.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCVCore.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        CvContext context = new CvContext();
        public void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();

        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
           return context.Set<T>().Where(filter).ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
           context.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}
