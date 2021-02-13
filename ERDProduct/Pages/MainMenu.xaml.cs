using ERDProduct.ApplicationData;
using ERDProduct.Pages.Admin;
using ERDProduct.Pages.MemagerBuy;
using ERDProduct.Pages.MenagerSell;
using ERDProduct.Windowses;
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

namespace ERDProduct.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public bool SizeWindow { get; private set; }
        public MainMenu()
        {
            InitializeComponent();

            CmbLogin.DisplayMemberPath = "Login";
            CmbLogin.SelectedValuePath = "Id";
            CmbLogin.ItemsSource = ClsFrame.Ent.User.ToList();

            CmbLogin.SelectedIndex = 1;
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            var user = ClsFrame.Ent.User.FirstOrDefault(x => x.Password == TxtPassword.Password && x.Login == CmbLogin.Text);

            if (string.IsNullOrEmpty(CmbLogin.Text) || string.IsNullOrEmpty(TxtPassword.Password))
            {
                MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (user == null)
                MessageBox.Show("Пользователь не найден или пароль введен неверно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);

            else
            {
                try
                {
                    switch (user.IdRole)
                    {
                        case 1:
                            ClsFrame.FrameCener.Navigate(new PageAdmin());
                            break;

                        case 2:
                            ClsFrame.FrameCener.Navigate(new PageMenagerBuy());
                            CallTicket();
                            break;

                        case 3:
                            ClsFrame.FrameCener.Navigate(new PageMenagerSell());
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так, обратитесь к специалисту!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                }

            }
        }

        private void CallTicket()
        {
            WindowTicket ticket = new WindowTicket();
            ticket.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ticket.Show();
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
