using ProjeAPI.Core.RepositoryConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Repository
{
    public class CrossCuttingRepository<T> : EFBaseRepository<T>, ICrossCuttingRepository<T> where T : class
    {
        public CrossCuttingRepository(ProjeDbContext context) : base(context)
        {

        }
    }
}
