using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Services.Implementation.AccountServiceImpl;
using DaoVietAnh.Asm2.Repo.Services.Implementation.CategoryServiceImpl;
using DaoVietAnh.Asm2.Repo.Services.Implementation.PizzaServiceImpl;
using DaoVietAnh.Asm2.Repo.Services.Implementation.SupplierServiceImpl;
using DaoVietAnh.Asm2.Repo.Services;
using Microsoft.EntityFrameworkCore;
using DaoVietAnh.Asm2.Repo.Services.Implementation.MemberServiceImpl;
using DaoVietAnh.Asm2.Repo.Services.Implementation.OrderServiceImpl;


namespace DaoVietAnh.Asm2.Web.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<ShoppingWebsiteDBContext>(options => options.UseSqlServer(GetConnectionString()));
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }

        private static string GetConnectionString()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config["ConnectionStrings:ShoppingWebsiteDB"];

            return strConn;
        }
    }
}
