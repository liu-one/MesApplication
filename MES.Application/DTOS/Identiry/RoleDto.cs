using MES.Domain.Entitys.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Application.DTOS.Identiry
{
    public class RoleDto
    {

        /// <summary>
        /// 角色ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string RoleCode { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 权限列表
        /// </summary>
        public List<Permission> permissions { get; set; }
    }
}
