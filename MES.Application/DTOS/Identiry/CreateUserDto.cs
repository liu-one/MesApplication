using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MES.Application.DTOS.Identiry
{
    public class CreateUserDto
    {
        /// <summary>
        /// 工号
        /// </summary>
        [Required]
        [StringLength(50)]
        public string UserCode { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string PasswordHash { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [StringLength(50)]
        public string RealName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [StringLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// 角色ID列表
        /// </summary>
        public List<int> RoleIds { get; set; }
    }
}
