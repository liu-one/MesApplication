using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MES.Application.DTOS.Identiry
{
    public class CreatePremissionDto
    {
        /// <summary>
        /// 权限编码
        /// </summary>
        [Required(ErrorMessage = "权限编码不能为空")]
        [StringLength(50, ErrorMessage = "权限编码长度不能超过50个字符")]
        public string PermCode { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        [Required(ErrorMessage = "权限名称不能为空")]
        [StringLength(100, ErrorMessage = "权限名称长度不能超过100个字符")]
        public string PermName { get; set; }

        /// <summary>
        /// 资源类型(菜单/按钮/API)
        /// </summary>
        [Required(ErrorMessage = "资源类型不能为空")]
        [StringLength(50, ErrorMessage = "资源类型长度不能超过50个字符")]
        public string ResourceType { get; set; }

        /// <summary>
        /// 资源路径
        /// </summary>
        [StringLength(200, ErrorMessage = "资源路径长度不能超过200个字符")]
        public string ResourcePath { get; set; }
    }
}
