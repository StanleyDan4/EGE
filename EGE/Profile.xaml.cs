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
        private readonly EGE_SchoolEntities _context;
        private readonly Curator _curator;
       
        public Profile(EGE_SchoolEntities context, Curator curator)
        {
            InitializeComponent();
           
            _curator = curator;
            NameTextBox.Text = _curator.Namee;
            SurnameTextBox.Text = _curator.SecondName;
            PatronymicTextBox.Text = _curator.Patronymic;
            NumberTextBox.Text = _curator.Number;
            EmailTextBox.Text = _curator.Email;
            SpecialityTextBox.Text = _curator.Speciality;

        }



        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Authorization Auth = new Authorization();
            this.Hide();
            Auth.Show();
        }

        private void My_Students_Click(object sender, RoutedEventArgs e)
        {
            My_Students my_Students = new My_Students();
            this.Hide();
            my_Students.Show();
        }
       
    }
}
