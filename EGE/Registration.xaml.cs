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
using System.Data.SqlClient;

namespace EGE
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private readonly EGE_SchoolEntities _context;

        public Registration(EGE_SchoolEntities context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var curator = new Curator
            {
                Namee = First_Name.Text,
                SecondName = Second_Name.Text,
                Patronymic = Patronymic.Text,
                Number = Telephone_Number.Text,
                Email = Email.Text,
                Speciality = Speciality.Text,
                Login = Login.Text,
                Password = Password.Text,
            };
            _context.Curator.Add(curator);
            _context.SaveChanges();


            Authorization Auth = new Authorization();
            this.Hide();
            Auth.Show();
            MessageBox.Show("Вы успешно зарегестрировались");
        }

        private void Already_Have_An_Account_Click(object sender, RoutedEventArgs e)
        {
            Authorization Auth = new Authorization();
            this.Hide();
            Auth.Show();
        }
    }
}
