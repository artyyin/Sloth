using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Sloth.Core.Model
{
    public class MiniBaseEntity : IEntity
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
}
