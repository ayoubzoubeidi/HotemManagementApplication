namespace HotelManagementDataLibrary.Models;

public class Room : BaseModel
{
    public string label { get; set; }
    public RoomType RoomType { get; set; }

}
