using Lim_Circus.ADO;
using Lim_Circus.Data;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AddAnimalWindow.xaml
    /// </summary>
    public partial class AddAnimalWindow : Window
    {
        public AddAnimalWindow()
        {
            InitializeComponent();
            Tamers_CB.Items.Clear();
            foreach (Users tamer in DBConnection.connection.Users.Where(x => x.Role_ID == 3).ToList())
            {
                Tamers_CB.Items.Add(tamer.Username);
            }
            Gender_CB.Items.Clear();
            foreach (Gender gender in DBConnection.connection.Gender.ToList())
            {
                Gender_CB.Items.Add(gender.Name);
            }
        }

        private void AddAnimal_BTN_Click(object sender, RoutedEventArgs e)
        {
            Users selectedTamer = DBConnection.connection.Users.Where(x => x.Username == Tamers_CB.SelectedItem).FirstOrDefault();
            if(selectedTamer == null)
            {
                return;
            }
            Animals animal = new Animals()
            {
                Name = Name_TB.Text,
                Age = int.Parse(Age_TB.Text),
                Gender_ID = Gender_CB.SelectedIndex + 1,
                Weight = decimal.Parse(Weight_TB.Text),
                Tamer_ID = selectedTamer.User_ID,
                Food_Preferences = FoodPreferences_TB.Text,
                Care_Recommendations = CareRecommendations_TB.Text,
            };
            DBConnection.connection.Animals.Add(animal);
            DBConnection.connection.SaveChanges();
            MessageBox.Show("Животное успешно добавлено");
        }
    }
}
