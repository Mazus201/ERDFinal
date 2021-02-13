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
using System.Windows.Shapes;

namespace ERDProduct.Windowses
{
    /// <summary>
    /// Логика взаимодействия для WindowToBuy.xaml
    /// </summary>
    public partial class WindowToBuy : Window
    {
        public double Sum = 0;
        public double CountProd;
        public double PriceProd = 0;
        public double CountInStock = 0;
        public string ProdName;

        public WindowToBuy(Product product)
        {
            InitializeComponent();
            PriceProd = Convert.ToDouble(product.Price);
            TxtProdName.Text = product.Name;
            CountInStock = Convert.ToDouble(product.Ammount);
        }

        /// <summary>
        /// отображение финальной суммы заказа в реальном времени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtCountProd_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtCountProd.Text)) { } //если юзер еще ничего не ввел, ничего не отображается
                else //если что-то ввел, то идет подсчет
                {
                    CountProd = Convert.ToDouble(TxtCountProd.Text);
                    Sum = PriceProd * CountProd;
                    TxtTotal.Text = Sum.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неверный формат введенных данных. \n {ex}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                TxtCountProd.Text = null;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch { }
        }

        /// <summary>
        /// Обработка закупки товара
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CountProd > CountInStock && CountProd % 1 == 0 && CountProd > 0) //проверка на наличие необходимого количества товра в магазине
            {   //ниже - действие при отсутствии товара в магазине
                MessageBoxResult result = MessageBox.Show($@"На складе производителя нет такого количества товра. Имеется лишь {CountInStock} единиц товара. 
Свяжитесь с производителем или ожидайте пополнения склада.",
                "Нехватка товара", 
                MessageBoxButton.OK, 
                MessageBoxImage.Information);
                if (result == MessageBoxResult.OK) //закрытие окна
                {
                    TxtCountProd.Text = CountInStock.ToString(); //заполнение макимальным количеством товара в магазине
                }
            }
            else if (CountProd % 1 == 0 && CountProd > 0) //если необходимое количество в магазине
            {
                MessageBoxResult result = MessageBox.Show($@"Вы точно хотите заказать {TxtProdName.Text} в количестве {CountProd} единиц на сумму {TxtTotal.Text}?",
                    "Проверка", MessageBoxButton.YesNo, MessageBoxImage.Question); //уточнение правильно ли в веден заказ
                if (result == MessageBoxResult.Yes) //если все верно, то заказываем
                {

                }
                else //если где-то ошибка, то редактируем заказ
                {
                    this.Close();
                }
            }
            else //если формат количетва заказываемого товара не правильно введен
            {
                MessageBox.Show("Вы неправильно ввели количество товара.", "Неверное количество товара", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
