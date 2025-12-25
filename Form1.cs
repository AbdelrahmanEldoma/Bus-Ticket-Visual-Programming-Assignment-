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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bus_Ticket
{
    public partial class Form1 : Form
    {
        public int No = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F0UNJKU;Initial Catalog=BusDB;TrustServerCertificate=True;Integrated Security=True;");
                con.Open();
                SqlCommand cnn = new SqlCommand("insert into Tickets values(@no,@date,@from,@destination)", con);
                cnn.Parameters.AddWithValue("@No", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                cnn.Parameters.AddWithValue("@From", textBox2.Text);
                cnn.Parameters.AddWithValue("@Destination", textBox3.Text);
                cnn.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Saved Successfully!");
                No++;

            }
            catch
            {
                MessageBox.Show("Error ticket was not saved.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F0UNJKU;Initial Catalog=BusDB;TrustServerCertificate=True;Integrated Security=True;");
                con.Open();
                SqlCommand cnn = new SqlCommand("select * from Tickets", con);
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }

            catch
            {
                MessageBox.Show("Error ticket was not added.");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F0UNJKU;Initial Catalog=BusDB;TrustServerCertificate=True;Integrated Security=True;");
                con.Open();
                SqlCommand cnn = new SqlCommand("update Tickets set date=@date,[from]=@from,destination=@destination where no=@no", con);
                cnn.Parameters.AddWithValue("@No", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                cnn.Parameters.AddWithValue("@From", textBox2.Text);
                cnn.Parameters.AddWithValue("@Destination", textBox3.Text);
                cnn.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully!");
            }

            catch
            {
                MessageBox.Show("Error ticket was not Updated.");
            }
        }
    private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F0UNJKU;Initial Catalog=BusDB;TrustServerCertificate=True;Integrated Security=True;");
                con.Open();
                SqlCommand cnn = new SqlCommand("delete Tickets where no=@no", con);
                cnn.Parameters.AddWithValue("@No", int.Parse(textBox1.Text));

                cnn.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
            }
            catch
            {
                MessageBox.Show("Error ticket was not Deleted.");
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F0UNJKU;Initial Catalog=BusDB;TrustServerCertificate=True;Integrated Security=True;");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from Tickets", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label7.Text = "Destination: " + textBox2.Text;
            this.label8.Text = "From: " + textBox3.Text;
            this.label9.Text = "Date: " + dateTimePicker1.Value;
            this.label10.Text = "No:" + textBox1.Text;

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
