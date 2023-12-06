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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        Curator _curator;
        public Edit(Curator curator)
        {
            _curator = curator;
            InitializeComponent();
            this._curator = curator;
        
            Password.Text = curator.Password;
            First_Name.Text = curator.Namee;
            Second_Name.Text = curator.SecondName;
            Patronymic.Text = curator.Patronymic;
            Telephone_Number.Text = curator.Number;
            Email.Text = curator.Email;
            Speciality.Text = curator.Speciality;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (First_Name.Text.Trim() != "" && Second_Name.Text.Trim() != "" && Patronymic.Text.Trim() != "" && Telephone_Number.Text.Trim() != "" && Email.Text.Trim() != "" && Speciality.Text.Trim() != "" && Password.Text.Trim() != "")
            {
                using (EGE_SchoolEntities db = new EGE_SchoolEntities())
                {
                    try
                    {
                        Curator u = null;
                        foreach (var us in db.Curator)
                        {
                            if (us.ID_Curator == this._curator.ID_Curator)
                            {
                                u = db.Curator.Find(us.ID_Curator);
                                break;
                            }
                        }

                        u.Password = Password.Text;
                        u.Namee = First_Name.Text;
                        u.SecondName = Second_Name.Text;
                        u.Patronymic = Patronymic.Text;
                        u.Number = Telephone_Number.Text;
                        u.Email = Email.Text;
                        u.Speciality = Speciality.Text;
                        db.SaveChanges();
                        System.Windows.MessageBox.Show("Сохранено");
                        Profile profile = new Profile(new EGE_SchoolEntities(), _curator);
                        this.Hide();

                        profile.Show();


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


    }
}

