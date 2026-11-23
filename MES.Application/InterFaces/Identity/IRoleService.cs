using MES.Application.DTOS.Identiry;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Application.InterFaces.Identity
{
    public interface IRoleService
    {
        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns>所有角色</returns>
        Task<List<RoleDto>> GetAllRolesAsync();
        /// <summary>
        /// 获取所有激活的角色
        /// </summary>
        /// <returns>所有激活的角色</returns>
        Task<List<RoleDto>> GetIsActiveRoleAsync();
        /// <summary>
        /// 通过Id获取角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>角色</returns>
        Task<RoleDto> GetRoleByIdAsync(int  roleId);
        /// <summary>
        /// 通过编码获取角色
        /// </summary>
        /// <param name="code"></param>
        /// <returns>角色</returns>

        Task<RoleDto> GetRoleByCodeAsync(string code);
        /// <summary>
        /// 通过用户ID获取角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>用户角色列表</returns>
        Task<List<RoleDto>> GetRolesByUserIdAsync(int userId);
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns>创建的角色信息</returns>
        Task<RoleDto> CreateRoleAsync(CreateRoleDto role);
        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns>更新的角色</returns>
        Task<RoleDto> UpdateRoleAsync(UpdateRoleDto role);
        /// <summary>
        /// 根据角色Id删除角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>是否删除成功</returns>
        Task<bool> DeleteRoleAsync(int roleId);
        /// <summary>
        /// 根据ID为角色分配权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permissionIds"></param>
        /// <returns>是否分配成功</returns>
        Task<bool> AssignPermissionToRoleAsync(int roleId, List<int> permissionIds);

    }
}
