using HotelManagementDataLibrary.Models;

namespace HotelManagementAbstractions.Repository;
public interface IGuestRepository
{

    Task<IEnumerable<Guest>> GetAll();
    Task<Guest?> GetGusetById(Guid id);
    Task<Guest?> GetGusetByCin(string cin);
    Task<Guest?> GetGusetByEmail(string email);
    Task SaveGuest(Guest guest);
    Task UpdateGuest(Guid id, Guest guest);
}
