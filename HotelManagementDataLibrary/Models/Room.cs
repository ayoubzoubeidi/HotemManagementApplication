namespace HotelManagementDataLibrary.Models;

public class Room : BaseModel
{
    public string Label { get; set; }
    public RoomType RoomType { get; set; }

    public Guid RoomTypeId { get; set; }

    public decimal Price { get; set; }
    public List<Reservation> Reservations { get; set; } = new();

}
