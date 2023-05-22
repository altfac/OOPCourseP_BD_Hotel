using System;
using System.Windows.Forms;

namespace Course_project
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }
        private void FormStart_Load(object sender, EventArgs e)
        {
        Timer timer = new Timer();
            timer.Tick += delegate 
            {
                this.Close();
            };
            timer.Interval = 3000;
            timer.Start();
        }
    }
}
