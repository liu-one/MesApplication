using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain.Entitys.Identity
{
    public  class Role:BaseEntity
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public int RoleId { get; set; }
        public string RoleCode {  get; set; }
        public string RoleName { get; set; }
        [SugarColumn(Length =50)]
        public string Description {  get; set; }
        [Navigate(typeof(UserRole),nameof(UserRole.RoleId),nameof(UserRole.UserId))]
        public  List<User> UserRoles {  get; set; }
        [Navigate(typeof(RolePermission),nameof(RolePermission.RoleId),nameof(RolePermission.PermissionId))]
        public List<RolePermission> RolePremissions { get; set; }
    }
}
