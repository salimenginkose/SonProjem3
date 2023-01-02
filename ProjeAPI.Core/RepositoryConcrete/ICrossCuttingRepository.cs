using ProjeAPI.Core.RepositoryConcrete.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.RepositoryConcrete
{
    public interface ICrossCuttingRepository<T> : IBaseRepository<T> where T : class
    {

    }
}
