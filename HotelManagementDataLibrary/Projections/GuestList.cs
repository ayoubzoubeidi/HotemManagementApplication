using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDataLibrary.Projections;
public class GuestList
{

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string CIN { get; set; }

    public DateTime DateOfBirth { get; set; }

    public GuestList(string firstName, string lastName, string email, string cIN, DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        CIN = cIN;
        DateOfBirth = dateOfBirth;
    }

}
