using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDataLibrary.Models;
public class Client : BaseModel
{

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string CIN { get; set; }

    public DateOnly DateOfBirth { get; set; }

}
