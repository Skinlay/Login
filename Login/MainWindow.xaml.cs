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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SQLite;
using Login.Classes;

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            connection.CreateTable<Acounts>();
        }


        SQLiteConnection connection = new SQLiteConnection(App.strDatabasePath);


        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // shows error massege when a field is not fild in
            if (textBoxEmail.Text.Trim() == ""|| passwordBox1.Text.Trim() == "")
            {
                MessageBox.Show("Empty Fields", "Error");
            }
            else
            {
                //MessageBox.Show("Correct");
                connection.Table<Acounts>().ToList().ForEach((each) =>
                {

                    // check if the cridentials are alright
                    if (each.Email == textBoxEmail.Text || each.Password == passwordBox1.Text)
                    {
                        GrantedAcces(); return;
                    }
                    else
                    {
                        MessageBox.Show("Empty Fields", "Error"); //displayed message if login has faied
                    }
                });

            }
        }




        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
            
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            Close();
        }

        public void GrantedAcces()
        {
            MenuScreen menuScreen = new MenuScreen();
            menuScreen.ShowDialog();
        }
    }
}
