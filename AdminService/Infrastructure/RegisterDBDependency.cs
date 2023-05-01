using Microsoft.EntityFrameworkCore;
using AdminService.DataAccessLayer.Context;

namespace AdminService.Infrastructure
{
    public static class RegisterDBDependency
    {
        public static void RegisterPSqlDatabaseContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DefaultDBContext>(options =>
            {
                options.UseNpgsql(connectionString, options =>
                {
                    options.EnableRetryOnFailure(3);
                    options.MigrationsAssembly(typeof(DefaultDBContext).Assembly.FullName);
                });
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
        }

        public static void RegisterMSSqlDatabaseContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DefaultDBContext>(options =>
            {
                options.UseSqlServer(connectionString, options =>
                {
                    options.EnableRetryOnFailure(3);
                    options.MigrationsAssembly(typeof(DefaultDBContext).Assembly.FullName);
                });
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
        }

        public static void RegisterSqliteDatabaseContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DefaultDBContext>(options =>
            {
                options.UseSqlite(connectionString, options =>
                {
                    options.MigrationsAssembly(typeof(DefaultDBContext).Assembly.FullName);
                });
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
