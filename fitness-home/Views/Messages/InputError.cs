﻿using System;
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
    public partial class InputError : Form
    {
        public InputError()
        {
            InitializeComponent();
        }

        private void button_try_again_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the message once the "Try Again" button is clicked
        }
    }
}
