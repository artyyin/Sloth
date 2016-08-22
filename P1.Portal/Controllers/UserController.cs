using P1.Common;
using P1.IBLL;
using P1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P1.Portal.Controllers
{
    public class UserController : Controller
    {
        private IUserInfoService _userService;
        public UserController()
        {
            this._userService = IOCHelper.Get<IUserInfoService>();
        }
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUserInfos()
        {
            //Json格式的要求{total:22,rows:{}}
            //实现对用户分页的查询，rows：一共多少条，page：请求的当前第几页
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int total = 0;
            //调用分页的方法，传递参数,拿到分页之后的数据
            var data = _userService.LoadPageEntities<Guid>(pageIndex, pageSize, out total, u => true, true, u => u.UserID);
            //构造成Json的格式传递
            var result = new { total = total, rows = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RegisterUser(UserInfo userInfo)
        {
            //首先保存一些需要录入数据库的信息
            //userInfo.Code = Guid.NewGuid().ToString();  //随机产生的一些数据
            //userInfo.QuickQuery = userInfo.UserName;   //获取数据的查询码
            //userInfo.UserFrom = "添加";               //用户来源
            //userInfo.Lang = "汉语";                   //默认系统识别的是汉语
            //userInfo.IsStaff = (Int32?)StaffEnum.OK;         //默认是职员
            //userInfo.IsVisible = (Int32?)VisibleEnum.OK;     //默认显示信息
            //userInfo.Enabled = (Int32?)EnabledEnum.OK;       //默认用户有效
            //userInfo.AuditStatus = "已审核";         //默认添加的用户已经经过审核
            //userInfo.DeletionStateCode = (Int32?)DeletionStateCodeEnum.Normal;    //默认没有伪删除
            //userInfo.CreateOn = DateTime.Parse(DateTime.Now.ToString());     //默认创建用户日期
            UserInfo user = Session["UserInfo"] as UserInfo;
            userInfo.CreateByID = user.UserID;   //获取添加此用户的管理者的ID
            userInfo.CreateByName = user.UserName;//获取添加此用户的管理者的名称
            userInfo.DeleteMark = 0;
            userInfo.ModifyTime = DateTime.Now;
            //执行添加用户的代码
            _userService.AddEntity(userInfo);
            return Content("OK");
        }
    }
}
