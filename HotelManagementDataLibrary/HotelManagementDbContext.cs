using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDataLibrary;
public class HotelManagementDbContext : DbContext
{
    public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options)
    {
    }
    
}
