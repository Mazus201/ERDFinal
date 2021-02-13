using ERD.AppData;
using ERDProduct.ApplicationData;
using ERDProduct.Resource;
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

namespace ERDProduct.Pages.MenagerSell
{
    /// <summary>
    /// Логика взаимодействия для PageMenagerSell.xaml
    /// </summary>
    public partial class PageMenagerSell : Page
    {
        public bool SizeWindow { get; private set; } //размер окна
        public PageMenagerSell()
        {
            InitializeComponent();
            DtGrMSReserv.ItemsSource = ClsFrame.Ent.Product.Where(x => x.ProductListType == 1 && x.Reserv > 0).ToList(); // заполнение датагридов
            DtGrMSTotal.ItemsSource = ClsFrame.Ent.Product.Where(x => x.ProductListType == 1).ToList();

            TxtPopular.Text = ClsFrame.Ent.Product.Where(x => x.ProductListType == 4).OrderByDescending(x => x.Ammount).Select(x => x.Name).FirstOrDefault().ToString(); //вывод самого продаваемого товара
            TxtUnPopular.Text = ClsFrame.Ent.Product.Where(x => x.ProductListType == 4 && x.Ammount != 0).OrderBy(x => x.Ammount).Select(x => x.Name).FirstOrDefault().ToString(); //вывод самого не продаваемого товара
        }
        /// <summary>
        /// поиск по таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtFind_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (TabReserv.IsSelected == true && TxtFind.Text != "Поиск") //поиск по таблице среди магазина
                DtGrMSReserv.ItemsSource = ClsFrame.Ent.Product.Where(x => x.Name.Contains(TxtFind.Text) && x.ProductListType == 1 && x.Reserv > 0).ToList();

            if (TabStore.IsSelected == true && TxtFind.Text != "Поиск") //поиск по таблице среди товара на складе
                DtGrMSTotal.ItemsSource = ClsFrame.Ent.Product.Where(x => x.Name.Contains(TxtFind.Text) && x.ProductListType == 1).ToList();

        }


        private void BtnPrintBuy_Click(object sender, RoutedEventArgs e)
        {
            ClsFiltr.FuncPrint(PageMS); //вывод на печать
        }
        private void TxtFind_GotFocus(object sender, RoutedEventArgs e)
        {
            ClsFiltr.TxbGot(TxtFind, "Поиск");
        }

        private void TxtFind_LostFocus(object sender, RoutedEventArgs e)
        {
            ClsFiltr.TxbLost(TxtFind, "Поиск");
        }


        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (SizeWindow == false) //проверяем открыто ли окно на весь экран
            {
                App.Current.MainWindow.WindowState = WindowState.Maximized; //если нет, то увеличиваем
                SizeWindow = true;
            }
            else //и наоборот
            {
                App.Current.MainWindow.WindowState = WindowState.Normal;
                SizeWindow = false;
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Current.Shutdown();
            }
            catch
            {
                MessageBox.Show("Я знаю, что тут ошибка и знаю из-за чего, но пофиксить не удается :(");
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (SizeWindow == true)
            {
                App.Current.MainWindow.WindowState = WindowState.Normal;
                SizeWindow = false;
            }
            ClsFrame.FrameCener.GoBack();
        }

        private void BtnSellProduct_Click(object sender, RoutedEventArgs e)
        {
            WindowToSell window = new WindowToSell((sender as Button).DataContext as Product);
            window.Show();
        }

    }
}

