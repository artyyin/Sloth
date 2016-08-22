  //引进TT模板的命名空间




using P1.IDAL;
using P1.Model;

namespace P1.DAL
{
 
        public partial class ActionInfoRepository : BaseRepository<ActionInfo>, IActionInfoRepository
        {

        }
        public partial class RoleRepository : BaseRepository<Role>, IRoleRepository
        {

        }
        public partial class UserInfoRepository : BaseRepository<UserInfo>, IUserInfoRepository
        {

        }

}