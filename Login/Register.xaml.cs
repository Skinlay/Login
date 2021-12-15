using System;
using System.Collections.Generic;
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
using Login.Classes;
using SQLite;

namespace Login
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //Connection to class
            Acounts acounts = new Acounts()
            {
                Firstname = textBoxFirstName.Text,
                LastName = textBoxLastName.Text,
                Email = textBoxEmail.Text,
                Password = passwordBox1.Password,
                ConfirmPwd = passwordBoxConfirm.Password,
                Address = textBoxAddress.Text

            };

            //Connection to database
            SQLiteConnection connection = new SQLiteConnection(App.strDatabasePath);
            {
                connection.CreateTable<Acounts>();
                connection.Insert(acounts);
            }

            //Close current window
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
