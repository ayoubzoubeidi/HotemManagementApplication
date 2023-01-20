using HotelManagementAbstractions.Repository;
using HotelManagementDataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementDataLibrary.Repository;
public class GuestRepository : IGuestRepository
{

    private readonly HotelManagementDbContext _dbContext;

    public GuestRepository(HotelManagementDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Guest?> GetGusetByCin(string cin)
    {
        return await _dbContext.Set<Guest>().FirstOrDefaultAsync(guest => guest.CIN == cin);
    }

    public async Task<Guest?> GetGusetByEmail(string email)
    {
        return await _dbContext.Set<Guest>().FirstOrDefaultAsync(guest => guest.Email == email);
    }

    public async Task<Guest?> GetGusetById(Guid id)
    {
        return await _dbContext.Set<Guest>().FirstOrDefaultAsync(guest => guest.Id == id);
    }

    public async void SaveGuest(Guest guest)
    {
        await _dbContext.Set<Guest>().AddAsync(guest);
        await _dbContext.SaveChangesAsync();

    }

    public async void UpdateGuest(Guid id, Guest guest)
    {
        _dbContext.Entry(await _dbContext.Set<Guest>()
            .FirstOrDefaultAsync(guest => guest.Id == id)).CurrentValues.SetValues(guest);
        await _dbContext.SaveChangesAsync();
        
    }
}
