  //引进TT模板的命名空间




using P1.IDAL;
using P1.Model;

namespace P1.IDAL
{
 
        public partial interface IActionInfoRepository : IBaseRepository<ActionInfo>
        {
        }
        public partial interface IRoleRepository : IBaseRepository<Role>
        {
        }
        public partial interface IUserInfoRepository : IBaseRepository<UserInfo>
        {
        }

}