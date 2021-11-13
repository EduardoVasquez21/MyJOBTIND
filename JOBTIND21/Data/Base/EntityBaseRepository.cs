using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBase<T> where T : class, IBase, new()
    {
        private ApplicationDbContext bd;

        public EntityBaseRepository(ApplicationDbContext bd)
        {
            this.bd = bd;
        }


        public void Delete(int id, T ent)
        {
            EntityEntry entityEntry = bd.Entry<T>(ent);
            entityEntry.State = EntityState.Deleted;
            bd.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            var entidad = bd.Set<T>().ToList();
            return entidad;
        }

        public T GetById(int id)
        {
            var entidad = bd.Set<T>().FirstOrDefault(x => x.Id == id);
            return entidad;
        }

        public void Save(T ent)
        {
            bd.Set<T>().Add(ent);
            bd.SaveChanges();
        }

        public void Update(int id, T entity)
        {
            EntityEntry entityEntry = bd.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            bd.SaveChanges();
        }
    }
}
