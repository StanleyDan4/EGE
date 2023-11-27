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

namespace EGE
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Authorization Auth = new Authorization(new EGE_SchoolEntities());
            this.Hide();
            Auth.Show();
        }

        private void My_Students_Click(object sender, RoutedEventArgs e)
        {
            My_Students my_Students = new My_Students();
            this.Hide();
            my_Students.Show();
        }
        private void My_Classes_Click(object sender, RoutedEventArgs e)
        {
            My_classes my_Classes = new My_classes();
            this.Hide();
            my_Classes.Show();
        }
    }
}
