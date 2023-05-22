using System;
using System.Drawing;
using System.Windows.Forms;

namespace Course_project
{
    public partial class NewRoom : Form
    {
        public static int codeRoom = 0;
        public static string typeRoom = "";
        public static int floorRoom = 0;
        public static int placesRoom = 0;
        public static double costRoom = 0;
        public static bool windowRoom = false;
        public static int countguestinroom = 0;

        public NewRoom()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            CodeRoomLabel.Text = "";
            TypeRoomLabel.Text = "";
            FloorRoomLabel.Text = "";
            PlacesRoomText.Text = "";
            bool checker = true;
            int code = (int)RoomCodeSelector.Value;
            foreach (Room op in Room.mass_of_Rooms)
                if (code == op.GuestRoomID)
                {
                    CodeRoomLabel.Text = "Этот номер уже существует!";
                    CodeRoomLabel.ForeColor = Color.Red;
                    checker = false;
                }
            if (typeRoomSelector.SelectedIndex == -1)
            {
                TypeRoomLabel.Text = "Заполните поле <Тип номера>";
                TypeRoomLabel.ForeColor = Color.Red;
                checker = false;
            }
            if (FloorRoomSelector.SelectedIndex == -1)
            {
                FloorRoomLabel.Text = "Заполните поле <Этаж номера>";
                FloorRoomLabel.ForeColor = Color.Red;
                checker = false;
            }
            if (PlacesRoomSelector.SelectedIndex == -1)
            {
                PlacesRoomText.Text = "Заполните поле <Количество мест>";
                PlacesRoomText.ForeColor = Color.Red;
                checker = false;
            }
            if (double.TryParse(CostRoomSelector.Text, out _))
            {
                costRoom = Convert.ToDouble(CostRoomSelector.Text);
            }
            if (checker)
            {
                new Room(code, typeRoomSelector.Text, Int32.Parse(FloorRoomSelector.Text), Int32.Parse(PlacesRoomSelector.Text), costRoom, WindowsCheckBox.Checked, 0);
                codeRoom = code;
                typeRoom = typeRoomSelector.SelectedItem as string;
                floorRoom = Convert.ToInt32(FloorRoomSelector.SelectedItem);
                placesRoom = Convert.ToInt32(PlacesRoomSelector.SelectedItem);
                windowRoom = WindowsCheckBox.Checked;
                countguestinroom = 0;
                Close();
            }
            else
                MessageBox.Show($"Некорректные данные", "Добавление номера", 0, MessageBoxIcon.Information);
            return;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            codeRoom = 0;
            typeRoom = "";
            floorRoom = 0;
            placesRoom = 0;
            costRoom = 0;
            windowRoom = false;
            countguestinroom = 0;
            Close();
        }

        private void AddNewRoom_Load(object sender, EventArgs e)
        {
            foreach (Room op in Room.mass_of_Rooms)
            {
                int code = (int)RoomCodeSelector.Value;
                if (code == op.GuestRoomID)
                    RoomCodeSelector.Value++;
            }
        }
    }
}
