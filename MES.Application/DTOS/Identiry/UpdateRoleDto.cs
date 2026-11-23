using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MES.Application.DTOS.Identiry
{
    public  class UpdateRoleDto
    {
        [Required(ErrorMessage ="角色ID不能为空")]
        public int Id { get; set; }
        [Required(ErrorMessage ="角色名称不能为空")]
        [StringLength(100,ErrorMessage ="角色名称长度不能超过100")]
        public string RoleName {  get; set; }
        [StringLength(500,ErrorMessage ="角色描述长度不能超过500")]
        public string Description { get; set; }
        public bool IsActive {  get; set; }
        public List<int> PermissionIds { get; set; }
    }
}
