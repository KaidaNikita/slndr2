using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            FileStream fs = new FileStream(@"slnd/SlenderTheEightPage.html", FileMode.Open, FileAccess.Read);
            Process.Start("chrome.exe",fs.Name);
            fs.Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
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
            Visibility = Visibility.Hidden;
            developers.ShowDialog();
            Visibility = Visibility.Visible;
        }

        //<Button Content="Play"
        // HorizontalAlignment="Left"
        //         Margin="185,43,0,0"
        //         VerticalAlignment="Top"
        //         Background="Transparent"
        //         Foreground="LightGray"
        //         Width="167"
        //         FontSize="25"
        //         Click="Button_Click" Height="Auto">
        // </Button>
        // <Button Content = "Help"
        //         HorizontalAlignment="Left"
        //         Margin="185,143,0,0"
        //         VerticalAlignment="Top"
        //         Background="Transparent"
        //         Foreground="LightGray"
        //         Width="167"
        //          FontSize="25"
        //         Click="Button_Click1" Height="Auto">
        //          </Button>

        // <Button Content = "Exit"
        //         HorizontalAlignment="Left"
        //         Margin="185,243,0,0"
        //         VerticalAlignment="Top"
        //         Background="Transparent"
        //         Foreground="LightGray"
        //         Width="167"
        //          FontSize="25"
        //         Click="Button_Click2" Height="Auto">
        // </Button>
        // <Button Content = "Developers"
        //         HorizontalAlignment="Left"
        //         Margin="185,343,0,0"
        //         VerticalAlignment="Top"
        //         Background="Transparent"
        //         Foreground="LightGray"
        //         Width="167"
        //          FontSize="25"
        //         Click="Button_Click3" Height="Auto">
        // </Button>

    }
}
