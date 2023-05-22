using System.Collections.Generic;

namespace Course_project
{
    public class Guest
    {
        public string FIOGuest { get; set; }
        public int AgeGuest { get; set; }
        public string CheckInGuest { get; set; }
        public string CheckOutGuest { get; set; }
        public int GuestRoomID { get; set; }
        public static List<Guest> mass_of_Guests = new List<Guest>();
        public Guest(int id = 0, string type = "Ivanov Ivan Ivanovich", int age = 0, string checkin = "", string checkout = "", int check = 0)
        {
            this.FIOGuest = type;
            this.AgeGuest = age;
            this.CheckInGuest = checkin;
            this.CheckOutGuest = checkout;
            this.GuestRoomID = check;
            Guest.mass_of_Guests.Add(this);
        }
        static public Guest get_by_GuestID(string FIO)
        {
            foreach (Guest guest in Guest.mass_of_Guests)
                if (guest.FIOGuest == FIO)
                    return guest;
            return null;
        }
    }
    public class Room
    {
        public string TypeRoom { get; set; }
        public int FloorRoom { get; set; }
        public int NumPlacesRoom { get; set; }
        public double CostRoom { get; set; }
        public bool WindowsRoom { get; set; }
        public int CountGuestInRoom { get; set; }
        public int GuestRoomID { get; set; }
        public static List<Room> mass_of_Rooms = new List<Room>();
        public Room(int code = 0, string type = "default type", int floor = 0,
            int places = 0, double cost = 0.0, bool windows = true, int count = 0)
        {
            this.GuestRoomID = code;
            this.TypeRoom = type;
            this.FloorRoom = floor;
            this.NumPlacesRoom = places;
            this.CostRoom = cost;
            this.WindowsRoom = windows;
            this.CountGuestInRoom = count;
            Room.mass_of_Rooms.Add(this);
        }
        static public Room get_by_CodeRoom(int code)
        {
            foreach (Room op in Room.mass_of_Rooms)
                if (op.GuestRoomID == code)
                    return op;
            return null;
        }
    }
}
