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
    /// Логика взаимодействия для AnimalsListWindow.xaml
    /// </summary>
    public partial class AnimalsListWindow : Window
    {
        public AnimalsListWindow()
        {
            InitializeComponent();
            UpdateList();
        }

        private void AddAnimal_BTN_Click(object sender, RoutedEventArgs e)
        {
            AddAnimalWindow newWindow = new AddAnimalWindow();
            newWindow.ShowDialog();
            UpdateList();
        }

        private void UpdateList()
        {
            Animals_List.Items.Clear();
            foreach(Animals animal in DBConnection.connection.Animals.ToList())
            {
                Animals_List.Items.Add(animal);
            }
        }
    }
}
