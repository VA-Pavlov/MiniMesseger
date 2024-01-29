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
using System.Windows.Shapes;

namespace MiniMesseger
{
    /// <summary>
    /// Interaction logic for Correspondence.xaml
    /// </summary>
    public partial class Correspondence : Window
    {
        SqlCommand sqlCommand;
        User user;
        public Correspondence(User user)
        {
            InitializeComponent();
            this.user = user;
            UserNameBlock.Text = user.last_name + " " + user.first_name;
            UpdateCorrespondence();
        }
        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateCorrespondence();
        }

        private void UpdateCorrespondence()
        {
            MessagList.Children.Clear();
            string query = "SELECT USERS.FIRST_NAME, INPUT_USER_ID, MESSEG_TEXT FROM MESSAG JOIN USERS ON USERS.ID = MESSAG.OUT_USER_ID ORDER BY DATATIME;";
            sqlCommand = new SqlCommand(query,MainWindow.conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = reader[0] + "\t\n" + reader[2];
                if ((int)reader[1] != user.id) textBlock.HorizontalAlignment = HorizontalAlignment.Right;
                textBlock.FontSize = 25;
                MessagList.Children.Add(textBlock);
            }
            reader.Close();
        }

        private void Send_Message_Click(object sender, RoutedEventArgs e)
        {

            string query = $"INSERT INTO MESSAG VALUES ('{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',{(user.id == 1 ? 2:1)}, {user.id}, '{TextMessageBox.Text}')";
            sqlCommand = new SqlCommand(query, MainWindow.conn);
            sqlCommand.ExecuteNonQuery();
            UpdateCorrespondence();
        }
    }
}
