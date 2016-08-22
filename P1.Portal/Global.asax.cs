using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;

namespace P1.Portal
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            StackExchange.Profiling.MiniProfilerEF.Initialize(); 
            


            //接口实现
            var builder =  new ContainerBuilder();
            builder.RegisterType<P1.BLL.UserInfoService>().As<IBLL.IUserInfoService>();
            builder.RegisterType<DAL.UserInfoRepository>().As<IDAL.IUserInfoRepository>();
            builder.RegisterType<BLL.RoleService>().As<IBLL.IRoleService>();
            builder.RegisterType<P1.DAL.RoleRepository>().As<P1.IDAL.IRoleRepository>();
            builder.RegisterType<P1.DAL.DbSession>().As<P1.IDAL.IUnitOfWork>();
            P1.Common.IOCHelper.Register(builder.Build());
        }
    }
}