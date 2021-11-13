using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Data.Base
{
    public interface IEntityBase<T> where T : class, IBase, new()
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
        void Save(T ent);

        void Update(int id, T ent);
        void Delete(int id, T ent);
    }
}
