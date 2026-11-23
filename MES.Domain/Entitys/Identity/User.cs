using Kdbndp.BouncyCastle;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MES.Domain.Entitys.Identity
{
    public  class User:BaseEntity
    {
        [SugarColumn(IsPrimaryKey = true,IsIdentity = true)]
        public int UserId { get; set; }
        public string UserCode {  get; set; }
        public string UserName { get; set; }    
        public string PasswordHash {  get; set; }
        public string RealName {  get; set; }
        [SugarColumn(Length =11)]
        public string Phone {  get; set; }
        public string Email {  get; set; }
        public int? DepartmentId {  get; set; }
        [Navigate(NavigateType.ManyToOne,nameof(DepartmentId))]
        public Department Department{  get; set; }
        [Navigate(typeof(UserRole), nameof(UserRole.UserId),nameof(UserRole.RoleId))]
        public List<Role> UserRoles { get; set; }
    }
}
