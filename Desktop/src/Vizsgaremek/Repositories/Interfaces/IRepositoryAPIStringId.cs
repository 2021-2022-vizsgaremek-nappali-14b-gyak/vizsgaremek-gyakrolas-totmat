using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek.Repositories.Interfaces
{
    interface IRepositoryAPIStringId<T>
    {

        public List<T> GetAll();
        public T Get(int id);
        public void Insert(T entity);
        public void Update(int id, T entity);
        public void Delete(int id);
    }
}
