using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Application.DTOS.Identiry
{
    public class DepartmentDto
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        public string DeptCode { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 上级部门ID
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 上级部门名称
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 子部门列表
        /// </summary>
        public List<DepartmentDto> Children { get; set; }

        /// <summary>
        /// 部门用户数量
        /// </summary>
        public int UserCount { get; set; }
    }
}
