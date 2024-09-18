using AnimateDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fitness_home.Views.Messages
{
    public partial class DatabaseError : Form
    {
        public DatabaseError()
        {
            InitializeComponent();
        }

        private void button_try_again_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DatabaseError_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 200, WinAPI.BLEND);
        }
    }
}
