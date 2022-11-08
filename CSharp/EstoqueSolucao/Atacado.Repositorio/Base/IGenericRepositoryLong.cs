using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repositorio.Base
{
    public interface IGenericRepositoryLong<T> : IGenericRepository<T> where T : class
    {
        T GetById(long id);

        T Delete(long id);
    }
}
