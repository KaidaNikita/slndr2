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
using System.Windows.Shapes;

namespace Slenderman
{
    /// <summary>
    /// Interaction logic for StartMenu.xaml
    /// </summary>
    public partial class StartMenu : Window
    {
        public StartMenu()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("chrome.exe", @"https://en.wikipedia.org/wiki/Slender_Man");
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Choice main = new Choice();
            Visibility = Visibility.Hidden;
            main.ShowDialog();
            Visibility = Visibility.Visible;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to close this game?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
            { 
            }
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Developers developers = new Developers();
            developers.Show();
        } 
    }
}
