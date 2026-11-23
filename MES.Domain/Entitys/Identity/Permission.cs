using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain.Entitys.Identity
{
    public  class Permission:BaseEntity
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public int PId { get; set; }
        public string PermCode {  get; set; }
        public string PermName { get; set; }
        public string ResourceType { get; set; } = "T";
        public string ResourPath { get; set; } = "T";
        [Navigate(typeof(RolePermission),nameof(RolePermission.PermissionId),nameof(RolePermission.RoleId))]
        public  List<Role> Roles { get; set; }
        
    }
}
