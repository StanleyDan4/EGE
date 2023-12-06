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
    /// Логика взаимодействия для Edit_Students.xaml
    /// </summary>
    public partial class Edit_Students : Window
    {
        public Curator Curator { get; set; }
        public Users _users { get; set; }
        public Curator _curator { get; set; }

        public Edit_Students(Curator curator)
        {
            _curator = curator; 
            InitializeComponent();
        

        }

        private void n_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void e_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            if (b.Text.Trim()!="")
            {
                using (EGE_SchoolEntities db = new EGE_SchoolEntities())
                {
                   
                    try
                    {
                        Users u = null;
                        foreach (var us in db.Users)
                        {
                            if (us.Email == b.Text )
                            {
                                u = db.Users.Find(us.ID_User);
                                break;
                            }
                        }

                       
                        
                        db.Users.Remove(u);
                        db.SaveChanges();
                
                        Profile profile = new Profile(new EGE_SchoolEntities(), _curator);
                        System.Windows.MessageBox.Show("Сохранено");
                        this.Hide();
                       

                    }
                    catch
                    {
                        MessageBox.Show("Неверно введены данные");
                    }
                }
            }
            else
                MessageBox.Show("Не все поля заполнены");
        }

        private void b_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

     
    }
}
