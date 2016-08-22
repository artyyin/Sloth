using P1.Common;
using P1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P1.IBLL
{
    public partial interface IActionInfoService
    {
        LoginResult CheckUserInfo(UserInfo userInfo);
    }
}
