using MES.Application.DTOS.Identiry;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Application.InterFaces.Identity
{
    public  interface IUserService
    {
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns>用户列表</returns>
        Task<List<UserDto>> GetAllUsersAsync();
        /// <summary>
        /// 获取活跃的用户
        /// </summary>
        /// <returns>用户列表</returns>
        Task<List<UserDto>> GetActiveAsync();
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns>返回用户</returns>
        Task<UserDto> GetUserById(int id);
        /// <summary>
        /// 通过用户名获取用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns>用户信息</returns>
        Task<UserDto> GetUserByNameAsync(string name);
        /// <summary>
        /// 通过用户工号获取用户
        /// </summary>
        /// <param name="code"></param>
        /// <returns>用户信息</returns>
        Task<UserDto> GetUserByCodeAsync(string code);
        /// <summary>
        /// 根据部门Id获取用户
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>用户信息</returns>
        Task<List<UserDto>> GetUserByDepartmentIdAsync(int departmentId);
        /// <summary>
        /// 根据角色Id获取用户信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>用户信息</returns>
        Task<List<UserDto>> GetUserByRoleIdAsync(int roleId);
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <returns>创建的用户信息</returns>
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="updateUserDto"></param>
        /// <returns>更新后的用户信息</returns>
        Task<UserDto> UpdateUserAsync(UpdateUserDto updateUserDto);
        /// <summary>
        /// 根据Id删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns>是否删除成功</returns>
        Task<bool> DeleteUserAsync(int id);
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="changePassWordDto"></param>
        /// <returns>是否修改成功</returns>
        Task<bool> ChangePasswordAsync(ChangePassWordDto changePassWordDto);
        /// <summary>
        /// 根据Id重置密码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>新密码</returns>
        Task<string> RestPasswordAsync(int userId);
        /// <summary>
        /// 为用户分配角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns>是否分配成功</returns>
        Task<bool> AssignRolesToUserAsync(int userId, List<int> roleIds);
    }
}
