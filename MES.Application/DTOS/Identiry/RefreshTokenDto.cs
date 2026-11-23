using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MES.Application.DTOS.Identiry
{
    public  class RefreshTokenDto
    {
        /// <summary>
        /// 刷新令牌
        /// </summary>
        [Required(ErrorMessage = "刷新令牌不能为空")]
        public string RefreshToken { get; set; }
    }
}
