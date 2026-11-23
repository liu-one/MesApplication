using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain.Entitys.Identity
{
    public class UserRole:BaseEntity
    {
       // [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public  int URId {  get; set; }
        public int UserId {  get; set; }
        public int RoleId { get; set; } 
        //public virtual User User { get; set; }
        //public virtual Role Role { get; set; }
    }
}
