using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Course_project
{
    public partial class EditGuest : Form
    {
        public static int CodeRoomGuest;
        public static string FIOGuest;
        public static string AgeGuest;
        public static string CheckInGuest;
        public static string CheckOutGuest;

        public static bool WindowsInsert;
        public static string PlacesInsert;
        public static string TypeRoomInsert;
        public EditGuest(Guest pt)
        {
            CodeRoomGuest = pt.GuestRoomID;
            if (CodeRoomGuest != 0)
            {
                WindowsInsert = Room.get_by_CodeRoom(CodeRoomGuest).WindowsRoom;
                PlacesInsert = Room.get_by_CodeRoom(CodeRoomGuest).NumPlacesRoom.ToString();
                TypeRoomInsert = Room.get_by_CodeRoom(CodeRoomGuest).TypeRoom;
            }
            FIOGuest = pt.FIOGuest;
            AgeGuest = pt.AgeGuest.ToString();
            CheckInGuest = pt.CheckInGuest;
            CheckOutGuest = pt.CheckOutGuest;
            InitializeComponent();
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            FIOGuestLabel.Text = "";
            AgeGuestLabel.Text = "";
            CheckInGuestLabel.Text = "";
            CheckOutGuestLabel.Text = "";
            TypeRoomLabel.Text = "";
            PlacesRoomText.Text = "";
            bool checker = true;
            Regex regGuestFIO = new Regex(@"^[А-ЯЁ]+[а-яё]+ ([А-ЯЁ]+[а-яё]* [А-ЯЁ]+[а-яё]*$|[А-ЯЁ][.] [А-ЯЁ][.]$|[А-ЯЁ][.][А-ЯЁ][.])");
            Regex regAge = new Regex(@"^(1[0-2][0-9]|[1-9][0-9]|[1-9])$|^130$");
            Regex regData = new Regex(@"^(0?[1-9]|[12][0-9]|3[01])([\ /.-])(0?[1-9]|1[012])\2(202[3-9]|2[3-9]\d|\d{4})$");
            if (!regGuestFIO.IsMatch(GuestFIO.Text))
            {
                FIOGuestLabel.Text = "Примеры ввода: Антонов А В";
                FIOGuestLabel.ForeColor = Color.Red;
                checker = false;
            }
            if (!regAge.IsMatch(GuestAge.Text))
            {
                AgeGuestLabel.Text = "Введите человеческий возраст";
                AgeGuestLabel.ForeColor = Color.Red;
                checker = false;
            }
            if (!regData.IsMatch(CheckIn_Guest.Text))
            {
                CheckInGuestLabel.Text = "Пример: 01/01/2001";
                CheckInGuestLabel.ForeColor = Color.Red;
                checker = false;
            }
            if (!regData.IsMatch(CheckOut_Guest.Text))
            {
                CheckOutGuestLabel.Text = "Пример: 02/02/2002";
                CheckOutGuestLabel.ForeColor = Color.Red;
                checker = false;
            }
            if (typeRoomSelector.SelectedIndex != -1 && PlacesRoomSelector.SelectedIndex != -1 && Room.mass_of_Rooms.Count != 0 && checker)
            {
                bool edited = false;
                foreach (Room room in Room.mass_of_Rooms)
                {
                    if (CodeRoomGuest == room.GuestRoomID)
                    {
                        room.CountGuestInRoom--;
                        CodeRoomGuest = 0;
                        edited = !edited;
                    }
                    if (room.CountGuestInRoom < room.NumPlacesRoom && room.TypeRoom == typeRoomSelector.Text && room.NumPlacesRoom == Convert.ToInt32(PlacesRoomSelector.SelectedItem) && room.WindowsRoom == WindowsCheckBox.Checked)
                    {
                        room.CountGuestInRoom++;
                        Guest.get_by_GuestID(FIOGuest).FIOGuest = FIOGuest = GuestFIO.Text;
                        AgeGuest = GuestAge.Text;
                        Guest.get_by_GuestID(FIOGuest).AgeGuest = Convert.ToInt32(AgeGuest);
                        Guest.get_by_GuestID(FIOGuest).CheckInGuest = CheckInGuest = CheckIn_Guest.Text;
                        Guest.get_by_GuestID(FIOGuest).CheckOutGuest = CheckOutGuest = CheckOut_Guest.Text;
                        Guest.get_by_GuestID(FIOGuest).GuestRoomID = CodeRoomGuest = room.GuestRoomID;
                        checker = false;
                        edited = true;
                        Close();
                        break;
                    }
                }
                if (!edited) MessageBox.Show("Не нашлось номера по заданным критериям", "Заселение гостя", 0, MessageBoxIcon.Information);
            }
            else if (typeRoomSelector.SelectedIndex == -1 || PlacesRoomSelector.SelectedIndex == -1 || WindowsCheckBox.Checked)
                MessageBox.Show($"Не полностью введены критерии заселения", "Редактирование гостя",
                    0, MessageBoxIcon.Information);


            if (checker)
            {
                Guest.get_by_GuestID(FIOGuest).FIOGuest = FIOGuest = GuestFIO.Text;
                AgeGuest = GuestAge.Text;
                Guest.get_by_GuestID(FIOGuest).AgeGuest = Convert.ToInt32(AgeGuest);
                Guest.get_by_GuestID(FIOGuest).CheckInGuest = CheckInGuest = CheckIn_Guest.Text;
                Guest.get_by_GuestID(FIOGuest).CheckOutGuest = CheckOutGuest = CheckOut_Guest.Text;
                Guest.get_by_GuestID(FIOGuest).GuestRoomID = CodeRoomGuest = 0;
                Close();
            }
            else return;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {

            Close();
        }
        private void EditGuest_Load(object sender, EventArgs e)
        {
            GuestFIO.Text = FIOGuest.ToString();
            GuestAge.Text = AgeGuest.ToString();
            CheckIn_Guest.Text = CheckInGuest.ToString();
            CheckOut_Guest.Text = CheckOutGuest.ToString();
            WindowsCheckBox.Checked = WindowsInsert;
            PlacesRoomSelector.SelectedItem = PlacesInsert;
            typeRoomSelector.SelectedItem = TypeRoomInsert;
        }
    }
}
