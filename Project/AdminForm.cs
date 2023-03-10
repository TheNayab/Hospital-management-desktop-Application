using LiveCharts;
using LiveCharts.Wpf;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace Project
{
    public partial class AdminForm : Form
    {
        
        public AdminForm()
        {
            InitializeComponent();

            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new LineSeries
                {
                    Values=new ChartValues<LiveCharts.Defaults.ObservablePoint>
                    {
                        new LiveCharts.Defaults.ObservablePoint(1,10),
                        new LiveCharts.Defaults.ObservablePoint(2,240),
                        new LiveCharts.Defaults.ObservablePoint(3,100),
                        new LiveCharts.Defaults.ObservablePoint(4,110),
                        new LiveCharts.Defaults.ObservablePoint(5,120),
                        new LiveCharts.Defaults.ObservablePoint(6,15),
                        new LiveCharts.Defaults.ObservablePoint(7,140),
                        new LiveCharts.Defaults.ObservablePoint(8,150),
                        new LiveCharts.Defaults.ObservablePoint(9,188),
                        new LiveCharts.Defaults.ObservablePoint(10,170),
                        new LiveCharts.Defaults.ObservablePoint(11,180),
                        new LiveCharts.Defaults.ObservablePoint(12,200),
                    },
                    PointGeometrySize=15
                }
            };
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Month",

            });
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Revenue",
            });
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DoctorLable_Click(object sender, EventArgs e)
        {
            DoctorCrud dcc= new DoctorCrud();
            dcc.Show();
            this.Hide();
        }

        private void guna2CustomGradientPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(DatabaseConnection.conString);

            conn.Open();
            string query = "Select count(*) from doctor";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            var count1 = cmd.ExecuteScalar();
            DoctorLabel.Text = count1.ToString();
        }

        private void DoctorLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
