
using System.Data;
using System.Data.Entity;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Amen_WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoToHome(object sender, RoutedEventArgs e)
        {

            
            //public void connection() {

              
                MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=agendamanagment");
            MySqlDataAdapter sda = new MySqlDataAdapter($"SELECT * FROM account where UserName='{userNameBox.Text}'",conn);        
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                //MessageBox.Show($"{ userNameBox.Text} {passwordBox.Password}");

                //MessageBox.Show("success");

                    HomePage home = new HomePage();
                    this.workingspace.Children.Clear();
                    this.workingspace.Children.Add(home);





                }
                else
                {
                    MessageBox.Show("Invalid password please correct it");

                }
            }
            



        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

