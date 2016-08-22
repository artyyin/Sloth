using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P1.IDAL
{
    public interface IUnitOfWork
    {
        IDAL.IRoleRepository RoleRepository { get; }
        IDAL.IUserInfoRepository UserRepository{get;}
        int SaveChanges();
    }
}
