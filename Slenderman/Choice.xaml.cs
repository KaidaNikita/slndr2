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
        int count=0;
        Map map = new Map();
        Random rnd = new Random();
        public Choice()
        {
            InitializeComponent();
        }

        List<int> RandomLetters(List<int> maze)
        {

            for (int i = 0; i < maze.Count; i++)
            {
                int x = rnd.Next(1, 900);
                if (maze[x]==0&& count<3)
                {
                    count++;
                    maze[x] = 2;

                }
            }
            if (count < 3)
            {
            for (int i = 0; i < maze.Count; i++)
            {
                if (maze[i] == 0 || maze[i] == 8 && count < 3)
                {
                    maze[i] = 2;
                    count++;
                }
            }
            }

            //for (int i = 0; i < maze.Count; i++)
            //{
            //    if (maze[i] == 2)
            //    {
            //        MessageBox.Show("2");
            //    }
            //}
            return maze;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(RandomLetters(map.map));
            Visibility = Visibility.Hidden;
            main.ShowDialog();
            Visibility = Visibility.Visible;
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(RandomLetters(map.forest));
            main.map_ints = map.forest;
            Visibility = Visibility.Hidden;
            main.ShowDialog();
            Visibility = Visibility.Visible;
        }
    }
}
