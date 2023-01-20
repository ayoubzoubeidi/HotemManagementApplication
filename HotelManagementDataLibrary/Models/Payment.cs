namespace HotelManagementDataLibrary.Models;
public class Payment : BaseModel
{
    public List<Reservation> Reservations { get; set; } = new();

    public decimal TotalPaid { get; set; }

}
