using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Application.DTOS.Identiry
{
    public class LoginResponseDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 访问令牌
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// 令牌类型
        /// </summary>
        public string TokenType { get; set; } = "Bearer";

        /// <summary>
        /// 过期时间（秒）
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        public List<string> Roles { get; set; }

        /// <summary>
        /// 权限列表
        /// </summary>
        public List<string> Permissions { get; set; }
    }
}
