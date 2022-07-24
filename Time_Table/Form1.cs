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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Admin";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Fill project comboBox
            SqlConnection _con = new SqlConnection(@"Data Source=SNG-SRV-01;Initial Catalog=Time_Table;User ID=Admin;Password=Sng@4016/S");
            DataTable Table = new DataTable();

            using (SqlConnection conn = new SqlConnection(@"Data Source=SNG-SRV-01;Initial Catalog=Time_Table;User ID=Admin;Password=Sng@4016/S"))
            {
                string s = comboBox2.Text;
                int month = int.Parse(s);
                string un = Login.username;
                string query = $"select employee,sum(Minutes) from Time WHERE DATEPART(mm,Date)={month} group by employee";
                Console.WriteLine(month);
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dta = new DataTable();
                sda.Fill(dta);
                dataGridView1.DataSource = dta;
            }
            Console.WriteLine(Table.Rows.Count);
            //comboBox_project.DisplayMember = "Text";
            //comboBox_project.ValueMember = "Value";
            /*
            foreach (DataRow dataRow in Table.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item);
                    comboBox_project.Items.Add(new { Text = item, Value = item });
                }
            }*/


            //employee ComboBox
            String queryStatement = "SELECT DISTINCT employee FROM Time";
            Table = new DataTable();
            using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
            {
                SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                _con.Open();
                _dap.Fill(Table);
                _con.Close();




            }
        }


        private void Back_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }



        

        

        private void button2_Click(object sender, EventArgs e)
        {
            Edit edit = new Edit();
            this.Close();
            edit.Show();

        }

        private void Back_Click_1(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Edit edit = new Edit();
            this.Close();
            edit.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=SNG-SRV-01;Initial Catalog=Time_Table;User ID=Admin;Password=Sng@4016/S"))
            {
                string s = comboBox2.Text;
                int month = int.Parse(s);
                string un = Login.username;
                string query = $"select employee,Project,Date,Minutes from Time WHERE DATEPART(mm,Date)={month} ";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dta = new DataTable();
                sda.Fill(dta);
                dataGridView1.DataSource = dta;
            }
            Console.WriteLine("Month CHN");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
