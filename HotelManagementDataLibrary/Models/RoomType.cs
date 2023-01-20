namespace HotelManagementDataLibrary.Models;

public class RoomType : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumberOfResidents { get; set; }

    public List<Room> Rooms { get; set; } = new();
}
