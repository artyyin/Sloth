using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sloth.Core.DAL
{
    public enum WorkItemType { Add, Update, Delete };
    public class WorkItem
    {
        public IEntity Entity;
        public IUnitOfWorkRepository Repository;
        public WorkItemType WorkType;
        public WorkItem() { }
        public WorkItem(IEntity entity, IUnitOfWorkRepository repository, WorkItemType worktype)
        {
            Entity = entity;
            WorkType = worktype;
            Repository = repository;
        }
    }

    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<Type, IUnitOfWorkRepository> RepoDictionary;

        private List<WorkItem> WorkList;

        public UnitOfWork()
        {
            WorkList = new List<WorkItem>();
            RepoDictionary = new Dictionary<Type, IUnitOfWorkRepository>();
        }
        private IUnitOfWorkRepository GetRepo(IEntity entity)
        {
            IUnitOfWorkRepository repo;
            if (!RepoDictionary.TryGetValue(entity.GetType(), out repo))
            {
                repo = RepositoryHelper.GetRepo(entity.GetType()) as IUnitOfWorkRepository;
                if (repo == null)
                    throw new Exception("创建Repository对象失败");
                RepoDictionary.Add(entity.GetType(), repo);
            }
            return repo;
        }
        public void RegisterAdd(IEntity o)
        {
            IUnitOfWorkRepository repo = GetRepo(o);
            WorkList.Add(new WorkItem(o, repo, WorkItemType.Add));
        }
        public void RegisterUpdate(IEntity o)
        {
            IUnitOfWorkRepository repo = GetRepo(o);
            WorkList.Add(new WorkItem(o, repo, WorkItemType.Update));
        }
        public void RegisterDelete(IEntity o)
        {
            IUnitOfWorkRepository repo = GetRepo(o);
            WorkList.Add(new WorkItem(o, repo, WorkItemType.Delete));
        }
        //public void Add(IEntity entity)
        //{
        //    IUnitOfWorkRepository repo = GetRepo(entity);
        //    repo.PersistCreationOf(entity, null);
        //}
        //public void Update(IEntity entity)
        //{
        //    IUnitOfWorkRepository repo = GetRepo(entity);
        //    repo.PersistUpdateOf(entity, null);
        //}
        //public void Delete(IEntity entity)
        //{
        //    IUnitOfWorkRepository repo = GetRepo(entity);
        //    repo.PersistDeletionOf(entity, null);
        //}

        public void Commit()
        {
            string connStr = Device.Common.ConifgHelper.WriteConnectionString;
            SqlSugar.SqlSugarClient db = null;
            try
            {
                db = new SqlSugar.SqlSugarClient(connStr);
                db.BeginTran();
                foreach (var item in WorkList)
                {
                    switch (item.WorkType)
                    {
                        case WorkItemType.Add:
                            item.Repository.PersistCreationOf(item.Entity, db);
                            break;
                        case WorkItemType.Update:
                            item.Repository.PersistUpdateOf(item.Entity, db);
                            break;
                        case WorkItemType.Delete:
                            item.Repository.PersistDeletionOf(item.Entity, db);
                            break;
                    }
                }
                db.CommitTran();
            }
            catch (Exception ee)
            {
                db.RollbackTran();
                throw ee;
            }
            finally
            {
                WorkList.Clear();
                db.Dispose();
            }
        }
    }
}
