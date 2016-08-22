  //引进TT模板的命名空间




using P1.Model;

namespace P1.IBLL
{
 
        public partial interface IActionInfoService : IBaseService<ActionInfo>
        {
        }
        public partial interface IRoleService : IBaseService<Role>
        {
        }
        public partial interface IUserInfoService : IBaseService<UserInfo>
        {
        }

}