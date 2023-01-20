namespace HotelManagementDataLibrary.Models;
public class Guest : BaseModel
{

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string CIN { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public List<Reservation> Reservations { get; set; } = new();

}
