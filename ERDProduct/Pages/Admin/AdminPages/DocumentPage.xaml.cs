using ERD.AppData;
using ERDProduct.ApplicationData;
using ERDProduct.Resource;
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
            DtGrAdmShop.ItemsSource = ClsFrame.Ent.Product.Where(x => x.ProductListType == 1).ToList(); // заполнение датагридов
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


        string DeleteProdName = "выбранный товар";
        /// <summary>
        /// Удаление товара
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TabShop.IsSelected == true) //проверка на то, из какой категории удалям товар
                {
                    MessageBoxResult result = MessageBox.Show($@"Вы точно хотите удалить {DeleteProdName} из списка предлагаемого товара магазина? 
Помните, это действие безвозвратно!", "Удаление из магазина", MessageBoxButton.YesNo, MessageBoxImage.Question); //предупреждение юзера
                    if (result == MessageBoxResult.Yes) //проверка ответа юзера
                    {
                        if (DtGrAdmShop.SelectedItems.Count > 0) //проверяем количество помеченных на удаление строк таблицы
                        {
                            for (int i = 0; i < DtGrAdmShop.SelectedItems.Count; i++) //перебераем все отмеченные на удаление строки
                            {
                                Product product = DtGrAdmShop.SelectedItems[i] as Product; //передаем БД эти строки
                                ClsFrame.Ent.Product.Remove(product); //удаляем их из БД
                            }
                            ClsFrame.Ent.SaveChanges(); //сохраняем изменения
                            DtGrAdmShop.Items.Refresh(); //попытка обновить страницу (неудачная)
                        }
                    }
                    else
                    {

                    }
                }
                else if (TabTotal.IsSelected == true) //удаление со страницы товара на складе
                {
                    MessageBoxResult result = MessageBox.Show($@"Вы точно хотите удалить {DeleteProdName} из списка товаров на нашем складе? 
Помните, это действие безвозвратно!", "Удаление со склада", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (DtGrAdmTotal.SelectedItems.Count > 0)
                        {
                            for (int i = 0; i < DtGrAdmTotal.SelectedItems.Count; i++)
                            {
                                Product product = DtGrAdmTotal.SelectedItems[i] as Product;
                                ClsFrame.Ent.Product.Remove(product);
                            }
                            ClsFrame.Ent.SaveChanges();
                            DtGrAdmTotal.Items.Refresh();
                        }
                    }
                    else
                    {

                    }
                }
                else if (TabSold.IsSelected == true) //удаления со страницы проданного товара
                {
                    MessageBoxResult result = MessageBox.Show($@"Вы точно хотите удалить {DeleteProdName} из списка проданных товаров? 
Помните, это действие безвозвратно!", "Удаление из проданных", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (DtGrAdmSell.SelectedItems.Count > 0)
                        {
                            for (int i = 0; i < DtGrAdmSell.SelectedItems.Count; i++)
                            {
                                Product product = DtGrAdmSell.SelectedItems[i] as Product;
                                ClsFrame.Ent.Product.Remove(product);
                            }
                            ClsFrame.Ent.SaveChanges();
                            DtGrAdmSell.Items.Refresh();
                        }
                    }
                    else
                    {

                    }
                }
                else { }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Кажется, вы пытаетесь удалить объект, которого нет!
{ex}", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ClsFiltr.TxbClear(TxtFind, "Поиск");
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
            if (TabShop.IsSelected == true && TxtFind.Text != "Поиск") //посик по таблице в закупке
                DtGrAdmShop.ItemsSource = ClsFrame.Ent.Product.Where(x => x.Name.Contains(TxtFind.Text) && x.ProductListType == 1).ToList();

            if (TabSold.IsSelected == true && TxtFind.Text != "Поиск") //в товарах на складе
                DtGrAdmSell.ItemsSource = ClsFrame.Ent.Product.Where(x => x.Name.Contains(TxtFind.Text) && x.ProductListType == 4).ToList();

            if (TabTotal.IsSelected == true && TxtFind.Text != "Поиск") //в проданых товарах
                DtGrAdmTotal.ItemsSource = ClsFrame.Ent.Product.Where(x => x.Name.Contains(TxtFind.Text) && x.ProductListType == 3).ToList();
        }

    }
}
