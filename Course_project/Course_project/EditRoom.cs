using System;
using System.Drawing;
using System.Windows.Forms;

namespace Course_project
{
    public partial class EditRoom : Form
    {
        public static int RoomID;
        public static string TypeRoom;
        public static int FloorRoom;
        public static int PlacesRoom;
        public static double CostRoom;
        public static bool WindowRoom;
        public static int CountGuestRoom;

        public EditRoom(Room pt)
        {
            RoomID = pt.GuestRoomID;
            TypeRoom = pt.TypeRoom;
            FloorRoom = pt.FloorRoom;
            PlacesRoom = pt.NumPlacesRoom;
            CostRoom = pt.CostRoom;
            WindowRoom = pt.WindowsRoom;
            CountGuestRoom = pt.CountGuestInRoom;
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            int code = (int)RoomCodeSelector.Value;
            foreach (Room op in Room.mass_of_Rooms)
                if (code == op.GuestRoomID)
                {
                    CodeRoomLabel.Text = "Этот номер уже существует!";
                    CodeRoomLabel.ForeColor = Color.Red;
                    return;
                }
            Room.get_by_CodeRoom(RoomID).GuestRoomID = RoomID = (int)RoomCodeSelector.Value;
            Room.get_by_CodeRoom(RoomID).TypeRoom = TypeRoom = typeRoomSelector.SelectedItem.ToString();
            Room.get_by_CodeRoom(RoomID).FloorRoom = FloorRoom = Convert.ToInt32(FloorRoomSelector.SelectedItem);
            Room.get_by_CodeRoom(RoomID).NumPlacesRoom = Convert.ToInt32(PlacesRoomSelector.SelectedItem);
            Room.get_by_CodeRoom(RoomID).CostRoom = CostRoom = Convert.ToDouble(CostRoomSelector.Text);
            Room.get_by_CodeRoom(RoomID).WindowsRoom = WindowRoom = WindowsCheckBox.Checked;
            Close();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditRoom_Load(object sender, EventArgs e)
        {
            RoomCodeSelector.Value = Convert.ToDecimal(RoomID.ToString());
            typeRoomSelector.SelectedItem = TypeRoom.ToString();
            FloorRoomSelector.SelectedItem = FloorRoom.ToString();
            PlacesRoomSelector.SelectedItem = PlacesRoom.ToString();
            CostRoomSelector.Text = CostRoom.ToString();
            WindowsCheckBox.Checked = WindowRoom;
        }
    }
}
