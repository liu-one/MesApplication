using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Application.Common.Exceptions
{
    public  class EntityNotFoundExectpion:AppException
    {
        public EntityNotFoundExectpion(string entityName,object id):base($"实体{entityName}({id})不存在","ENTITY_NOT_FOUND")
        {
            EntityName=entityName;
            Id=id;

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="entityName">实体名称</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="propertyValue">属性值</param>
        public EntityNotFoundExectpion(string entityName, string propertyName, object propertyValue)
            : base($"实体 {entityName} 中 {propertyName}={propertyValue} 不存在", "ENTITY_NOT_FOUND")
        {
            EntityName = entityName;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }

        /// <summary>
        /// 实体名称
        /// </summary>
        public string EntityName { get; }

        /// <summary>
        /// 实体ID
        /// </summary>
        public object Id { get; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// 属性值
        /// </summary>
        public object PropertyValue { get; }
    }
}
