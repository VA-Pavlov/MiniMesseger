using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniMesseger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SqlConnection conn;
        public MainWindow()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = MYMESSEGER; Integrated Security=SSPI;");
            conn.Open();
            LogInButton.IsEnabled = true;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM USERS WHERE USER_LIGIN = '{LoginBox.Text}' and USER_PASSWORD = '{PasswordBox.Password}';",conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                User user = new User((int)reader[0], reader[1].ToString(), reader[2].ToString());
                Correspondence secondWindow = new Correspondence(user);
                secondWindow.Show();
                this.Close();
            }
            else
            {
                ExeptionBlock.Text = "Неверный логин или пароль";
            }
        }
    }
}
