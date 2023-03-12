using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());  
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/sosneshzasotky");
            Process.Start("https://discord.gg/z6ZF4By4");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Process.Start("https://docs.google.com/document/d/1cMNsosI3F5vQcbFAVC3LEFg7C-r-6uJnfkhaopCLyw0/edit?usp=sharing");
        }
    }
}
