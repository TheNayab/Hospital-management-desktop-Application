using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ubiety.Dns.Core.Records;

namespace Project
{
    public partial class Alert_form : Form
    {
        public static Alert_form alertinstance;
       
        public string LabelText
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
        public Alert_form()
        {
            InitializeComponent();
            alertinstance = this;
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Alert_form_Load(object sender, EventArgs e)
        {
            this.Top = 270;
            this.Left = Screen.PrimaryScreen.Bounds.Width - Width - 590;
        }

    }
}
