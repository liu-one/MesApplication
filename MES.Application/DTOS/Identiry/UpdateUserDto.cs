using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MES.Application.DTOS.Identiry
{
    public  class UpdateUserDto
    {
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 角色ID列表
        /// </summary>
        public List<int> RoleIds { get; set; }
    }
}
