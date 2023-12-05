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
         Curator Curator { get; set; }
        
        public Profile(EGE_SchoolEntities context, Curator curator)
        {
            InitializeComponent();
            
                    Curator = curator;
            NameTextBox.Text = Curator.Namee;
            SurnameTextBox.Text = Curator.SecondName;
            PatronymicTextBox.Text = Curator.Patronymic;
            NumberTextBox.Text = Curator.Number;
            EmailTextBox.Text = Curator.Email;
            SpecialityTextBox.Text = Curator.Speciality;

        }



        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Authorization Auth = new Authorization();
            this.Hide();
            Auth.Show();
        }

        private void My_Students_Click(object sender, RoutedEventArgs e)
        {
            My_Students my_Students = new My_Students(Curator);
            this.Hide();
            my_Students.Show();
        }
       private void Message_Click(object sender,RoutedEventArgs e)
        {
            Profile profile = new Profile(new EGE_SchoolEntities(), Curator);
            this.Hide();
           
            profile.Show();
        }

        private void Registration_User_Click(object sender, RoutedEventArgs e)
        {
            Registration_Users registrUser = new Registration_Users( new EGE_SchoolEntities(),Curator);
            this.Hide();

            registrUser.Show();
        }
    }
}
