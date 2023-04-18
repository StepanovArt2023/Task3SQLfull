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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private SASEntities _db = new SASEntities();

        public RegistrationPage()
        {
            InitializeComponent();
            CbRole.ItemsSource = _db.Users.ToList();
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
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
                    _db.Users.Add(new User()
                    {
                        Login = TbLogin.Text,
                        Password = PbPassword.Password,
                        RoleID = Convert.ToInt32(CbRole.Text)
                    });
                    _db.SaveChanges();
                    MessageBox.Show("Учётная запись создана", "Системное сообщение",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    CoreConnection.CoreFrame.Navigate(new MainLoginPage());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                }
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            CoreConnection.CoreFrame.Navigate(new MainLoginPage());

        }
    }
}
