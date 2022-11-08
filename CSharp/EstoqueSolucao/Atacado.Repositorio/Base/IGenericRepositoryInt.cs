using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repositorio.Base
{
    public interface IGenericRepositoryInt<T> : IGenericRepository<T> where T : class
    {
        T GetById(int id);

        T Delete(int id);
    }
}
