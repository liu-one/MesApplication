using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MES.Application.DTOS.Identiry
{
    /// <summary>
    /// 修改密码DTO
    /// </summary>
    public class ChangePassWordDto
    {
        
       
            /// <summary>
            /// 用户ID
            /// </summary>
            [Required]
            public int UserId { get; set; }

            /// <summary>
            /// 旧密码
            /// </summary>
            [Required]
            [StringLength(100)]
            public string OldPassword { get; set; }

            /// <summary>
            /// 新密码
            /// </summary>
            [Required]
            [StringLength(100, MinimumLength = 6)]
            public string NewPassword { get; set; }

            /// <summary>
            /// 确认新密码
            /// </summary>
            [Required]

            [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配")]
            public string ConfirmPassword { get; set; }
        }
}
