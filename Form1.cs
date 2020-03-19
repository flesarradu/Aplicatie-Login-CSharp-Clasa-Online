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

namespace FirstLoginFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = "", password = "";
            user = userTextBox.Text;
            password = passwordTextBox.Text;


            string connectionString = @"Data Source=FLESAR\FLESARSQLSERVER;Initial Catalog=LoginDatabase;Integrated Security=True;Pooling=False";
            string query = "SELECT * FROM dbo.Users WHERE username = '"+user+"'";
            bool ok = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string u = reader["username"].ToString();
                     
                        string p = reader["password"].ToString();
                        
                        if(u.Trim()==user)
                        {
                            if (p.Trim(' ') == password)
                            {
                                ok = true;
                            }
                        }
                        
                    }
                }
            }
            if (ok)
            {
                MessageBox.Show("Te-ai logat cu succes");
            }
            else
            { MessageBox.Show("nu-i ok"); }
        }
    }
}
