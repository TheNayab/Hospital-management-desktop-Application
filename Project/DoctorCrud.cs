using MySql.Data.MySqlClient;
using Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace Project
{
    public partial class DoctorCrud : Form
    {
        List<Doctor> doctors=new List<Doctor>();
        Doctor doc = null;
        public DoctorCrud()
        {
            InitializeComponent();
        }

      
     
        private void DoctorCrud_Load(object sender, EventArgs e)
        {
            SidePanel.Hide();
            SidePanel2.Hide();
            PreOne.Enabled = false;
            Next2.Enabled = false;

            try
            {
                MySqlConnection conn = new MySqlConnection(DatabaseConnection.conString);
                conn.Open();
                string Query = "Select * from doctor";


                MySqlCommand cmd = new MySqlCommand(Query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    doctors.Add(new Doctor(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetString("Address"), reader.GetDouble("PhoneNumber"), reader.GetInt32("Age"), reader.GetString("Qualification"), reader.GetString("Specilization"), reader.GetString("City"), reader.GetString("Username"), reader.GetString("Password")));
                }
                conn.Close();

            }
            catch
            {
                MessageBox.Show("An unexpected Error occur");
            }
            if (doctors.Count > 0)
            {
                doc = doctors[0];
            }
           
            foreach (Doctor d in doctors)
            {
                gridDataManipulation(d);

            }

        }
        void gridDataManipulation(Doctor d)
        {
            DataGridViewRow rows = new DataGridViewRow();

            DataGridViewTextBoxCell CellID = new DataGridViewTextBoxCell();
            CellID.Value = d.Id;

            DataGridViewTextBoxCell CellName = new DataGridViewTextBoxCell();
            CellName.Value = d.Name;
            DataGridViewTextBoxCell CellAdress = new DataGridViewTextBoxCell();
            CellAdress.Value = d.Address;

            DataGridViewTextBoxCell CellPhone = new DataGridViewTextBoxCell();
            CellPhone.Value = d.PhoneNumber;

            DataGridViewTextBoxCell CellAge = new DataGridViewTextBoxCell();
            CellAge.Value = d.Age;
            
            DataGridViewTextBoxCell CellSpeci = new DataGridViewTextBoxCell();
            CellSpeci.Value = d.Specilization;


            rows.Cells.Add(CellID);
            rows.Cells.Add(CellName);
            rows.Cells.Add(CellAdress);
            rows.Cells.Add(CellPhone);
            rows.Cells.Add(CellAge);
            rows.Cells.Add(CellSpeci);

            gridView.Rows.Add(rows);
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
            if(WindowState== FormWindowState.Normal)
              {
                  this.WindowState= FormWindowState.Maximized;
              }
              else
              {
                  this.WindowState = FormWindowState.Normal;
              }
              
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SidePanel.Show();
        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            SidePanel.Hide();
        }

        private void NextOne_Click(object sender, EventArgs e)
        {
            SidePanel.Hide();
            SidePanel2.Show();
   
        }

        

        private void Pre2_Click(object sender, EventArgs e)
        {
            SidePanel.Show();
            SidePanel2.Hide();
        }

        private void Hide2_Click(object sender, EventArgs e)
        {
            SidePanel2.Hide();
        }
        public void FromGUIToData()
        {
            
                doc.Id = int.Parse(BoxId.Text);
                doc.Name = BoxName.Text;
                doc.Address = BoxAddress.Text;
                doc.Age = int.Parse(BoxAge.Text);
                doc.PhoneNumber = double.Parse(BoxPhone.Text);
                doc.Qualification = BoxQualification.Text;
                doc.Specilization = BoxSpecialization.Text;
                doc.City = BoxCity.Text;
                doc.Username = BoxUsername.Text;
                doc.Password = BoxPassword.Text;
         
        }


        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(DatabaseConnection.conString);
            conn.Open();
            FromGUIToData();
            string query = "INSERT INTO DOCTOR VALUES( '"+ doc.Id + "','"+ doc.Name + "','"+ doc.Address + "','"+ doc.Age + "','"+ doc.PhoneNumber + "','"+ doc.Qualification + "','"+ doc.Specilization + "','" + doc.City + "','"+ doc.Username + "','"+ doc.Password + "')";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Inserted");
                    gridDataManipulation(doc);
                    
                }
                else
                {
                    MessageBox.Show("Data not inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            FromGUIToData();
            MessageBox.Show(doc.Name);
        }
    }
}
