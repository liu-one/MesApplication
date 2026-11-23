using AutoMapper;
using MES.Application.Common.Exceptions;
using MES.Application.DTOS.Identiry;
using MES.Application.InterFaces.Identity;
using MES.Domain.Entitys.Identity;
using Microsoft.Identity.Client;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace MES.Application.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ISqlSugarClient _db;
        public UserService(IMapper mapper, ISqlSugarClient db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<bool> AssignRolesToUserAsync(int userId, List<int> roleIds)
        {
            int RoleCount = 0;
            //获取用户

            var user = await _db.Queryable<User>().FirstAsync(u => u.UserId == userId);
            if (user==null)
            {
                throw new EntityNotFoundExectpion(nameof(User), userId);
            }
            //验证角色是否存在
            foreach (var roleId in roleIds)
            {
                var role = await _db.Queryable<Role>().Where(r => r.RoleId == roleId).ToListAsync();
                if (role.Count != 0)
                    RoleCount++;

            }
            if (RoleCount != roleIds.Count())
                throw new ApplicationException("部分角色不存在");
            //方式一删除不在roleIdes中的角色获取用户角色
            //方式二，删除用户在UserRole中间表的全部角色，，然后再重新创建

            var currentUserRoles = await _db.Queryable<UserRole>().Where(r=>r.UserId == userId).ToListAsync();

            //删除不在新角色列表中的角色
            //List<int> roles = roleIds;
            if(currentUserRoles.Count>0)
            {
                foreach (var currentUserRole in currentUserRoles)
                {
                    if (!roleIds.Contains( currentUserRole.RoleId ))
                    {
                        // await _db.DeleteNav<User>(u => u.UserId == userId).Include(x => x.UserRoles).ExecuteCommandAsync();
                        await _db.Deleteable<UserRole>(new UserRole() { URId = currentUserRole.UserId }).ExecuteCommandAsync();
                        continue;
                    }
                    roleIds.Remove(currentUserRole.RoleId);

                }
            }
            
            //添加新角色
            //var currendRoleIds=currentUserRoles.Select(u=>u.RoleId)
            if(roleIds.Count > 0)
            {
                List<UserRole> roles = new List<UserRole>();
                
                foreach (var roleId in roleIds)
                {
                    roles.Add(new() { RoleId = roleId ,CreatedAt=DateTime.Now,CreatedBy=userId,UserId=userId,IsActive=true});
                }
                int count=await _db.Insertable(roles).ExecuteCommandAsync();
              
            }
            
            
            //_db.Updateable<User>().ExecuteCommand();
            // var result= await _db.Updateable(user).ExecuteCommandAsync();
            //var result = await _db.Storageable(user).ExecuteCommandAsync();
           //bool result= await _db.InsertNav(user).Include(r=>r.UserRoles).ExecuteCommandAsync();


            return true;


        }

        public async Task<bool> ChangePasswordAsync(ChangePassWordDto changePassWordDto)
        {
            var user = await _db.Queryable<User>().FirstAsync(u => u.UserId == changePassWordDto.UserId);
            if(user == null)  throw new EntityNotFoundExectpion(nameof(user),changePassWordDto.UserId);
            if (user.PasswordHash != changePassWordDto.OldPassword) throw new Exception("密码错误");
            user.PasswordHash = changePassWordDto.NewPassword;
            var result = _db.Storageable(user).ToStorage();
           var u= result.AsUpdateable.ExecuteCommandAsync();
            if(u==null)return false;
            return true;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            if(await _db.Queryable<User>().AnyAsync(u=>u.UserName==createUserDto.UserName))
                throw new EntityAlreadyExistsException(nameof(User),"UserName" ,createUserDto.UserName);
            if(await _db.Queryable<User>().AnyAsync(u=>u.UserCode==createUserDto.UserCode))
                throw new EntityAlreadyExistsException(nameof(User), "UserCode",createUserDto.UserName);
            if(createUserDto.DepartmentId.HasValue)
            {
                bool result=await _db.Queryable<Department>().AnyAsync(d => d.Id == createUserDto.DepartmentId);
                if (!result) 
                    throw new EntityNotFoundExectpion(nameof(Department),createUserDto.DepartmentId);
            }
            var user=_mapper.Map<User>(createUserDto);
            user.CreatedAt = DateTime.Now;
            user.PasswordHash = "123456";
            user.IsActive = true;
            var count= await _db.Insertable(user).ExecuteCommandAsync();
            var u=await _db.Queryable<User>().FirstAsync(u=>u.UserName==createUserDto.UserName);
            if(createUserDto.RoleIds!=null&&createUserDto.RoleIds.Any())
            {
                await AssignRolesToUserAsync(u.UserId, createUserDto.RoleIds);
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user= await _db.Queryable<User>().FirstAsync(u=>u.UserId == id);
            if (user == null) throw new EntityNotFoundExectpion(nameof(User), id);
          var result= await _db.DeleteNav<User>(u => u.UserId == id).Include(r => r.UserRoles, new DeleteNavOptions() { 
                ManyToManyIsDeleteA = true
            }).ExecuteCommandAsync();
            return true;
                

        }

        public async Task<List<UserDto>> GetActiveAsync()
        {
           var users= await _db.Queryable<User>().Where(u=>u.IsActive==true).ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
            
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _db.Queryable<User>().ToListAsync();
            var result = _mapper.Map<List<UserDto>>(users);
            return result;
        }

        public async Task<UserDto> GetUserByCodeAsync(string code)
        {
            var user = await _db.Queryable<User>().Where(u => u.UserCode == code).ToListAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetUserByDepartmentIdAsync(int departmentId)
        {
            var users = await _db.Queryable<User>().Where(u => u.DepartmentId == departmentId).ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            //var user = _db.Queryable<User>().Where(u => u.UserId == id).ToListAsync();
            var user1 = await _db.Queryable<User>().FirstAsync(u=>u.UserId==id);
            return _mapper.Map<UserDto>(user1);
        }

        public async Task<UserDto> GetUserByNameAsync(string name)
        {
            var user = await _db.Queryable<User>().Where(u => u.UserName == name).ToListAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetUserByRoleIdAsync(int roleId)
        {
            var user = await _db.Queryable<User>().Includes(x => x.Id == roleId).ToListAsync();
            return _mapper.Map<List<UserDto>>(user);

        }

        public async Task<string> RestPasswordAsync(int userId)
        {
            List<User> user = await _db.Queryable<User>().Where(u => u.UserId == userId).ToListAsync();
            if (user == null)
                return "用户不存在";
            foreach (var item in user)
            {
                item.PasswordHash = "123456";
            }
            var result = await _db.Updateable(user).ExecuteCommandAsync();
            if (result == 0)
                return "更新失败";
            return $"更新成功：{result}";

        }

        public async Task<UserDto> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            //获取用户
            string userName = updateUserDto.Username;
            var user = await _db.Queryable<User>().Where(u => u.Id == updateUserDto.Id).ToListAsync();
            if (user == null) throw new EntityNotFoundExectpion(nameof(User), updateUserDto.Id);
            //验证用户名是否存在
            var upDateName = await _db.Queryable<User>().Where(u => u.UserName == updateUserDto.Username).ToArrayAsync();

            if (!string.IsNullOrEmpty(updateUserDto.Username) && upDateName.Count() != 0)
                throw new EntityAlreadyExistsException(nameof(User), "UserName", userName);
            //验证工号是否存在
            if (!string.IsNullOrEmpty(updateUserDto.UserCode) && await _db.Queryable<User>().Where(u => u.UserCode == updateUserDto.UserCode).CountAsync() > 0)
                throw new EntityAlreadyExistsException(nameof(User), "UserCode", updateUserDto.UserCode);
            //验证部门是否存在
            if(updateUserDto.DepartmentId.HasValue)
            {
                var department = await _db.Queryable<Department>().Where(d => d.Id == updateUserDto.Id).ToListAsync();
                if (department == null)
                    throw new EntityNotFoundExectpion(nameof(department), updateUserDto.Id);
            }
            //更新用户信息
           User users= _mapper.Map<User>(updateUserDto);
            users.UpdateAt=DateTime.Now;
           int count=await _db.Updateable(users).ExecuteCommandAsync();
            if (count == 0)
                throw new Exception("更新失败");
            // 如果有角色ID，更新角色分配
            if (updateUserDto.RoleIds != null)
            {
                await AssignRolesToUserAsync(users.Id, updateUserDto.RoleIds);
            }



            return _mapper.Map<UserDto>(users);

        }
    }
}
