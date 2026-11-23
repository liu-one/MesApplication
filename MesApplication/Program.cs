
using MES.Application.InterFaces.Identity;
using MES.Application.Mapping;
using MES.Application.Services.Identity;
using MesApplication.Extension;
using Scalar.AspNetCore;
using SqlSugar;

namespace MesApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddHttpContextAccessor();
            //依赖注入
            builder.Services.AddApplicationServices();
            //添加AutoMpper
            builder.Services.AddAutoMapper(cfg=>
            cfg.AddProfile<MappingProfile>());
            //注册SqlSugar用AddScoped
            builder.Services.AddScoped<ISqlSugarClient>(s =>
               {
                   //Scoped用SqlSugarClient 
                   SqlSugarClient sqlSugar = new SqlSugarClient(new ConnectionConfig()
                   {
                       DbType = SqlSugar.DbType.MySql,
                       ConnectionString = "server=localhost;Database=MESProject;Uid=root;Pwd=123456",
                       IsAutoCloseConnection = true,
                   },
                  db =>
                  {
                      //每次上下文都会执行

                      //获取IOC对象不要求在一个上下文
                      //var log=s.GetService<Log>()

                      //获取IOC对象要求在一个上下文
                      //var appServive = s.GetService<IHttpContextAccessor>();
                      //var log= appServive?.HttpContext?.RequestServices.GetService<Log>();

                      db.Aop.OnLogExecuting = (sql, pars) =>
                      {

                      };
                  });
                   return sqlSugar;
               });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.MapScalarApiReference();

            app.Run();
        }
    }
}
