using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDataLibrary;
public static class DependencyInjection
{

    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        // hard coded connection string configuration property to change afterwards
        string? connectionString = configuration.GetConnectionString("Dev");
        if (connectionString != null || connectionString.Length > 0)
        {
            services.AddDbContext<HotelManagementDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

    }

}
