using AutoMapper;
using MES.Application.DTOS.Identiry;
using MES.Application.InterFaces.Identity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using MES.Domain.Entitys.Identity;
using MES.Application.Common.Exceptions;

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


            

        }

        public Task<bool> DeleteRoleAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<RoleDto>> GetAllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<RoleDto>> GetIsActiveRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoleDto> GetRoleByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<RoleDto> GetRoleByIdAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<RoleDto>> GetRolesByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<RoleDto> UpdateRoleAsync(UpdateRoleDto role)
        {
            throw new NotImplementedException();
        }
    }
}
