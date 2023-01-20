namespace HotelManagementDataLibrary.Models;
public class Reservation : BaseModel
{
    public Guid RoomId { get; set; }
    public Guid GuestId { get; set; }
    public Guid PaymentId { get; set; }

    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }

    public bool meal { get; set; }
    public int adults { get; set; }
    public int children { get; set; }

    public Room Room { get; set; }
    public Guest Guest { get; set; }
    public Payment Payment { get; set; }

}
