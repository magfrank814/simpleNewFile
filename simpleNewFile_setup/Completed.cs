﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleNewFile_setup
{
    public partial class Completed : Form
    {
        public Completed()
        {
            InitializeComponent();
            this.FormClosed += MyForm_FormClosed;
        }
        private void MyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
