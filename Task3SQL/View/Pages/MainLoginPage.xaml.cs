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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task3SQL.Core;
using Task3SQL.Model;

namespace Task3SQL.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainLoginPage.xaml
    /// </summary>
    public partial class MainLoginPage : Page
    {
        private SASEntities _db = new SASEntities();

        public MainLoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text) ||
                string.IsNullOrEmpty(PbPassword.Password))
            {
                MessageBox.Show("Ошибка ввода данных", "Системное сообщение",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    User userModel = _db.Users.FirstOrDefault(d => d.Login == TbLogin.Text && d.Password == PbPassword.Password);
                    if(userModel != null)
                    {
                        MessageBox.Show($"{userModel.Login} - выполнен успешный вход!", "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка ввода данных", "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                }
            }
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            CoreConnection.CoreFrame.Navigate(new RegistrationPage());
        }
    }
}
