using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sloth.Core.IDAL
{
    public interface IUnitOfWorkRepository
    {
        void PersistCreationOf(IEntity entity, object content);
        void PersistUpdateOf(IEntity entity, object content);
        void PersistDeletionOf(IEntity entity, object content);
    }
}
