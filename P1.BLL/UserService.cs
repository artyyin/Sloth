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
    public class UserInfoService : BaseService<UserInfo>, P1.IBLL.IUserInfoService
    {
        public UserInfoService()
        {
        }
        public override void SetCurrentRepository()
        {
            CurrentRepository = IOCHelper.Get<IUserInfoRepository>();
        }
        //完成了对用户的校验
        public LoginResult CheckUserInfo(UserInfo userInfo)
        {
            //首先判断用户名，密码是否为空
            if (string.IsNullOrEmpty(userInfo.UserName))
            {
                return LoginResult.UserIsNull;
            }
            if (string.IsNullOrEmpty(userInfo.Password))
            {
                return LoginResult.PwdIsNUll;
            }
            //如果不为空的话则去数据库中查询信息
            //在这里会去数据库检查是否有数据，如果没有的话就会返回一个空值
            var result = CurrentRepository.LoadEntities(u => u.UserName == userInfo.UserName);
            UserInfo LoginUserInfoCheck =result.FirstOrDefault();
            //对返回的结果进行判断
            if (LoginUserInfoCheck == null)
            {
                return LoginResult.UserNotExist;
            }
            if (LoginUserInfoCheck.Password != userInfo.Password)
            {
                return LoginResult.PwdError;
            }
            else
            {
                return LoginResult.OK;
            }
        }
    }
}
