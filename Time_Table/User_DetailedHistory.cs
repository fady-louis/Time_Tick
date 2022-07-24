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
    public partial class User_DetailedHistory : Form
    {
        public User_DetailedHistory()
        {
            InitializeComponent();
        }

        private void User_DetailedHistory_Load(object sender, EventArgs e)
        {
            /*TODO: This line of code loads data into the 'database1DataSet1.Time' table. You can move, or remove it, as needed.
            this.timeTableAdapter1.Fill(this.database1DataSet1.Time_table);
            // TODO: This line of code loads data into the 'database1DataSet.Time' table. You can move, or remove it, as needed.
            this.timeTableAdapter.Fill(this.database1DataSet.Time_table);*/

            using (SqlConnection conn = new SqlConnection(@"Data Source=SNG-SRV-01;Initial Catalog=Time_Table;User ID=Admin;Password=Sng@4016/S"))
            {
                string un = Login.username;
                string query = $"SELECT Project,Minutes FROM Time WHERE employee LIKE '%{un}%'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dta = new DataTable();
                sda.Fill(dta);
                dataGridView1.DataSource = dta;
            }



        }

 
        /*private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.timeTableAdapter1.FillBy(this.database1DataSet1.Time);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             User_Form form = new User_Form();
            this.Close();
            form.Show();
        }
    }
}
