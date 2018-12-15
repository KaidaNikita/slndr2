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

namespace Slenderman
{
    /// <summary>
    /// Логика взаимодействия для Choice.xaml
    /// </summary>
    public partial class Choice : Window
    {
        Map map = new Map();
        public int x;
        public Choice()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            x = 1;
            MainWindow main = new MainWindow(map.map);
            main.Show();
          //  this.Close();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            x = 2;
            MainWindow main = new MainWindow(map.forest);
            main.map_ints = map.forest;
            main.Show();
           // this.Close();
        }
    }
}
