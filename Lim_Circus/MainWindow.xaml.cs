using Lim_Circus.Data;
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
using Lim_Circus.ADO;
using Lim_Circus.Data;
using Lim_Circus.Windows;

namespace Lim_Circus
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_BTN_Click(object sender, RoutedEventArgs e)
        {
            Users currentUser = DBConnection.connection.Users.Where(x => x.Username == Login_TB.Text && x.Password == Password_PB.Password).FirstOrDefault();
            if(currentUser != null)
            {
                MessageBox.Show("Авторизация прошла успешно");
                switch (currentUser.Role_ID)
                {
                    case 1:
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                        break;
                    case 2:
                        ArtistWindow artisWindow = new ArtistWindow();
                        artisWindow.Show();
                        this.Close();
                        break;
                    case 3:
                        TamerWindow tamerWindow = new TamerWindow();
                        tamerWindow.Show();
                        this.Close();
                        break;
                    case 4:
                        PersonelWindow personelWindow = new PersonelWindow();
                        personelWindow.Show();
                        this.Close();
                        break;
                    default: ;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Логин или пароль введены неверно");
            }
        }
    }
}
