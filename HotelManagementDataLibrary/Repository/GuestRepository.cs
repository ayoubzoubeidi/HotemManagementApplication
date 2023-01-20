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

    public async Task<IEnumerable<Guest>> GetAll()
    {
        return await _dbContext.Guests.ToListAsync();
    }

    public async Task<Guest?> GetGusetByCin(string cin)
    {
        return await _dbContext.Guests.FirstOrDefaultAsync(guest => guest.CIN == cin);
    }

    public async Task<Guest?> GetGusetByEmail(string email)
    {
        return await _dbContext.Guests.FirstOrDefaultAsync(guest => guest.Email == email);
    }

    public async Task<Guest?> GetGusetById(Guid id)
    {
        return await _dbContext.Guests.FirstOrDefaultAsync(guest => guest.Id == id);
    }

    public async Task SaveGuest(Guest guest)
    {
        await _dbContext.Guests.AddAsync(guest);
        await _dbContext.SaveChangesAsync();

    }

    public async Task UpdateGuest(Guid id, Guest guest)
    {
        var savedGuest = await _dbContext.Guests
            .FirstOrDefaultAsync(guest => guest.Id == id);

        savedGuest.DateOfBirth = guest.DateOfBirth;
        savedGuest.FirstName = guest.FirstName;
        savedGuest.LastName = guest.LastName;
        savedGuest.Email = guest.Email;

        await _dbContext.SaveChangesAsync();
        
    }
}
