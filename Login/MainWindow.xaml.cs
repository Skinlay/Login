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

            if (textBoxEmail.Text.Trim() == "" || passwordBox1.Text.Trim() == "")
            {
                MessageBox.Show("Empty Fields", "Error"); return;
            }
            var query = connection.Table<Acounts>().Where(x => x.Email == textBoxEmail.Text);
            if (query[0].Password == passwordBox1.Text)
            {
                GrantedAcces(); return;
            }
        }
        
//        connection.Table<Acounts>().ToList().ForEach((each) =>
//            {
//            if (each.Email == textBoxEmail.Text && each.Password == passwordBox1.Text)
//            {
//              Console.WriteLine(each.Email);
//            Console.WriteLine(each.Password);
//
//          GrantedAcces(); return;
//    }
// });






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
