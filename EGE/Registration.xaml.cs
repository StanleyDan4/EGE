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
using System.Text.RegularExpressions;

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
            if (_context.Curator.Any(c => c.Login == Login.Text))
            {
                MessageBox.Show("Такой логин уже существует!");
                return;
            }
            if (!string.IsNullOrEmpty(First_Name.Text) && !string.IsNullOrEmpty(Second_Name.Text) && !string.IsNullOrEmpty(Patronymic.Text) && !string.IsNullOrEmpty(Telephone_Number.Text) && !string.IsNullOrEmpty(Email.Text) && !string.IsNullOrEmpty(Speciality.Text) && !string.IsNullOrEmpty(Login.Text) && !string.IsNullOrEmpty(Password.Text))
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
                                        if (IsSpecialityValid(Speciality.Text))
                                        {

                                            if (IsLoginValid(Login.Text))
                                            {
                                               

                                                if (IsPasswordValid(Password.Text))
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
                                                    MessageBox.Show("Вы зарегистрированы!");
                                                    First_Name.Clear();
                                                    Second_Name.Clear();
                                                    Patronymic.Clear();
                                                    Telephone_Number.Clear();
                                                    Email.Clear();
                                                    Speciality.Clear();
                                                    Login.Clear();
                                                    Password.Clear();
                                                    Hide();
                                                    Authorization Auth = new Authorization();
                                                    this.Hide();
                                                    Auth.Show();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Длина пароля не должна быть менее 8 символов!");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Пожалуйста, введите корректный логин!");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Пожалуйста, введите корректную специальность ");
                                        }
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
            bool IsSpecialityValid(string speciality)
            {
                string specialityPattern = @"^[A-ЯЁ][а-яё]{5,}$";
                return Regex.IsMatch(speciality, specialityPattern);
            }
            bool IsPhoneNumberValid(string phoneNumber)
            {
                string phonePattern = @"^\+7\d{10}$";
                return Regex.IsMatch(phoneNumber, phonePattern);
            }
            bool IsLoginValid(string login)
            {
                string loginPattern = @"^[a-zA-Z0-9._%+-]{4,}$";
                return Regex.IsMatch(login, loginPattern);
            }
            bool IsPasswordValid(string password)
            {
                string passwordPattern = @"^[a-zA-Z0-9_]{8,}$";
                return Regex.IsMatch(password, passwordPattern);
            }
        }


        private void Already_Have_An_Account_Click(object sender, RoutedEventArgs e)
        {
            Authorization Auth = new Authorization();
            this.Hide();
            Auth.Show();
        }
    }
}