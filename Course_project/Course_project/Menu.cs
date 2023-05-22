using System;
using System.Windows.Forms;

namespace Course_project
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn_films_Click(object sender, EventArgs e)
        {
            Rooms room = new Rooms();
            room.ShowDialog();
        }

        private void btn_partcp_Click(object sender, EventArgs e)
        {
            Guests Client = new Guests();
            Client.ShowDialog();
        }
    }
}
