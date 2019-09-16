using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amen_WpfApp4
{
    class DATABASE
    {
        MySqlConnection conn;
        public void connection() { }
        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=agendamanagment");
        // MessageBox.Show($"{ userNameBox.Text} {passwordBox.Password}");
        MySqlDataAdapter sda = new MySqlDataAdapter($"SELECT * FROM Account WHERE UserName ='{userNameBox.Text}' AND Password='{passwordBox.Password}'", conn);

        //MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM Account WHERE UserName ='" + userNameBox.Text + "' AND Password='" + passwordBox.Password + "'", conn);
        // SqlDataAdapter sda = new SqlDataAdapter("Select userName,password from login where userName =' " + userNameBox.Text + "' and password='" + passwordBox.Password + "'", conn);

        //SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\e\Documents\LoginDetails.mdf; Integrated Security = True; Connect Timeout = 30");
        //SqlDataAdapter sda = new SqlDataAdapter("Select * from login where userName =' " + userNameBox.Text + "' and password='" + passwordBox.Password + "'", conn);
        // SqlDataAdapter sda = new SqlDataAdapter("Select userName,password from login where userName =' " + userNameBox.Text + "' and password='" + passwordBox.Password + "'", conn);
        
    }
}
