namespace HotelManagementDataLibrary.Models;
public class Payment : BaseModel
{
    public Guid GuestId { get; set; }

    public List<Reservation> Reservations { get; set; } = new();

    public decimal TotalPaid { get; set; }

    public Guest Guest { get; set; }
}
