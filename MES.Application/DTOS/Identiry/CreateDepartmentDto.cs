using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MES.Application.DTOS.Identiry
{
    public class CreateDepartmentDto
    {
        /// <summary>
        /// 部门编码
        /// </summary>
        [Required(ErrorMessage = "部门编码不能为空")]
        [StringLength(50, ErrorMessage = "部门编码长度不能超过50个字符")]
        public string DeptCode { get; set; }

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
    }
}
