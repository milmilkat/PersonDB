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

namespace PersonDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ReadBtn_Click(object sender, EventArgs e)
        {
            string conString = @"Data Source=DHMATUT-09\SQLEXPRESS;Initial Catalog=Contact;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(conString);

            con.Open();

            DataTable person = new DataTable();

            person.Clear();

            //Our Visual Data Base
            person.Columns.Add("id");
            person.Columns.Add("first name");
            person.Columns.Add("last name");
            //end of visual


            string query = @"Select * from Person order by ID";

            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader();


            while(reader.Read())
            {
                person.Rows.Add(
                    reader["ID"],
                    reader["FirstName"],
                    reader["SurName"]
                    );
            }

            reader.Close();

            con.Close();

            dataGridView1.DataSource = person;


        }
    }
}
