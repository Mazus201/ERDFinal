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
    /// Логика взаимодействия для WindowToSell.xaml
    /// </summary>
    public partial class WindowToSell : Window
    {
        public double Sum = 0;
        public double CountProd;
        public double PriceProd = 0;
        public double CountInStock = 0;

        public WindowToSell(Product product)
        {
            InitializeComponent();
            PriceProd = Convert.ToDouble(product.Price);
            TxtProdName.Text = product.Name;
            CountInStock = Convert.ToDouble(product.Ammount);
        }

        private void TxtCountProd_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtCountProd.Text)) { }
                else
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CountProd > CountInStock)
            {
                MessageBoxResult result = MessageBox.Show($@"В данный момент на складе имеется лишь {CountInStock} единиц товара. 
Предупредите покупателя о задержке и продолжите или измените развмер заказа.",
                "Нехватка товара",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
                else
                {
                    TxtCountProd.Text = CountInStock.ToString();
                }
            }
            else
            {
                this.Close();
            }
        }
    }

}