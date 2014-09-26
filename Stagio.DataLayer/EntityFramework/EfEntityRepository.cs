using System.Data.Entity;
using System.Linq;
using Stagio.Domain.Entities;

namespace Stagio.DataLayer.EntityFramework
{
    public class EfEntityRepository<T>: IEntityRepository<T> where T : Entity
    {
        private readonly DbContext _context;

        public EfEntityRepository()
        {
            _context = new StagioDbContext();
        }
        
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
     
    }

}


