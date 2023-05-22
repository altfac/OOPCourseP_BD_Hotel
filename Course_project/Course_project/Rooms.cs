using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using File = System.IO.File;

namespace Course_project
{
    public partial class Rooms : Form
    {
        const string ROOM_JSON = "Rooms.json";
        const string GUESTS_JSON = "Guestj.json";
        int indexRoom = 0;

        public Rooms()
        {
            Task.Run(() => File.Open(ROOM_JSON, FileMode.OpenOrCreate).Close());
            Task.Run(() => File.Open(GUESTS_JSON, FileMode.OpenOrCreate).Close());
            InitializeComponent();
        }

        async void Rooms_Load(object sender, EventArgs e)
        {
            if (File.Exists(ROOM_JSON))
            {
                var roomFile = await ReadFromFile<Room>(ROOM_JSON);

                if (roomFile.Count != 0)
                {
                    foreach (var room in roomFile)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[indexRoom].Cells[0].Value = room.GuestRoomID;
                        dataGridView1.Rows[indexRoom].Cells[1].Value = room.TypeRoom;
                        dataGridView1.Rows[indexRoom].Cells[2].Value = room.FloorRoom;
                        dataGridView1.Rows[indexRoom].Cells[3].Value = room.NumPlacesRoom;
                        dataGridView1.Rows[indexRoom].Cells[4].Value = room.CostRoom;
                        dataGridView1.Rows[indexRoom].Cells[5].Value = room.WindowsRoom;
                        dataGridView1.Rows[indexRoom].Cells[6].Value = room.CountGuestInRoom;
                        indexRoom++;
                    }
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

        bool Print(Room room)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[indexRoom].Cells[0].Value = room.GuestRoomID;
            dataGridView1.Rows[indexRoom].Cells[1].Value = room.TypeRoom;
            dataGridView1.Rows[indexRoom].Cells[2].Value = room.FloorRoom;
            dataGridView1.Rows[indexRoom].Cells[3].Value = room.NumPlacesRoom;
            dataGridView1.Rows[indexRoom].Cells[4].Value = room.CostRoom;
            dataGridView1.Rows[indexRoom].Cells[5].Value = room.WindowsRoom;
            dataGridView1.Rows[indexRoom].Cells[6].Value = room.CountGuestInRoom;
            indexRoom++;
            return true;
        }

        private void btn_Back_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        async void btn_Add_Click_1(object sender, EventArgs e)
        {
            NewRoom NewRoomFormAdd = new NewRoom();
            NewRoomFormAdd.ShowDialog();

            int codeRoom = NewRoom.codeRoom;
            string typeRoom = NewRoom.typeRoom;
            int floorRoom = NewRoom.floorRoom;
            int placesRoom = NewRoom.placesRoom;
            double costRoom = NewRoom.costRoom;
            bool windowRoom = NewRoom.windowRoom;
            int countguestinroom = NewRoom.countguestinroom;
            if ((codeRoom > 0) && !string.IsNullOrEmpty(typeRoom) && (floorRoom > 0) && (placesRoom > 0) && (costRoom > 0))
            {
                var room = await ReadFromFile<Room>(ROOM_JSON);
                if (!room.Contains(Room.get_by_CodeRoom(codeRoom)))
                {
                    room.Add(Room.get_by_CodeRoom(codeRoom));
                    await WriteToFile(room, ROOM_JSON);

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[indexRoom].Cells[0].Value = codeRoom;
                    dataGridView1.Rows[indexRoom].Cells[1].Value = typeRoom;
                    dataGridView1.Rows[indexRoom].Cells[2].Value = floorRoom;
                    dataGridView1.Rows[indexRoom].Cells[3].Value = placesRoom;
                    dataGridView1.Rows[indexRoom].Cells[4].Value = costRoom;
                    dataGridView1.Rows[indexRoom].Cells[5].Value = windowRoom;
                    dataGridView1.Rows[indexRoom].Cells[6].Value = countguestinroom;
                    indexRoom++;
                }
                else
                {
                    MessageBox.Show($"Номер уже есть",
                        "Добавление Номер", 0, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        async void btn_filter_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is null)
            {
                MessageBox.Show("Выберите критерий", "Фильтрация", 0, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(textBox1.Text) && comboBox1.SelectedIndex != 9 && comboBox1.SelectedIndex != 10 && comboBox1.SelectedIndex != 11 && comboBox1.SelectedIndex != 12)
            {
                MessageBox.Show("Заполните поле", "Фильтрация", 0, MessageBoxIcon.Information);
                textBox1.BackColor = Color.MistyRose;
            }
            else
            {
                string filter = textBox1.Text;
                int fil;

                textBox2.Text = "";
                dataGridView1.Rows.Clear();
                indexRoom = 0;

                bool flag = false;

                var rooms = await ReadFromFile<Room>(ROOM_JSON);

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var room in rooms)
                                if (room.GuestRoomID >= fil)
                                    flag = Print(room);
                            if (flag == false)
                                MessageBox.Show($"Номера с кодами от {filter} не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 1:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var room in rooms)
                                if (room.GuestRoomID < fil)
                                    flag = Print(room);
                            if (flag == false)
                                MessageBox.Show($"Номера с кодами от {filter} не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 2:
                        foreach (var room in rooms)
                            if (room.TypeRoom == Convert.ToString(filter))
                                flag = Print(room);
                        if (flag == false)
                            MessageBox.Show($"Введёный тип номера '{filter}' не существует, проверьте корректность ввода",
                                "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 3:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var room in rooms)
                                if (room.FloorRoom >= fil)
                                    flag = Print(room);
                            if (flag == false)
                                MessageBox.Show($"Номера с этажом от {filter} не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 4:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var room in rooms)
                                if (room.FloorRoom < fil)
                                    flag = Print(room);

                            if (flag == false)
                                MessageBox.Show($"Номера с этажом до {filter} не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 5:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var room in rooms)
                                if (room.NumPlacesRoom >= fil)
                                    flag = Print(room);

                            if (flag == false)
                                MessageBox.Show($"Номера с количеством мест от {filter} не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 6:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var room in rooms)
                                if (room.NumPlacesRoom < fil)
                                    flag = Print(room);

                            if (flag == false)
                                MessageBox.Show($"Номера с количеством мест до {filter} не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 7:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var room in rooms)
                                if (room.CostRoom >= fil)
                                    flag = Print(room);

                            if (flag == false)
                                MessageBox.Show($"Номера по цене за ночь до {filter} не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 8:
                        if (int.TryParse(filter, out fil) && fil > 0)
                        {
                            foreach (var room in rooms)
                                if (room.CostRoom < fil)
                                    flag = Print(room);

                            if (flag == false)
                                MessageBox.Show($"Номера по цене за ночь от {filter} не найдены, " +
                                    $"проверьте корректность ввода",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Некорректные данные",
                                    "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 9:

                        foreach (var room in rooms)
                            if (room.WindowsRoom)
                                flag = Print(room);

                        if (flag == false)
                            MessageBox.Show($"Номера c наличием окна {filter} не найдены, " +
                                $"проверьте корректность ввода",
                                "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 10:
                        foreach (var room in rooms)
                            if (!room.WindowsRoom)
                                flag = Print(room);

                        if (flag == false)
                            MessageBox.Show($"Номера c наличием окна {filter} не найдены, " +
                                $"проверьте корректность ввода",
                                "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 11:
                        foreach (var room in rooms)
                            if (room.CountGuestInRoom > 0)
                                flag = Print(room);

                        if (flag == false)
                            MessageBox.Show($"Занятые номера {filter} не найдены, " +
                                $"проверьте корректность ввода",
                                "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                    case 12:
                        foreach (var room in rooms)
                            if (room.CountGuestInRoom == 0)
                                flag = Print(room);

                        if (flag == false)
                            MessageBox.Show($"Незанятые номера {filter} не найдены, " +
                                $"проверьте корректность ввода",
                                "Фильтрация", 0, MessageBoxIcon.Information);
                        break;
                }
            }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            dataGridView1.ClearSelection();

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Заполните поле", "Поиск", 0, MessageBoxIcon.Information);
                textBox2.BackColor = Color.MistyRose;
            }
            else
            {
                if (int.TryParse(textBox2.Text, out int fil))
                {
                    bool flag = false;
                    var Items = dataGridView1.Rows;

                    foreach (var item in Items)
                        if (Convert.ToInt32(((DataGridViewRow)item).Cells[0].Value) == fil)
                        {
                            ((DataGridViewRow)item).Selected = true;
                            flag = true;
                        }

                    if (flag == false)
                        MessageBox.Show($"Номер {fil} не найден, " +
                            $"проверьте корректность номера",
                            "Поиск", 0, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show($"Некорректные данные",
                            "Поиск", 0, MessageBoxIcon.Information);
            }
        }
        async void button_EditRoom_Click(object sender, EventArgs e)
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
                    int ID = Convert.ToInt32(((DataGridViewRow)item).Cells[0].Value);
                    var it = (DataGridViewRow)item;
                    int RoomID = Convert.ToInt32(it.Cells[0].Value.ToString());
                    string TypeRoom = it.Cells[1].Value.ToString();
                    int FloorRoom = Convert.ToInt32(it.Cells[2].Value.ToString());
                    int PlacesRoom = Convert.ToInt32(it.Cells[3].Value.ToString());
                    double CostRoom = Convert.ToDouble(it.Cells[4].Value);
                    bool WindowRoom = Convert.ToBoolean(it.Cells[5].Value.ToString());
                    int CountGuestRoom = Convert.ToInt32(it.Cells[6].Value.ToString());

                    for (int i = 0; i < rooms.Count; i++)
                    {
                        var pt = rooms[i];
                        if (ID == pt.GuestRoomID)
                        {
                            foreach (var guest in guests)
                            {
                                if (ID == guest.GuestRoomID)
                                {
                                    MessageBox.Show($"Редактирование невозможно, данный номер заселён",
                                        "Редактирование номера", 0, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        if (RoomID == pt.GuestRoomID && TypeRoom == pt.TypeRoom && FloorRoom == pt.FloorRoom &&
                        PlacesRoom == pt.NumPlacesRoom && CostRoom == pt.CostRoom && WindowRoom == pt.WindowsRoom && CountGuestRoom == pt.CountGuestInRoom)
                        {
                            EditRoom editRoom = new EditRoom(pt);
                            editRoom.ShowDialog();
                            await WriteToFile(rooms, ROOM_JSON);
                            await WriteToFile(guests, GUESTS_JSON);
                            it.Cells[0].Value = EditRoom.RoomID;
                            it.Cells[1].Value = EditRoom.TypeRoom;
                            it.Cells[2].Value = EditRoom.FloorRoom;
                            it.Cells[3].Value = EditRoom.PlacesRoom;
                            it.Cells[4].Value = EditRoom.CostRoom;
                            it.Cells[5].Value = EditRoom.WindowRoom;
                            it.Cells[6].Value = EditRoom.CountGuestRoom;

                            MessageBox.Show($"Номер {pt.GuestRoomID} отредактирован", "Редактирование номера",
                                0, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбраны номера для редактирования", "Редактирование номера", 0, MessageBoxIcon.Information);
                return;
            }
        }
        async void btn_Remove_Click_1(object sender, EventArgs e)
        {
            var Items = dataGridView1.SelectedRows;
            int selectCount = Items.Count;

            if (selectCount > 0)
            {
                var rooms = await ReadFromFile<Room>(ROOM_JSON);
                var guests = await ReadFromFile<Guest>(GUESTS_JSON);

                foreach (var item in Items)
                {
                    int ID = Convert.ToInt32(((DataGridViewRow)item).Cells[0].Value);

                    foreach (var room in rooms)
                    {
                        if (ID == room.GuestRoomID)
                        {
                            bool check = true;

                            foreach (var prt in guests)
                            {
                                if (ID == prt.GuestRoomID)
                                {
                                    MessageBox.Show($"Удаление невозможно, данный номер заселён",
                                        "Удаление номера", 0, MessageBoxIcon.Information);
                                    check = false;
                                    break;
                                }
                            }
                            if (check)
                            {
                                rooms.Remove(room);
                                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                                indexRoom--;
                                MessageBox.Show($"Номер <{room.GuestRoomID}> удалён",
                                    "Удаление номера", 0, MessageBoxIcon.Information);
                                break;
                            }
                        }
                    }
                }

                await WriteToFile(rooms, ROOM_JSON);
            }
            else
            {
                MessageBox.Show("Выберите номер для удаления", "Удаление номера", 0, MessageBoxIcon.Information);
                return;
            }
        }

        async void btn_Reset_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dataGridView1.Rows.Clear();
            comboBox1.SelectedIndex = -1;
            indexRoom = 0;

            var rooms = await ReadFromFile<Room>(ROOM_JSON);

            foreach (var room in rooms)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[indexRoom].Cells[0].Value = room.GuestRoomID;
                dataGridView1.Rows[indexRoom].Cells[1].Value = room.TypeRoom;
                dataGridView1.Rows[indexRoom].Cells[2].Value = room.FloorRoom;
                dataGridView1.Rows[indexRoom].Cells[3].Value = room.NumPlacesRoom;
                dataGridView1.Rows[indexRoom].Cells[4].Value = room.CostRoom;
                dataGridView1.Rows[indexRoom].Cells[5].Value = room.WindowsRoom;
                dataGridView1.Rows[indexRoom].Cells[6].Value = room.CountGuestInRoom;
                indexRoom++;
            }
        }
    }
}
