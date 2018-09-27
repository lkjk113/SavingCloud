using System;
using System.Collections.Generic;
using System.Text;

namespace SavingCloud
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class EntityBase<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public abstract TPrimaryKey _EntityKey { get; set; }
    }
}
