using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time_Table
{
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            SqlConnection _con = new SqlConnection(@"Data Source=SNG-SRV-01;Initial Catalog=Time_Table;User ID=Admin;Password=Sng@4016/S");

            string queryStatement = "SELECT Project_Name FROM PROJECT";
            DataTable Table = new DataTable();
            using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
            {
                SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                _con.Open();
                _dap.Fill(Table);
                comboBox2.DisplayMember = "Project_Name";
                comboBox2.ValueMember = "Project_Name";
                comboBox2.DataSource = Table;
            }



            queryStatement = "SELECT Username FROM Login";
            using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
            {

                SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                _dap.Fill(Table);
                comboBox1.DisplayMember = "Username";
                comboBox1.ValueMember = "Username";
                comboBox1.DataSource = Table;
            }
            _con.Close();






        }



        



        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection _con = new SqlConnection(@"Data Source=SNG-SRV-01;Initial Catalog=Time_Table;User ID=Admin;Password=Sng@4016/S");

            string s = comboBox1.Text;
            string queryStatement = $"DELETE FROM Login WHERE Username like'%{s}%'";
            Console.WriteLine(s);
            DataTable Table = new DataTable();
            using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
            {
                SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                _con.Open();
                _dap.Fill(Table);
                comboBox1.DisplayMember = "Username";
                comboBox1.ValueMember = "Username";
                comboBox1.DataSource = Table;
            }
            queryStatement = "SELECT Username FROM Login";
            Table = new DataTable();
            using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
            {

                SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                _dap.Fill(Table);
                comboBox1.DisplayMember = "Username";
                comboBox1.ValueMember = "Username";
                comboBox1.DataSource = Table;
            }
            MessageBox.Show("successfully User Deleted", "Delete");
            _con.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection _con = new SqlConnection(@"Data Source=SNG-SRV-01;Initial Catalog=Time_Table;User ID=Admin;Password=Sng@4016/S");

            string s = comboBox2.Text;
            string queryStatement = $"DELETE FROM PROJECT WHERE Project_name like'%{s}%'";
            Console.WriteLine(s);
            DataTable Table = new DataTable();
            using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
            {
                SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                _con.Open();
                _dap.Fill(Table);
                comboBox2.DisplayMember = "Project_Name";
                comboBox2.ValueMember = "Project_Name";
                comboBox2.DataSource = Table;
            }

            queryStatement = "SELECT Project_Name FROM PROJECT";
            Table = new DataTable();
            using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
            {
                SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                _dap.Fill(Table);
                comboBox2.DisplayMember = "Project_Name";
                comboBox2.ValueMember = "Project_Name";
                comboBox2.DataSource = Table;
                _con.Close();


            }
            MessageBox.Show("successfully Project Deleted", "Delete");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string employee_name = Employee_name_text.Text;
            string employee_Password = Password_text.Text;
            string employee_username = user_name_text.Text;


            SqlConnection _con = new SqlConnection(@"Data Source=SNG-SRV-01;Initial Catalog=Time_Table;User ID=Admin;Password=Sng@4016/S");

            string s = comboBox2.Text;
            string queryStatement = $"Insert into [Login] ([Username],[Password]) VALUES('{employee_username}','{employee_Password}')";
            Console.WriteLine(s);
            DataTable Table = new DataTable();
            using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
            {
                SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                _con.Open();
                _dap.Fill(Table);
                comboBox2.DisplayMember = "Project_Name";
                comboBox2.ValueMember = "Project_Name";
                comboBox2.DataSource = Table;
                _con.Close();
            }
            MessageBox.Show("User Edited", "update");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string project_name = project_name_text.Text;
            string Project_ID = Project_ID_text.Text;
            string client_name = Client_Name_text.Text;


            SqlConnection _con = new SqlConnection(@"Data Source=SNG-SRV-01;Initial Catalog=Time_Table;User ID=Admin;Password=Sng@4016/S");

            string s = comboBox2.Text;
            string queryStatement = $"Insert into [Project] ([Project_name],[Project_id],[Client_name]) VALUES('{project_name}','{Project_ID}','{client_name}')";
            Console.WriteLine(s);
            DataTable Table = new DataTable();
            using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
            {
                SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                _con.Open();
                _dap.Fill(Table);
                comboBox2.DisplayMember = "Project_Name";
                comboBox2.ValueMember = "Project_Name";
                comboBox2.DataSource = Table;
                _con.Close();
            }
            MessageBox.Show("Project Edited", "update");
        }
    }
    
}
