using P1.IDAL;
using P1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace P1.DAL
{
    //一次跟数据库交互的会话
    public class DbSession : IUnitOfWork  //代表应用程序跟数据库之间的一次会话，也是数据库访问层的统一入口
    {
        public IRoleRepository RoleRepository
        {
            get { return new RoleRepository(); }
        }
        public IUserInfoRepository UserRepository
        {
            get { return new UserInfoRepository(); }
        }
        //代表：当前应用程序跟数据库的绘画内所有的实体的变化，更新会数据库
        public int SaveChanges()
        {
            //调用EF上下文的SaveChanges方法
            return GetCurrentDbContext().SaveChanges();
        }
        private DbContext GetCurrentDbContext()
        {
            //CallContext：是线程内部唯一的独用的数据槽（一块内存空间）
            //传递DbContext进去获取实例的信息，在这里进行强制转换。
            DbContext dbContext = CallContext.GetData("DbContext") as DbContext;
            if (dbContext == null)  //线程在数据槽里面没有此上下文
            {
                dbContext = new DataModelContainer(); //如果不存在上下文的话，创建一个EF上下文
                //我们在创建一个，放到数据槽中去
                CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }
    }
}
