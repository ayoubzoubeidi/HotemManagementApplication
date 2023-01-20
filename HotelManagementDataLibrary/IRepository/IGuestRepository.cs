using HotelManagementDataLibrary.Models;

namespace HotelManagementAbstractions.Repository;
public interface IGuestRepository
{
    Task<Guest?> GetGusetById(Guid id);
    Task<Guest?> GetGusetByCin(string cin);
    Task<Guest?> GetGusetByEmail(string email);
    void SaveGuest(Guest guest);
    void UpdateGuest(Guid id, Guest guest);
}
