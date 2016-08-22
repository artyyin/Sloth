using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace P1.Model
{
    public class MiniBaseEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MiniBaseEntity()
        {
            Id = Guid.Empty;
        }
        /// <summary>
        /// ID自动增长序列号
        /// </summary>          
        [Key]
        public Guid Id { get; set; }
    }

    public class BaseEntity : MiniBaseEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseEntity()
        {
            CreateDate = DateTime.Now;
            ModifyDate = DateTime.Now;
        }
        /// <summary>
        /// 排序码
        /// </summary>
        public int SortCode { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>        
        public int DeleteMark { get; set; }
        /// <summary>
        /// 使能标志
        /// </summary>
        public int Enable { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>        
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>        
        public Guid? CreateUserId { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>        
        [StringLength(30)]
        public string CreateUserName { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 修改人ID
        /// </summary>        
        public Guid? ModifyUserId { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [StringLength(30)]
        public string ModifyUserName { get; set; }
    }
    public interface IDeleteMark
    {
        /// <summary>
        /// 删除标志
        /// </summary>        
        int DeleteMark { get; set; }
    }
    public interface IUserSort
    {
        /// <summary>
        /// 排序码
        /// </summary>
        int SortCode { get; set; }
    }
    public interface ICreaterRecord
    {
        /// <summary>
        /// 创建日期
        /// </summary>        
        DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>        
        Guid? CreateUserId { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>        
        [StringLength(30)]
        string CreateUserName { get; set; }
    }
    public interface IModifyRecord
    {
        /// <summary>
        /// 修改日期
        /// </summary>
        DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 修改人ID
        /// </summary>        
        Guid? ModifyUserId { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [StringLength(30)]
        string ModifyUserName { get; set; }
    }    
    public interface IDeleteRecord
    {
        /// <summary>
        /// 删除日期
        /// </summary>
        DateTime? DeleteDate { get; set; }
        /// <summary>
        /// 删除人ID
        /// </summary>        
        Guid? DeleteUserId { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        [StringLength(30)]
        string DeleteUserName { get; set; }
    }
}
