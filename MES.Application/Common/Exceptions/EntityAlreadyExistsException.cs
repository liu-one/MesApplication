using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Application.Common.Exceptions
{
    public  class EntityAlreadyExistsException:AppException
    {

        /// <summary>
        /// 实体名称
        /// </summary>
        public string EntityName { get; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// 属性值
        /// </summary>
        public object PropertyValue { get; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="entityName">实体名称</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="propertyValue">属性值</param>
        public EntityAlreadyExistsException(string entityName, string propertyName, object propertyValue)
            : base($"实体 {entityName} 中 {propertyName}={propertyValue} 已存在", "ENTITY_ALREADY_EXISTS")
        {
            EntityName = entityName;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }

        
    }
}
