using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Collections;
using System.Configuration;

namespace EGE
{
    /// <summary>
    /// Логика взаимодействия для My_Students.xaml
    /// </summary>
    /// 
    public class TestData3
    {
        public int Column11 { get; set; }
        public string Column22 { get; set; }
        public string Column33 { get; set; }
        public string Column44 { get; set; }
        public string Column55 { get; set; }
        public string Column66 { get; set; }

    }

    public partial class My_Students : Window
    {
        public Curator Curator { get; set; }
        public Users users { get; set; }
        public My_Students(Curator curator)
        {
            InitializeComponent();
            Curator = curator;
            FillDataGrid();
            this.Curator = curator;
        }



        private void FillDataGrid()
        {
            using (EGE_SchoolEntities db = new EGE_SchoolEntities())
            {
                foreach (var i in db.Users)
                {
                    if (i.Login_Curator == Curator.Login)
                    {
                        users = i;
                        break;
                    }
                }

            }
            NewTable();
        }
        public void NewTable()
        {
            table.Items.Clear();
            using (EGE_SchoolEntities db = new EGE_SchoolEntities())
            {
                foreach (var item in db.Users)
                {
                    if (item.Login_Curator == Curator.Login)
                    {

                        table.Items.Add(new TestData3
                        {
                            Column11 = (int)item.ID_User,
                            Column22 = item.Namee,
                            Column33 = item.SecondName,
                            Column44 = item.Patronymic,
                            Column55 = item.Number,
                            Column66 = item.Email
                        });
                    }
                }
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Authorization auth = new Authorization();
            this.Hide();
            auth.Show();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile pr = new Profile(new EGE_SchoolEntities(), Curator);
            this.Hide();
            pr.Show();
        }

        private void Write_1_Click(object sender, RoutedEventArgs e)
        {
            chat Chatik = new chat(Curator);
            this.Hide();
            Chatik.Show();
        }

        private void Registration_User_Click(object sender, RoutedEventArgs e)
        {
            Registration_Users registration = new Registration_Users(new EGE_SchoolEntities(), Curator);
            registration.Show();
        }

        private void Edit_User_Click(object sender, RoutedEventArgs e)
        {
           Edit_Students edit = new Edit_Students(Curator);
           edit.Show();
        }
    }
}
