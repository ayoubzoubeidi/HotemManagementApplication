namespace HotelManagementDataLibrary.Models;
public class Personnel : BaseModel
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string CIN { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string JobDescirption { get; set; }

    public decimal Salary { get; set; }

}
