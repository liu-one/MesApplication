using AutoMapper;
using MES.Application.Common.Exceptions;
using MES.Application.DTOS.Identiry;
using MES.Application.InterFaces.Identity;
using MES.Domain.Entitys.Identity;
using SQLitePCL;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using static Dm.net.buffer.ByteArrayBuffer;

namespace MES.Application.Services.Identity
{
    public class RoleService : IRoleService
    {
        private readonly ISqlSugarClient _db;
        private readonly IMapper _mapper;
        public RoleService(ISqlSugarClient db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public Task<bool> AssignPermissionToRoleAsync(int roleId, List<int> permissionIds)
        {
            throw new NotImplementedException();
        }

        public async Task<RoleDto> CreateRoleAsync(CreateRoleDto role)
        {
            var roles=await _db.Queryable<Role>().FirstAsync(r=>r.RoleCode==role.RoleCode);
            if(roles != null ) throw new EntityAlreadyExistsException(nameof(roles),"role",role.RoleCode);
            Role r = _mapper.Map<Role>(role);
            r.IsActive = true;
            r.UpdateAt = DateTime.Now;
           
            var Crole = await _db.Insertable(r).ExecuteCommandAsync();
            var r1= await _db.Queryable<Role>().FirstAsync(r => r.RoleCode == role.RoleCode);
            //分配权限
            if (role.PermissionIds.Any() )
            {
                List<RolePermission> rolePermission = new List<RolePermission>();
                foreach(var permissionId in role.PermissionIds)
                {
                    rolePermission.Add(new (){ RoleId=r1.RoleId, PermissionId=permissionId ,CreatedAt=DateTime.Now,IsActive=true});
                }
                await _db.Insertable(rolePermission).ExecuteCommandAsync();
            }
            return _mapper.Map<RoleDto>(r1);
           

            

        }

        public async Task<bool> DeleteRoleAsync(int roleId)
        {
            Role role=await _db.Queryable<Role>().FirstAsync(r=>r.RoleId==roleId);
            if(role==null)throw new EntityNotFoundExectpion(nameof(role),roleId);
            //bool result = await _db.DeleteNav<Role>(r => r.RoleId == roleId).Include(p => p.RolePremissions, new DeleteNavOptions() { 
            //    ManyToManyIsDeleteA = true }).ExecuteCommandAsync();
            int count=await _db.Deleteable<Role>(new Role() { RoleId=roleId}).ExecuteCommandAsync();
            var result=await _db.Deleteable<RolePermission>().EnableQueryFilter().Where(p=>p.RoleId==roleId).ExecuteCommandAsync();

            return true;
        }

        public async Task<List<RoleDto>> GetAllRolesAsync()
        {
            var roles=await _db.Queryable<Role>().ToListAsync();
            return _mapper.Map<List<RoleDto>>(roles);
        }

        public async Task<List<RoleDto>> GetIsActiveRoleAsync()
        {
            var result=await _db.Queryable<Role>().Where(r=>r.IsActive==true).ToListAsync();
            return _mapper.Map<List<RoleDto>>(result);
        }

        public async Task<RoleDto> GetRoleByCodeAsync(string code)
        {
            var role = await _db.Queryable<Role>().FirstAsync(r => r.RoleCode == code);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> GetRoleByIdAsync(int roleId)
        {
            var role = await _db.Queryable<Role>().FirstAsync(r => r.RoleId == roleId);
            return _mapper.Map<RoleDto>(role);
        }

        public async  Task<List<RoleDto>> GetRolesByUserIdAsync(int userId)
        {
           // var roles=await _db.Queryable<Role>().Includes(x=>x.UserRoles.Where(u=>u.UserId==userId).ToList()).Where(x=>x.UserRoles==userId).ToListAsync();
            //var role = await _db.Queryable<Role>().FirstAsync(r => r.us== roleId);
            //if (roles == null) throw new EntityNotFoundExectpion(nameof(Role), userId);
            var roles= await _db.Queryable<Role>()
                .InnerJoin<UserRole>((r,ur)=>r.RoleId==ur.RoleId)
                .InnerJoin<User>((r,ur,u)=>ur.UserId==u.UserId)
                .Where((r, ur, u) => u.Id == userId)
               .ToListAsync();



            return _mapper.Map<List<RoleDto>>(roles);
        }

        public Task<RoleDto> UpdateRoleAsync(UpdateRoleDto role)
        {
            throw new NotImplementedException();
        }
    }
}
