using ERD.AppData;
using ERDProduct.ApplicationData;
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

namespace ERDProduct.Pages.Admin.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для DocumentPage.xaml
    /// </summary>
   public partial class DocumentPage : Page
    {
        public bool SizeWindow { get; private set; } //размер окна
        public decimal MadeMoney, SentMoney, Total; //переменные для данных о деньгах
        public string Popular; //самый популярный товар
        public DocumentPage()
        {
            InitializeComponent();
            DtGrAdmBuy.ItemsSource = ClsFrame.Ent.Product.Where(x => x.ProductListType == 1).ToList(); // заполнение датагридов
            DtGrAdmTotal.ItemsSource = ClsFrame.Ent.Product.Where(x => x.ProductListType == 3).ToList();
            DtGrAdmSell.ItemsSource = ClsFrame.Ent.Product.Where(x => x.ProductListType == 4).ToList();

            MadeMoney = Convert.ToDecimal(ClsFrame.Ent.Product.Where(x => x.ProductListType == 4).Select(x => x.Ammount * x.Price).Sum()); // заполнение переменных для получения подробных данных
            SentMoney = Convert.ToDecimal(ClsFrame.Ent.Product.Where(x => x.ProductListType == 3).Select(x => x.Ammount * x.Price).Sum());

            Total = MadeMoney - SentMoney; // разница между полученными и потраченными деньгами

            TxtMadeMoney.Text = Convert.ToString(MadeMoney);
            TxtSentMoney.Text = Convert.ToString(SentMoney);
            TxtTotal.Text = Convert.ToString(Total);

            TxtPopular.Text = ClsFrame.Ent.Product.Where(x => x.ProductListType == 4).OrderByDescending(x => x.Ammount).Select(x => x.Name).FirstOrDefault().ToString(); //вывод самого продаваемого товара
            TxtUnPopular.Text = ClsFrame.Ent.Product.Where(x => x.ProductListType == 4).OrderBy(x => x.Ammount).Select(x => x.Name).FirstOrDefault().ToString(); //вывод самого не продаваемого товара

            if (Total > 0)
                TxtConclusion.Text = "В компании все хорошо, мы имеем прибыль!";

            else
                TxtConclusion.Text = "Мы терпим убыдки, нужно что-то делать!";
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

        private void BtnPrintBuy_Click(object sender, RoutedEventArgs e)
        {
            ClsFiltr.FuncPrint(AdminPage);
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

        private void TxtFind_GotFocus(object sender, RoutedEventArgs e)
        {
            ClsFiltr.TxbGot(TxtFind, "Поиск");
        }

        private void TxtFind_LostFocus(object sender, RoutedEventArgs e)
        {
            ClsFiltr.TxbLost(TxtFind, "Поиск");
        }

        /// <summary>
        /// Поиск по бд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtFind_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (TabFirst.IsSelected == true && TxtFind.Text != "Поиск") //посик по таблице в закупке
                DtGrAdmBuy.ItemsSource = ClsFrame.Ent.Product.Where(x => x.Name.Contains(TxtFind.Text) && x.ProductListType == 1).ToList();

            if (TabSec.IsSelected == true && TxtFind.Text != "Поиск") //в товарах на складе
                DtGrAdmSell.ItemsSource = ClsFrame.Ent.Product.Where(x => x.Name.Contains(TxtFind.Text) && x.ProductListType == 4).ToList();

            if (TabTotal.IsSelected == true && TxtFind.Text != "Поиск") //в проданых товарах
                DtGrAdmTotal.ItemsSource = ClsFrame.Ent.Product.Where(x => x.Name.Contains(TxtFind.Text) && x.ProductListType == 3).ToList();
        }

    }
}
