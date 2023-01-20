using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDataLibrary;
public class HotelManagementDbContextDesignFactory : IDesignTimeDbContextFactory<HotelManagementDbContext>
{
    public HotelManagementDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        var optionsBuilder = new DbContextOptionsBuilder<HotelManagementDbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Dev"));
        Console.WriteLine(configuration.GetConnectionString("Dev"));
        return new HotelManagementDbContext(optionsBuilder.Options);
    }
}
