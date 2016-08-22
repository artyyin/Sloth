using P1.Common;
using P1.IBLL;
using P1.IDAL;
using P1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P1.BLL
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        public RoleService()
        {
            
        }
        public override void SetCurrentRepository()
        {
            CurrentRepository = UnitOfWork.RoleRepository;
        }
    } 
}
