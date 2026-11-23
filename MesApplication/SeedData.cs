using System;
using System.Collections.Generic;
using System.Data;
using System.Security;
using System.Text;
using Azure.Core;
using MES.Domain.Entitys.Identity;
using SqlSugar;

namespace MES.Infrastructure
{
    public static class SeedData
    {

        public  static void iniSeedData(ISqlSugarClient db)
        {
            // 添加部门
            var departments = new List<Department>
            {
                new Department
                {
                    Id = 1,
                    DeptCode = "D001",
                    DeptName = "总经办",
                    ParentId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new Department
                {
                    Id = 2,
                    DeptCode = "D002",
                    DeptName = "生产部",
                    ParentId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new Department
                {
                    Id = 3,
                    DeptCode = "D003",
                    DeptName = "质量部",
                    ParentId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new Department
                {
                    Id = 4,
                    DeptCode = "D004",
                    DeptName = "研发部",
                    ParentId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new Department
                {
                    Id = 5,
                    DeptCode = "D005",
                    DeptName = "IT部",
                    ParentId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                }
            };
            db.Insertable(departments).ExecuteCommand();


            // 添加权限
            var permissions = new List<Permission>
            {
                new Permission
                {
                    Id = 1,
                    PermCode = "P001",
                    PermName = "用户管理",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new Permission
                {
                    Id = 2,
                    PermCode = "P002",
                    PermName = "角色管理",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new Permission
                {
                    Id = 3,
                    PermCode = "P003",
                    PermName = "部门管理",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new Permission
                {
                    Id = 4,
                    PermCode = "P004",
                    PermName = "权限管理",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new Permission
                {
                    Id = 5,
                    PermCode = "P005",
                    PermName = "生产计划管理",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                }
            };

            

            // 添加角色
            var roles = new List<Role>
            {
                new Role
                {
                    Id = 1,
                    RoleCode = "R001",
                    RoleName = "系统管理员",
                    Description = "拥有系统所有权限",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new Role
                {
                    Id = 2,
                    RoleCode = "R002",
                    RoleName = "生产主管",
                    Description = "拥有生产相关的所有权限",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new Role
                {
                    Id = 3,
                    RoleCode = "R003",
                    RoleName = "质量主管",
                    Description = "拥有质量相关的所有权限",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new Role
                {
                    Id = 4,
                    RoleCode = "R004",
                    RoleName = "操作员",
                    Description = "拥有生产操作权限",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                }
            };

            db.Insertable(roles).ExecuteCommand();

            // 添加用户
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    UserCode = "U001",
                    UserName= "admin",
                    PasswordHash = "AQAAAAEAACcQAAAAEGbEUqIXjGlNCuUMepZ6CKNQs5n2QbvAg5XJXhPrIEzBRIsmnIQ/gvjq91swucLsOw==", // 密码: Admin@123
                    RealName = "系统管理员",
                    Phone = "13800138000",
                    Email = "admin@example.com",
                    DepartmentId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new User
                {
                    Id = 2,
                    UserCode = "U002",
                    UserName= "production",
                    PasswordHash = "AQAAAAEAACcQAAAAEGbEUqIXjGlNCuUMepZ6CKNQs5n2QbvAg5XJXhPrIEzBRIsmnIQ/gvjq91swucLsOw==", // 密码: Admin@123
                    RealName = "生产主管",
                    Phone = "13800138001",
                    Email = "production@example.com",
                    DepartmentId = 2,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new User
                {
                    Id = 3,
                    UserCode = "U003",
                    UserName= "quality",
                    PasswordHash = "AQAAAAEAACcQAAAAEGbEUqIXjGlNCuUMepZ6CKNQs5n2QbvAg5XJXhPrIEzBRIsmnIQ/gvjq91swucLsOw==", // 密码: Admin@123
                    RealName = "质量主管",
                    Phone = "13800138002",
                    Email = "quality@example.com",
                    DepartmentId = 3,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new User
                {
                    Id = 4,
                    UserCode = "U004",
                    UserName= "operator",
                    PasswordHash = "AQAAAAEAACcQAAAAEGbEUqIXjGlNCuUMepZ6CKNQs5n2QbvAg5XJXhPrIEzBRIsmnIQ/gvjq91swucLsOw==", // 密码: Admin@123
                    RealName = "操作员",
                    Phone = "13800138003",
                    Email = "operator@example.com",
                    DepartmentId = 2,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new User
                {
                    Id = 5,
                    UserCode = "U005",
                    UserName= "developer",
                    PasswordHash = "AQAAAAEAACcQAAAAEGbEUqIXjGlNCuUMepZ6CKNQs5n2QbvAg5XJXhPrIEzBRIsmnIQ/gvjq91swucLsOw==", // 密码: Admin@123
                    RealName = "开发人员",
                    Phone = "13800138004",
                    Email = "developer@example.com",
                    DepartmentId = 4,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                }
            };

            db.Insertable(users).ExecuteCommand();
            // 添加角色权限关系
            var rolePermissions = new List<RolePermission>();

            // 系统管理员拥有所有权限
            for (int i = 1; i <= 5; i++)
            {
                rolePermissions.Add(new RolePermission
                {
                    RoleId = 1,
                    PermissionId = i,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                });
            }

            // 生产主管拥有生产计划权限
            rolePermissions.Add(new RolePermission
            {
                RoleId = 2,
                PermissionId = 5,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = 1
            });

            // 质量主管拥有部分权限
            rolePermissions.Add(new RolePermission
            {
                RoleId = 3,
                PermissionId = 3,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = 1
            });

            db.Insertable(rolePermissions).ExecuteCommand();

            // 添加用户角色关系
            var userRoles = new List<UserRole>
            {
                new UserRole
                {
                    UserId = 1,
                    RoleId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new UserRole
                {
                    UserId = 2,
                    RoleId = 2,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new UserRole
                {
                    UserId = 3,
                    RoleId = 3,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new UserRole
                {
                    UserId = 4,
                    RoleId = 4,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
                new UserRole
                {
                    UserId = 5,
                    RoleId = 4,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                }
            };

            db.Insertable(userRoles).ExecuteCommand();
        }
    }
}
        
    


