using HotelManagementAbstractions.Repository;
using HotelManagementDataLibrary.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace HotelManagementDataLibrary;
public static class DependencyInjection
{

    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        // hard coded connection string configuration property to change afterwards
        string? connectionString = configuration.GetConnectionString("Dev");
        if (!connectionString.IsNullOrEmpty())
        {
            services.AddDbContextPool<HotelManagementDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IGuestRepository, GuestRepository>();
        }

    }

}
