using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sloth.Core.IDAL
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        List<T> GetAll();
    }
}
