using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDataLibrary.Models;

public class Room : BaseModel
{
    public string label { get; set; }
    public RoomType RoomType { get; set; }

}
