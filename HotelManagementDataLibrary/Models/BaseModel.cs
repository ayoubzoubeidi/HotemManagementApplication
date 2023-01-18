namespace HotelManagementDataLibrary.Models;

public class BaseModel
{
    public Guid Id { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedOn { get; set; }

    public DateTime LastAccessed { get; set; }
}
