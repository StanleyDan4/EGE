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
    /// Логика взаимодействия для chat.xaml
    /// </summary>
    public partial class chat : Window

    {
        private readonly EGE_SchoolEntities _context;
        private readonly Message _message;
        private Tariff _tariff;
        public chat()
        {
            _context = new EGE_SchoolEntities();
            InitializeComponent();
            TextBox_Start.Text = "Привет! На связи Чат Бот нашей онлайн школы DA! Скорее узнай актуальную информацию про обучение!";
            TextBox_ShortInfo.Visibility = Visibility.Hidden;
            Button_Second_First.Visibility = Visibility.Hidden;
            Button_Second_Second.Visibility = Visibility.Hidden;
            Button_Second_Third.Visibility = Visibility.Hidden;
            TextBox_Info.Visibility = Visibility.Hidden;
        }

        private void Button_Click_AboutUs(object sender, RoutedEventArgs e)
        {
            TextBox_ShortInfo.Visibility = Visibility.Visible;
            Button_Second_First.Visibility = Visibility.Visible;
            Button_Second_Second.Visibility = Visibility.Visible;
            Button_Second_Third.Visibility = Visibility.Visible;
            TextBox_ShortInfo.Text = "О нас";
            TextBox_ShortInfo.FontSize = 16;
            TextBox_ShortInfo.TextAlignment = TextAlignment.Center;
            Button_Second_First.Content = "Информация";
            Button_Second_Second.Content = "Основатели";
            Button_Second_Third.Content = "Успехи";
            TextBox_Info.Visibility = Visibility.Hidden;

        }

        private void Button_Click_Price(object sender, RoutedEventArgs e)
        {

            TextBox_ShortInfo.Visibility = Visibility.Visible;
            Button_Second_First.Visibility = Visibility.Visible;
            Button_Second_Second.Visibility = Visibility.Visible;
            Button_Second_Third.Visibility = Visibility.Visible;
            TextBox_ShortInfo.Text = "Цена";
            TextBox_ShortInfo.FontSize = 16;
            TextBox_ShortInfo.TextAlignment = TextAlignment.Center;
            Button_Second_First.Content = "Light";
            Button_Second_Second.Content = "Classic";
            Button_Second_Third.Content = "Gold";
            TextBox_Info.Visibility = Visibility.Hidden;

        }

        private void Button_Click_Tariff(object sender, RoutedEventArgs e)
        {
            TextBox_ShortInfo.Visibility = Visibility.Visible;
            Button_Second_First.Visibility = Visibility.Visible;
            Button_Second_Second.Visibility = Visibility.Visible;
            Button_Second_Third.Visibility = Visibility.Hidden;

            TextBox_ShortInfo.Text = "Тариф";
            TextBox_ShortInfo.FontSize = 16;
            TextBox_ShortInfo.TextAlignment = TextAlignment.Center;
            Button_Second_First.Content = "Виды";
            Button_Second_Second.Content = "Скидка";
            TextBox_Info.Visibility = Visibility.Hidden;
        }
        private void Button_Click_Second_First(object sender, RoutedEventArgs e)
        {
            TextBox_Info.Visibility = Visibility.Visible;
            Message message;
            Tariff tariff;
            Tariff price;

            if (TextBox_ShortInfo.Text == "О нас")
            {
                using (var context = new EGE_SchoolEntities())
                {
                    var id_Message = 1;

                    message = context.Message.FirstOrDefault(c =>
                   c.ID_Message == id_Message);

                }
                TextBox_Info.Text = message.Text;
                TextBox_Info.FontSize = 16;
            }
            else if (TextBox_ShortInfo.Text == "Тариф")
            {

                TextBox_Info.Text = "Тариф Light - это тариф с самопроверкой, там не будет личного куратора, который будет проверять твои ДЗ Тариф Classic -включает в себя персонального куратора, который ответит на все твои вопросы и проверит ДЗ Тариф Gold -отличается тем, что данный тариф включает в себя дополнительные занятия с преподавателем в месяц по проблемным(или желаемым) темам";
                TextBox_Info.FontSize = 16;
            }
            else
            {
                var Namee = Button_Second_First.Content;

                using (var context = new EGE_SchoolEntities())
                {


                    tariff = context.Tariff.FirstOrDefault(c =>
                   c.Namee == Namee);
                    _tariff = tariff;

                }
                TextBox_Info.Text = "Тариф " + _tariff.Namee + ". Стоимость " + _tariff.Price + " руб/мес";
                TextBox_Info.FontSize = 16;

            }
        }
        private void Button_Click_Second_Second(object sender, RoutedEventArgs e)
        {
            TextBox_Info.Visibility = Visibility.Visible;
            Message message;
            Tariff tariff;
            if (TextBox_ShortInfo.Text == "О нас")
            {
                using (var context = new EGE_SchoolEntities())
                {
                    var id_Message = 2;

                    message = context.Message.FirstOrDefault(c =>
                   c.ID_Message == id_Message);
                }
                TextBox_Info.Text = message.Text;
                TextBox_Info.FontSize = 16;
            }
            else if (TextBox_ShortInfo.Text == "Тариф")
            {

                TextBox_Info.Text = "Так же вы можете покупать по скидке сразу 3 тарифа Gold по трем профильным предметам. Например: Физика, Математика и Информатика. Скидка составляет 15%";
                TextBox_Info.FontSize = 16;
            }
            else
            {
                var Namee = Button_Second_Second.Content;

                using (var context = new EGE_SchoolEntities())
                {


                    tariff = context.Tariff.FirstOrDefault(c =>
                   c.Namee == Namee);
                    _tariff = tariff;

                }
                TextBox_Info.Text = "Тариф " + _tariff.Namee + ". Стоимость " + _tariff.Price + " руб/мес";
                TextBox_Info.FontSize = 16;

            }


        }
        private void Button_Click_Second_Third(object sender, RoutedEventArgs e)
        {
            TextBox_Info.Visibility = Visibility.Visible;
            Message message;
            Tariff tariff;
            if (TextBox_ShortInfo.Text == "О нас")
            {
                using (var context = new EGE_SchoolEntities())
                {
                    var id_Message = 3;

                    message = context.Message.FirstOrDefault(c =>
                   c.ID_Message == id_Message);
                }
                TextBox_Info.Text = message.Text;
                TextBox_Info.FontSize = 16;
            }
            else
            {
                var Namee = Button_Second_Third.Content;

                using (var context = new EGE_SchoolEntities())
                {


                    tariff = context.Tariff.FirstOrDefault(c =>
                   c.Namee == Namee);
                    _tariff = tariff;

                }
                TextBox_Info.Text = "Тариф " + _tariff.Namee + ". Стоимость " + _tariff.Price + " руб/мес";
                TextBox_Info.FontSize = 16;

            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            
            Authorization profile = new Authorization();
            this.Hide();
            profile.Show();
        }

       
    }
}
