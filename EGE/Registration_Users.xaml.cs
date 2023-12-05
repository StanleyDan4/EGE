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
using System.Text.RegularExpressions;

namespace EGE
{
    /// <summary>
    /// Логика взаимодействия для Registration_Users.xaml
    /// </summary>
    public partial class Registration_Users : Window
    {
        private readonly EGE_SchoolEntities _context;
        public Curator Curator { get; set; }
        public Curator Context { get; set; }
        public Registration_Users(EGE_SchoolEntities context, Curator curator)
        {
            InitializeComponent();
            Curator = curator;
            _context = context;
            Context = curator;

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(First_Name.Text) && !string.IsNullOrEmpty(Second_Name.Text) && !string.IsNullOrEmpty(Patronymic.Text) && !string.IsNullOrEmpty(Telephone_Number.Text) && !string.IsNullOrEmpty(Email.Text) && !string.IsNullOrEmpty(Login.Text))
            {
                if (char.IsUpper(First_Name.Text[0]) && char.IsUpper(Second_Name.Text[0]) && char.IsUpper(Patronymic.Text[0]))
                {
                    if (IsFirstNameValid(First_Name.Text))
                    {
                        if (IsSecondNameValid(Second_Name.Text))
                        {
                            if (IsPatronymicValid(Patronymic.Text))
                            {
                                if (IsPhoneNumberValid(Telephone_Number.Text))
                                {
                                    if (IsEmailValid(Email.Text))
                                    {
                                        var users = new Users
                {
                    Namee = First_Name.Text,
                    SecondName = Second_Name.Text,
                    Patronymic = Patronymic.Text,
                    Number = Telephone_Number.Text,
                    Email = Email.Text,
                    Login_Curator = Login.Text

                };

                MessageBox.Show("Вы успешно зарегистрировали ученика!");
                _context.Users.Add(users);
                _context.SaveChanges();
                Profile profile = new Profile(new EGE_SchoolEntities(), Curator);
                this.Hide();
                profile.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Пожалуйста, введите корректный адрес электронной почты!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Пожалуйста, введите корректный номер телефона!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пожалуйста, введите корректное отчество!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, введите корректную фамилию!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите корректное имя!");
                    }
                }
                else
                {
                    MessageBox.Show("Имя, фамилия и отчество должны начинаться с заглавной буквы!");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
            }
        }
        bool IsFirstNameValid(string firstname)
        {
            string firstnamePattern = @"^[A-ЯЁ][а-яё]{4,}$";
            return Regex.IsMatch(firstname, firstnamePattern);
        }
        bool IsSecondNameValid(string secondname)
        {
            string secondnamePattern = @"^[A-ЯЁ][а-яё]{5,}$";
            return Regex.IsMatch(secondname, secondnamePattern);
        }
        bool IsPatronymicValid(string patronymic)
        {
            string patronymicPattern = @"^[A-ЯЁ][а-яё]{5,}$";
            return Regex.IsMatch(patronymic, patronymicPattern);
        }
        bool IsEmailValid(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }
        bool IsPhoneNumberValid(string phoneNumber)
        {
            string phonePattern = @"^\+7\d{10}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }
    }
}
