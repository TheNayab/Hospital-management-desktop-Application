﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
            
        }  

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Increment(2);
            if(progressBar1.Value == 100) {
                timer1.Enabled = false;
                Form1 fm=new Form1();
                fm.Show();
                this.Hide();
            }
        }

          }
}
