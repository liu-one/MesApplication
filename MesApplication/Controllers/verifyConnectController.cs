using MES.Domain.Entitys.Identity;
using MES.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace MesApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class verifyConnectController : ControllerBase
    {
        private readonly ISqlSugarClient _db;
        public verifyConnectController(ISqlSugarClient db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            bool result = _db.Ado.IsValidConnection();
            if(result)
            {
                return Ok("数据库连接成功");
            }
            return Ok("数据库连接失败");
        }
        [HttpGet]
        public IActionResult InitialTables()
        {
            Type[] types = Assembly
            .LoadFrom("E:\\source\\repos\\MesApplication\\MES.Domain\\bin\\Debug\\net10.0\\MES.Domain.dll")//如果 .dll报错，可以换成 xxx.exe 有些生成的是exe 
            .GetTypes().Where(it => it.FullName.Contains("MES.Domain.Entitys.Identity"))//命名空间过滤，可以写其他条件
            .ToArray();//断点调试一下是不是需要的Type，不是需要的在进行过滤

            _db.CodeFirst.SetStringDefaultLength(200).InitTables(types);//根据types创建表

            return Ok("数据库表初始化成功");
        }
        [HttpGet]
        public IActionResult InitialDatabase()
        {
            SeedData.iniSeedData(_db);

            return Ok("初始化数据种子成功");
        }
    }
}
