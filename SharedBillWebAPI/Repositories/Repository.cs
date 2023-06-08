using Microsoft.EntityFrameworkCore;
using VaquinhaWebAPI.Data;
using VaquinhaWebAPI.Repositories.Interfaces;

namespace VaquinhaWebAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly VaquinhaContext _vaquinhaContext;
        private readonly DbSet<T> _entities;
        public Repository(VaquinhaContext vaquinhaContext)
        {
            _vaquinhaContext = vaquinhaContext;
            _entities = _vaquinhaContext.Set<T>();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
            _vaquinhaContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
            _vaquinhaContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }

        public T GetById(int id)
        {

            var registro = _entities.Find(id);

            if (registro == null)
            {
                throw new NullReferenceException("registro não encontrado");
            }
            return registro;
        }

        public void Update(T entity)
        {
            // _entities.Attach(entity);
            // _vaquinhaContext.Entry(entity).State = EntityState.Modified;                
            _vaquinhaContext.Update(entity);
            _vaquinhaContext.SaveChanges();
        }

    }
}