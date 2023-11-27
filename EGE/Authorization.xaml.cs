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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        private readonly EGE_SchoolEntities _context;
        public Authorization(EGE_SchoolEntities context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Registration RG = new Registration(new EGE_SchoolEntities());
            this.Hide();
            RG.Show();
        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            Profile pr = new Profile();
            this.Hide();
            pr.Show();
        }
    }
}
