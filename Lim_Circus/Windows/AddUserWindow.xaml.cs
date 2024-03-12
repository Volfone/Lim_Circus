using Lim_Circus.ADO;
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
using System.Windows.Shapes;

namespace Lim_Circus.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
            Roles_CB.Items.Clear();
            foreach(Roles role in DBConnection.connection.Roles)
            {
                Roles_CB.Items.Add(role.Name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(DBConnection.connection.Users.Where(x => x.Username == Login_TB.Text).FirstOrDefault() != null)
            {
                MessageBox.Show("Пользователь с такин логином уже существует");
                return;
            }
            if(Password_PB.Password != PasswordConfirmation_PB.Password)
            {
                MessageBox.Show("Пароль введен неверно");
                return;
            }
            Users users = new Users()
            {
                Username = Login_TB.Text,
                Password = Password_PB.Password,
                Role_ID = Roles_CB.SelectedIndex + 1,
            };
            DBConnection.connection.Users.Add(users);
            DBConnection.connection.SaveChanges();
            MessageBox.Show("Пользователь успешно создан");
            this.Close();
        }
    }
}
