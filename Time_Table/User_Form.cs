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
    public partial class User_Form : Form
    {
        public User_Form()
        {
            InitializeComponent();
            label1.Text = "Hello " + Login.username + " ;)";
        }

        private void User_Form_Load(object sender, EventArgs e)
        {
            SqlConnection _con = new SqlConnection(@"Data Source=SNG-SRV-01;Initial Catalog=Time_Table;User ID=Admin;Password=Sng@4016/S");

            string queryStatement = "SELECT Project_Name FROM PROJECT";
            DataTable Table = new DataTable();
            using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
            {
                SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                _con.Open();
                _dap.Fill(Table);


            }

            _con.Close();
            Console.WriteLine(Table.Rows.Count);
            Project_box.DisplayMember = "Text";
            Project_box.ValueMember = "Value";
            foreach (DataRow dataRow in Table.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item);


                    Project_box.Items.Add(new { Text = item, Value = item });



                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox2.Text = textBox2.Text.Remove(textBox1.Text.Length - 1);
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            //send data to SQL
            SqlConnection conn = new SqlConnection(@"Data Source=SNG-SRV-01;Initial Catalog=Time_Table;User ID=Admin;Password=Sng@4016/S");
            conn.Open();
            string emp = Login.username;
            int startm = 8;
            int Hours = 00;
            int Mins = 01;
            int Times = Mins + 60 * Hours;
            try
            {
                startm = Int32.Parse(starts_txt.Text);
                Hours = Int32.Parse(textBox1.Text);
                Mins = Int32.Parse(textBox2.Text);
                Times = Mins + 60 * Hours;
                Console.WriteLine(Times);

            }
            catch
            {
                MessageBox.Show("Enter Details", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            SqlCommand cmd = new SqlCommand("INSERT INTO Time(employee,Project,Date,Minutes,[Starting Time]) values ('" + emp + "','" + Project_box.Text + "','" + date_txt.Value.Date + "','" + Times + "','" + startm + "')", conn);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                label7.Text = "Thanks your Data Submitted Successfuly";
            }
            else
            {
                label7.Text = "Error!!!";

            }
            conn.Close();
            //Fdy kol 2l textboxes


            label7.Text = "Thanks your Data Submitted Succesfully";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_DetailedHistory form = new User_DetailedHistory();
            this.Hide();
            form.Show();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }
    }
}
