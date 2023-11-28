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
    /// Логика взаимодействия для My_Students.xaml
    /// </summary>
    public partial class My_Students : Window
    {
        public My_Students()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Authorization auth = new Authorization();
            this.Hide();
            auth.Show();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile pr = new Profile();
            this.Hide();
            pr.Show();
        }
        private void My_Classes_Click(object sender, RoutedEventArgs e)
        {
            My_classes my_Classes = new My_classes();
            this.Hide();
            my_Classes.Show();
        }
    }
}
