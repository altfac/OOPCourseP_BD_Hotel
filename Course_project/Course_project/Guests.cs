using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_project
{
    public partial class Guests : Form
    {
        const string ROOM_JSON = "Rooms.json";
        const string GUESTS_JSON = "Guestj.json";
        int numbers = 0;
        public Guests()
        {
            Task.Run(() => File.Open(GUESTS_JSON, FileMode.OpenOrCreate).Close());
            Task.Run(() => File.Open(ROOM_JSON, FileMode.OpenOrCreate).Close());
            InitializeComponent();
        }

        async void Guests_Load(object sender, EventArgs e)
        {
            if (File.Exists(GUESTS_JSON))
            {
                var guests = await ReadFromFile<Guest>(GUESTS_JSON);

                if (guests != null)
                    foreach (var guest in guests)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[numbers].Cells[0].Value = guest.FIOGuest;
                        dataGridView1.Rows[numbers].Cells[1].Value = guest.AgeGuest;
                        dataGridView1.Rows[numbers].Cells[2].Value = guest.CheckInGuest;
                        dataGridView1.Rows[numbers].Cells[3].Value = guest.CheckOutGuest;
                        dataGridView1.Rows[numbers].Cells[4].Value = guest.GuestRoomID;
                        numbers++;
                    }
            }
        }

        async Task WriteToFile<T>(List<T> data, string FILE_NAME)
        {
            using (var streamWriter = new StreamWriter(FILE_NAME, false))
            {
                await streamWriter.WriteAsync(await Task.Run(() => JsonConvert.SerializeObject(data)));
            }
        }
        async Task<List<T>> ReadFromFile<T>(string FILE_NAME)
        {
            using (var streamReader = new StreamReader(FILE_NAME))
            {
                return await Task.Run(async () => JsonConvert.DeserializeObject<List<T>>(await streamReader.ReadToEndAsync()) ?? new List<T>());
            }
        }

        private void btn_Back_Click_1(object sender, EventArgs e)
        {
            Guest.mass_of_Guests.Clear();
            Room.mass_of_Rooms.Clear();
            Close();
        }

        async void btn_Remove_Click_1(object sender, EventArgs e)
        {
            Room.mass_of_Rooms.Clear();
            var rooms = await ReadFromFile<Room>(ROOM_JSON);

            var Items = dataGridView1.SelectedRows;
            int selectCount = Items.Count;

            if (selectCount > 0)
            {
                Guest.mass_of_Guests.Clear();
                var guests = await ReadFromFile<Guest>(GUESTS_JSON);

                foreach (var item in Items)
                {
                    var it = (DataGridViewRow)item;
                    string FIOGuest = it.Cells[0].Value.ToString();
                    int AgeGuest = Convert.ToInt32(it.Cells[1].Value.ToString());
                    string CheckInGuest = it.Cells[2].Value.ToString();
                    string CheckOutGuest = it.Cells[3].Value.ToString();
                    int CodeRoomGuest = Convert.ToInt32(it.Cells[4].Value.ToString());

                    foreach (var pt in guests)
                    {
                        if (FIOGuest == pt.FIOGuest && AgeGuest == pt.AgeGuest && CheckInGuest == pt.CheckInGuest &&
                            CheckOutGuest == pt.CheckOutGuest && CodeRoomGuest == pt.GuestRoomID)
                        {
                            if (pt.GuestRoomID != 0 && Room.get_by_CodeRoom(pt.GuestRoomID) != null)
                            {
                                Room.get_by_CodeRoom(pt.GuestRoomID).CountGuestInRoom -= 1;
                                await WriteToFile(rooms, ROOM_JSON);
                            }

                            guests.Remove(pt);
                            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                            numbers--;
                            MessageBox.Show($"Гость {pt.FIOGuest} удалён", "Удаление гостя",
                                0, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                await WriteToFile(guests, GUESTS_JSON);
            }
            else
            {
                MessageBox.Show("Не выбраны гости для удаления", "Удаление", 0, MessageBoxIcon.Information);
                return;
            }
        }

        async void button_EditGuest_Click(object sender, EventArgs e)
        {
            var Items = dataGridView1.SelectedRows;
            int selectCount = Items.Count;

            if (selectCount > 0)
            {
                Guest.mass_of_Guests.Clear();
                var guests = await ReadFromFile<Guest>(GUESTS_JSON);
                Room.mass_of_Rooms.Clear();
                var rooms = await ReadFromFile<Room>(ROOM_JSON);
                foreach (var item in Items)
                {
                    var it = (DataGridViewRow)item;
                    string FIOGuest = it.Cells[0].Value.ToString();
                    int AgeGuest = Convert.ToInt32(it.Cells[1].Value.ToString());
                    string CheckInGuest = it.Cells[2].Value.ToString();
                    string CheckOutGuest = it.Cells[3].Value.ToString();
                    int CodeRoomGuest = Convert.ToInt32(it.Cells[4].Value.ToString());
                    for (int i = 0; i < guests.Count; i++)
                    {
                        var pt = guests[i];
                        if (FIOGuest == pt.FIOGuest && AgeGuest == pt.AgeGuest && CheckInGuest == pt.CheckInGuest &&
                            CheckOutGuest == pt.CheckOutGuest && CodeRoomGuest == pt.GuestRoomID)
                        {
                            EditGuest editGuest = new EditGuest(pt);
                            editGuest.ShowDialog();
                            await WriteToFile(rooms, ROOM_JSON);
                            await WriteToFile(guests, GUESTS_JSON);
                            it.Cells[0].Value = EditGuest.FIOGuest;
                            it.Cells[1].Value = EditGuest.AgeGuest;
                            it.Cells[2].Value = EditGuest.CheckInGuest;
                            it.Cells[3].Value = EditGuest.CheckOutGuest;
                            it.Cells[4].Value = EditGuest.CodeRoomGuest;

                            MessageBox.Show($"Гость {pt.FIOGuest} отредактирован", "Редактирование гостя",
                                0, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбраны гости для редактирования", "Редактирование гостя", 0, MessageBoxIcon.Information);
                return;
            }
        }

        async void btn_Add_Click_1(object sender, EventArgs e)
        {
            Room.mass_of_Rooms.Clear();
            var rooms = await ReadFromFile<Room>(ROOM_JSON);
            Guest.mass_of_Guests.Clear();
            var guests = await ReadFromFile<Guest>(GUESTS_JSON);
            NewGuest newGuest = new NewGuest();
            newGuest.ShowDialog();
            await WriteToFile(rooms, ROOM_JSON);
            string FIOGuest = NewGuest.FIOGuest;
            string AgeGuest = NewGuest.AgeGuest;
            string CheckInGuest = NewGuest.CheckInGuest;
            string CheckOutGuest = NewGuest.CheckOutGuest;
            int CodeRoomGuest = NewGuest.CodeRoomGuest;
            int IDGuest = NewGuest.IDGuest;


            if (!string.IsNullOrEmpty(FIOGuest) && !string.IsNullOrEmpty(AgeGuest) && !string.IsNullOrEmpty(CheckInGuest) &&
                !string.IsNullOrEmpty(CheckOutGuest) && (Guest.mass_of_Guests.Count > 0))
            {
                guests.Add(Guest.get_by_GuestID(FIOGuest));
                await WriteToFile(guests, GUESTS_JSON);

                dataGridView1.Rows.Add();
                dataGridView1.Rows[numbers].Cells[0].Value = FIOGuest;
                dataGridView1.Rows[numbers].Cells[1].Value = AgeGuest;
                dataGridView1.Rows[numbers].Cells[2].Value = CheckInGuest;
                dataGridView1.Rows[numbers].Cells[3].Value = CheckOutGuest;
                dataGridView1.Rows[numbers].Cells[4].Value = CodeRoomGuest;
                numbers++;
            }
        }
    }
}
