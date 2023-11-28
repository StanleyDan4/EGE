using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EGE
{
    /// <summary>
    /// Логика взаимодействия для My_classes.xaml
    /// </summary>
    public partial class My_classes : Window
    {
       
        public My_classes()
        {
            InitializeComponent();
        }
       
           
        

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Authorization Auth = new Authorization();
            this.Hide();
            Auth.Show();
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile pr = new Profile();
            this.Hide();
            pr.Show();
        }
        private void My_Students_Click(object sender, RoutedEventArgs e)
        {
            My_Students my_Students = new My_Students();
            this.Hide();
            my_Students.Show();
        }
    }
}
