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
    public class LoginController : Controller
    {
        private IUserInfoService _userInfoService;
        public LoginController()
        {
            _userInfoService = IOCHelper.Get<IUserInfoService>();
        }
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        //判断用户输入的信息是否正确
        // [HttpPost]
        public ActionResult CheckUserInfo(string UserName, string Passwd, string Code)
        {
            //首先我们拿到系统的验证码
            string sessionCode = this.TempData["ValidateCode"] == null
                                     ? new Guid().ToString()
                                     : this.TempData["ValidateCode"].ToString();
            //然后我们就将验证码去掉，避免了暴力破解
            this.TempData["ValidateCode"] = new Guid();
            //判断用户输入的验证码是否正确
            if (sessionCode != Code)
            {
                return Content("验证码输入不正确");
            }
            //调用业务逻辑层（BLL）去校验用户是否正确,,,定义变量存取获取到的用户的错误信息
            string UserInfoError = "";
            UserInfo userInfo = new UserInfo { UserName = UserName, Password= Passwd, DeleteMark=0};
            var loginUserInfo = _userInfoService.CheckUserInfo(userInfo);
            switch (loginUserInfo)
            {
                case LoginResult.PwdError:
                    UserInfoError = "密码输入错误";
                    break;
                case LoginResult.UserNotExist:
                    UserInfoError = "用户名输入错误";
                    break;
                case LoginResult.UserIsNull:
                    UserInfoError = "用户名不能为空";
                    break;
                case LoginResult.PwdIsNUll:
                    UserInfoError = "密码不能为空";
                    break;
                case LoginResult.OK:
                    UserInfoError = "OK";
                    break;
                default:
                    UserInfoError = "未知错误，请您检查您的数据库";
                    break;
            }
            #region ----使用if else来判断信息----
            //if (loginUserInfo == LoginResult.UserIsNull)
            //{
            //    UserInfoError = "用户名不能为空";
            //}
            //else if (loginUserInfo == LoginResult.PwdIsNUll)
            //{
            //    UserInfoError = "密码不能为空";
            //}
            //else if (loginUserInfo == LoginResult.UserNotExist)
            //{
            //    UserInfoError = "用户名输入错误";
            //}
            //else if (loginUserInfo == LoginResult.PwdError)
            //{
            //    UserInfoError = "密码输入错误";
            //}
            //else if (loginUserInfo == LoginResult.OK)
            //{
            //    UserInfoError = "OK";
            //}
            //else
            //{
            //    UserInfoError = "未知错误，请您检查您的数据库";
            //}
            #endregion
            return Content(UserInfoError);
        }
        
        //
        // GET: /Login/CheckCode
        public FileContentResult CheckCode()
        {
            ValidateCode coder = new ValidateCode();
            string code = coder.CreateValidateCode(4);
            byte[] img = coder.CreateValidateGraphic(code);
            this.TempData["ValidateCode"] = code;

            return File(img, @"image/jpeg");
        }
    }
}
