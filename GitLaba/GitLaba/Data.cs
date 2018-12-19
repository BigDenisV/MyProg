using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GitLaba
{
    [Serializable]
    public class Room
    {
        public string room_type;
        public int area;

        public Room(string r_type, int ar)
        {
            room_type = r_type;
            area = ar;
        }
    }

    [Serializable]
    public class House
    {
        public string street_name;
        public int street_number;
        public int apartment;
        public string description;
        public List<Room> Rooms;
        public int full_area;

        public House(string s_name = "",int s_number = 0, int apart = 0,string descr = "")
        {
            street_name = s_name;
            street_number = s_number;
            apartment = apart;
            description = descr;
            Rooms = new List<Room>();
        }

        public void add_Room(string r_type, int ar)
        {
            Rooms.Add(new Room(r_type, ar));
            full_area += ar;
        }
    }
}
