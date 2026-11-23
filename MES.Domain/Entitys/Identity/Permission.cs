using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain.Entitys.Identity
{
    public  class Permission:BaseEntity
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public int Id { get; set; }
        public string PermCode {  get; set; }
        public string PermName { get; set; }
        public string ResourceType { get; set; }
        public string ResourPath {  get; set; }
        [Navigate(typeof(RolePermission),nameof(RolePermission.PermissionId),nameof(RolePermission.RoleId))]
        public  List<RolePermission> RolePermissions { get; set; }
        
    }
}
