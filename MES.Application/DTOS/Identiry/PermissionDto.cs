using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Application.DTOS.Identiry
{
    public class PermissionDto
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        public string PermCode { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermName { get; set; }

        /// <summary>
        /// 资源类型(菜单/按钮/API)
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// 资源路径
        /// </summary>
        public string ResourcePath { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
