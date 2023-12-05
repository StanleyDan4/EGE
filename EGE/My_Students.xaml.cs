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
        Curator curator;
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
            Profile pr = new Profile(new EGE_SchoolEntities(),curator);
            this.Hide();
            pr.Show();
        }

        private void Write_1_Click(object sender, RoutedEventArgs e)
        {
            chat Chatik = new chat();
            this.Hide();
            Chatik.Show();
        }
    }
}
