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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Text = "Admin";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        public static string username = "";
        private void button2_Click(object sender, EventArgs e)
        {
            username = txt_username.Text;
            Console.WriteLine(username);
            Console.WriteLine(txt_password.Text);
            if (isValid())
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=SNG-SRV-01;Initial Catalog=Time_Table;User ID=Admin;Password=Sng@4016/S"))
                {
                    string query = "SELECT * FROM Login WHERE Username='" + txt_username.Text.Trim() + "' AND Password ='" + txt_password.Text.Trim() + "' AND Admin = 1";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dta = new DataTable();
                    sda.Fill(dta);
                    if (dta.Rows.Count == 0)
                        Console.WriteLine("WWW");
                    if (dta.Rows.Count == 1)
                    {
                        Console.WriteLine("Log in admin successed");
                        Form1 form1 = new Form1();
                        this.Hide();
                        form1.Show();

                    }

                    string query_admin = "SELECT * FROM Login WHERE Username='" + txt_username.Text.Trim() + "' AND Password ='" + txt_password.Text.Trim() + "' AND Admin <> 1";
                    SqlDataAdapter sda_1 = new SqlDataAdapter(query_admin, conn);
                    DataTable dta_1 = new DataTable();
                    sda_1.Fill(dta_1);

                    if (dta_1.Rows.Count == 1)
                    {
                        Console.WriteLine("Log in user successed");
                        User_Form form_1 = new User_Form();
                        this.Hide();
                        form_1.Show();

                    }



                }
            }
            }
        private bool isValid()
        {
            if (txt_username.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Enter User Name First", "Error");
                return false;
            }
            else if (txt_password.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Enter Password First", "Error");
                return false;
            }
            return true;
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
