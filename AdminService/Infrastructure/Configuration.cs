using Microsoft.EntityFrameworkCore;
using AdminService.Core.Middlewares;
using AdminService.DataAccessLayer.Context;
using AdminService.DataAccessLayer.Repository.Impl;
using AdminService.DataAccessLayer.Repository.Interfaces;
using AdminService.Infrastructure;

namespace AdminService.Core
{
    public static class Configuration
    {
        public static void RegisterProjectDependencies(this WebApplicationBuilder builder)
        {

            //Fix JSON Self Referencing Loop Exceptions
            builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //builder.Services.RegisterSqliteDatabaseContext(builder.Configuration.GetConnectionString("DefaultCon"));
            builder.Services.RegisterPSqlDatabaseContext(builder.Configuration.GetConnectionString("DefaultCon"));
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddAutoMapper(typeof(Program));
            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY") ?? builder.Configuration["JWT:Key"];
            builder.Services.RegisterJWTAuthentication(jwtKey);
            builder.Services.AddSwaggerGenWithJWTSecurity();
        }

        public static void RegisterProjectMiddleWares(this IApplicationBuilder builder)
        {
            builder.UseSerilogRequestLogging(opt =>
            {
                opt.Logger = Log.Logger;
            });

            builder.UseErrorHandler();
        }
    }
}
