using MySql.Data.MySqlClient;
using System;
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
    public partial class Form1 : Form     
    {
        string user = "";
        string pass = "";
        bool checkedd=true;
       
        public Form1()
        {
            InitializeComponent();             
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
          /*  if(WindowState== FormWindowState.Normal)
            {
                this.WindowState= FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
            */
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(DatabaseConnection.conString);
                conn.Open();

                string Query = "Select * from credientials where username='" + boxusername.Text + "'AND password='" + boxpassword.Text + "'";

                MySqlCommand cmd = new MySqlCommand(Query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    
                    user = boxusername.Text;
                    pass = boxpassword.Text;
                    AdminForm dc =new AdminForm();
                    dc.Show();
                    this.Hide();
                }
                else if(!reader.Read())
                {
                    user = boxusername.Text;
                    pass = boxpassword.Text;
                    checkedd = false;
                }
                if(user=="" && pass == "")
                {
                    Alert_form frm=new Alert_form();
                    frm.LabelText = "Please Enter Username and Password";
                    frm.Show();
                }
                if (user != "" && pass == "")
                {
                    Alert_form frm = new Alert_form();
                    frm.LabelText = "Please Enter Password";
                    frm.Show();
                }
                if (user == "" && pass != "")
                {
                    Alert_form frm = new Alert_form();
                    frm.LabelText = "Please Enter Username ";
                    frm.Show();
                }
                if (checkedd == false && user !="" &&  pass != "")
                {
                    Alert_form form = new Alert_form();
                    form.Show();
                }
               

                conn.Close();
            }
            catch
            {
                
                MessageBox.Show("error");
            }

            
           
        }

        private void passwordviewer_Click(object sender, EventArgs e)
        {
            if (boxpassword.PasswordChar == '*')
            {
                boxpassword.PasswordChar = default;

            }
            else
            {
                boxpassword.PasswordChar= '*';
            }

        }

        private void picview_Click(object sender, EventArgs e)
        {
            
                boxpassword.PasswordChar = '*';
                pichide.Visible = true;
                picview.Visible = false;
           
        }

        private void pichide_Click(object sender, EventArgs e)
        {
            boxpassword.PasswordChar = default;
            picview.Visible= true;
            pichide.Visible = false;    
        }

        private void boxusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
