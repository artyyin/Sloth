using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sloth.Core.DAL
{
    public class RepositoryBase<T> : IRepository<T>, IUnitOfWorkRepository where T : EntityBase, new()
    {
        private string ConnectionString;
        public RepositoryBase()
        {

            ConnectionString = Device.Common.ConifgHelper.ReadConnectionString;
        }
        public void PersistCreationOf(IEntity entity, object content)
        {
            SqlSugarClient DB = content as SqlSugarClient;
            DB.Insert<T>(entity as T);
        }

        public void PersistUpdateOf(IEntity entity, object content)
        {
            SqlSugarClient DB = content as SqlSugarClient;
            DB.Update<T>(entity as T);
        }

        public void PersistDeletionOf(IEntity entity, object content)
        {
            SqlSugarClient DB = content as SqlSugarClient;
            DB.ExecuteCommand("delete from " + entity.GetType().Name + " where " + entity.GetIDName() + " = @id", entity.GetID());
        }
        public T Get(Guid tid)
        {
            using (SqlSugarClient db = new SqlSugarClient(ConnectionString))
            {
                Queryable<T> query = new Queryable<T>();
                query.DB = db;
                T t = new T();
                return query.Where((t as IEntity).GetIDName() + "=@id", new { id = tid }).First<T>();
            }
        }
        public List<T> GetAll()
        {
            using (SqlSugarClient db = new SqlSugarClient(ConnectionString))
            {
                Queryable<T> query = new Queryable<T>();
                query.DB = db;
                return query.ToList<T>();
            }
        }
    }    
}
