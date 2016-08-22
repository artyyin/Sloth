using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Sloth.Core.Model
{
    public class BaseEntity : MiniBaseEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseEntity()
        {            
            CreateDate = DateTime.Now;
            ModifyDate = DateTime.Now;
            IsDeleted = false;
            IsDraft = false;
        }
        /// <summary>
        /// 排序码
        /// </summary>
        public int SortCode { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
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

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>        
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 是否草稿
        /// </summary>
        public bool IsDraft { get; set; }

        /// <summary>
        /// 单据所属组织
        /// </summary>
        public Guid? OrgId { get; set; }
    }
}
