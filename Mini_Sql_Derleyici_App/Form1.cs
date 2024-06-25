using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mini_Sql_Derleyici_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-3JI920O\SQLEXPRESS;Initial Catalog=DbProje12;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = richTextBox1.Text;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Sorgu Girdiniz","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = richTextBox1.Text;
                conn.Open();
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                SqlDataAdapter da = new SqlDataAdapter("Select * from TBLMATEMATIK", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Sorgu Girdiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }
    }
}
