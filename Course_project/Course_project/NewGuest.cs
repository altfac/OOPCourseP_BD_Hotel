using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Course_project
{
    public partial class NewGuest : Form
    {
        public static int CodeRoomGuest = 0;
        public static string FIOGuest = "";
        public static string AgeGuest = "";
        public static string CheckInGuest = "";
        public static string CheckOutGuest = "";
        public static int IDGuest = 0;

        public NewGuest()
        {
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
            foreach (Guest guest in Guest.mass_of_Guests)
                if (GuestFIO.Text == guest.FIOGuest)
                {
                    MessageBox.Show("Уже есть такой гость", "Заселение гостя", 0, MessageBoxIcon.Information);
                    return;
                }
            if (!regGuestFIO.IsMatch(GuestFIO.Text))
            {
                FIOGuestLabel.Text = "Примеры ввода: Антонов Андрей Владимирович, Антонов А В, Антонов А.В.";
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
                    if (room.CountGuestInRoom < room.NumPlacesRoom && room.TypeRoom == typeRoomSelector.Text && room.NumPlacesRoom == Convert.ToInt32(PlacesRoomSelector.SelectedItem) && room.WindowsRoom == WindowsCheckBox.Checked)
                    {
                        room.CountGuestInRoom++;
                        IDGuest = Guest.mass_of_Guests.Count;
                        new Guest(Guest.mass_of_Guests.Count, GuestFIO.Text, Convert.ToInt32(GuestAge.Text), CheckIn_Guest.Text, CheckOut_Guest.Text, room.GuestRoomID);
                        FIOGuest = GuestFIO.Text;
                        AgeGuest = GuestAge.Text;
                        CheckInGuest = CheckIn_Guest.Text;
                        CheckOutGuest = CheckOut_Guest.Text;
                        CodeRoomGuest = room.GuestRoomID;
                        checker = false;
                        edited = true;
                        Close();
                        break;
                    }
                }
                if (!edited) MessageBox.Show("Не найдено номера по заданным критериям", "Заселение гостя", 0, MessageBoxIcon.Information);

            }
            else if (typeRoomSelector.SelectedIndex == -1 && PlacesRoomSelector.SelectedIndex == -1 && WindowsCheckBox.Checked)
                MessageBox.Show($"Не полностью введены критерии заселения", "Редактирование гостя",
                    0, MessageBoxIcon.Information);
            if (checker)
            {
                FIOGuest = GuestFIO.Text;
                AgeGuest = GuestAge.Text;
                CheckInGuest = CheckIn_Guest.Text;
                CheckOutGuest = CheckOut_Guest.Text;
                CodeRoomGuest = 0;
                IDGuest = Guest.mass_of_Guests.Count;
                new Guest(Guest.mass_of_Guests.Count, FIOGuest, Convert.ToInt32(AgeGuest), CheckInGuest, CheckOutGuest, CodeRoomGuest);
                Close();
            }
            else return;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            FIOGuest = "";
            AgeGuest = "";
            CheckInGuest = "";
            CheckOutGuest = "";
            CodeRoomGuest = 0;
            Close();
        }
    }
}
