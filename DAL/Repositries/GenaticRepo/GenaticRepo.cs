using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GenaticRepo<T> : IGenaticRepo<T> where T : class
    {
        private readonly SkyContext _skyContext;
        public GenaticRepo(SkyContext skyContext)
        {
            _skyContext = skyContext;
        }
        public List<T> GetAll()
        {
            return _skyContext.Set<T>().ToList();
        }
        public T? GetById(int id)
        {
            return _skyContext.Set<T>().Find(id);
        }
        public void Add(T t)
        {
            _skyContext.Set<T>().Add(t);
        }
        public void Update(T t)
        {
            _skyContext.Set<T>().Update(t);
        }

        public void Delete(T t)
        {
            _skyContext.Set<T>().Remove(t);
        }
        public void SaveChanges()
        {
            _skyContext.SaveChanges();
        }


    }
}
