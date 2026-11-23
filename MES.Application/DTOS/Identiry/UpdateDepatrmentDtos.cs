using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MES.Application.DTOS.Identiry
{
    public class UpdatePermission
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        [Required(ErrorMessage = "部门ID不能为空")]
        public int Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Required(ErrorMessage = "部门名称不能为空")]
        [StringLength(100, ErrorMessage = "部门名称长度不能超过100个字符")]
        public string DeptName { get; set; }

        /// <summary>
        /// 上级部门ID
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }
    }
}
