using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MES.Application.DTOS.Identiry
{
    public class CreateRoleDto
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        [Required(ErrorMessage = "角色编码不能为空")]
        [StringLength(50, ErrorMessage = "角色编码长度不能超过50个字符")]
        public string RoleCode { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "角色名称不能为空")]
        [StringLength(100, ErrorMessage = "角色名称长度不能超过100个字符")]
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        [StringLength(500, ErrorMessage = "角色描述长度不能超过500个字符")]
        public string Description { get; set; }

        /// <summary>
        /// 权限ID列表
        /// </summary>
        public List<int> PermissionIds { get; set; }
    }
}
