using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sloth.Core.IDAL
{
    public interface IUnitOfWork
    {
        void RegisterAdd(IEntity entity);
        void RegisterUpdate(IEntity entity);
        void RegisterDelete(IEntity entity);
        void Commit();
    }
}
