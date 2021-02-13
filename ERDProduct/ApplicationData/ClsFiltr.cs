using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ERD.AppData
{
    class ClsFiltr
    {
        public static void FuncPrint(Visual visual)
        {
            PrintDialog printObj = new PrintDialog();

            if (printObj.ShowDialog() == true)
            {
                printObj.PrintVisual(visual, "");
            }
            else
            {
                MessageBox.Show("Произошла отмена печати!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public static void TxbGot(TextBox textBox, string Text)
        {
            if (textBox.Text == Text)
            {
                textBox.Text = null;
                textBox.Foreground = Brushes.Black;
            }
        }
        public static void TxbLost(TextBox textBox, string Text)
        {
            if (textBox.Text == "")
            {
                textBox.Text = Text;
                textBox.Foreground = Brushes.LightGray;
            }
        }

        public static void TxbClear(TextBox textBox1, string Text)
        {
            textBox1.Foreground = Brushes.LightGray;
            textBox1.Text = Text;
        }
    }
}
