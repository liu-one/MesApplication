using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain.Entitys.Identity
{
    public  class Department:BaseEntity
    {
        public int Id { get; set; }
        public string DeptCode {  get; set; }
        public string DeptName {  get; set; }
        public int? ParentId { get; set; }
        [Navigate(NavigateType.ManyToOne,nameof(Id))]
        public  Department Partent { get; set; }
        [Navigate(NavigateType.OneToMany,nameof(ParentId))]
        public  List<Department> Departments { get; set; }
        [Navigate(NavigateType.OneToMany,nameof(User.UserId))]
        public  List<User> Users { get; set; }

    }
}
