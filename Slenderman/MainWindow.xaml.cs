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

namespace Slenderman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player player;
        public MainWindow()
        {
            InitializeComponent();
            player = new Player();
            player.Source = new BitmapImage(new Uri(@"Textures/player.png", UriKind.Relative));

            player.OpacityMask =Brushes.Black;
            player.Height = 20;
            player.Width = 20;
            canvas.Children.Add(player);
            Canvas.SetTop(player, 50);
            Canvas.SetLeft(player, 50);
           // papers.Content = "Count of letters" + player.count_of_papers.ToString() + "/3";
        }

        

        bool IsIntersect()
        {
            bool temp = false;
            foreach (var el in canvas.Children)
            {
                try
                {
                    GeneralTransform t1 = (el as Rectangle).TransformToVisual(this);
                    GeneralTransform t2 = player.TransformToVisual(this);
                    Rect r1 = t1.TransformBounds(new Rect() { X = 0, Y = 0, Width = (el as Rectangle).ActualWidth, Height = (el as Rectangle).ActualHeight });
                    Rect r2 = t2.TransformBounds(new Rect() { X = 0, Y = 0, Width = player.ActualWidth, Height = player.ActualHeight });
                    bool result = r1.IntersectsWith(r2);
                    if (result)
                    {
                        return true; 
                    }
                }

                catch { }
            }
            return temp;
        }


        bool IsLetter()
        {
            bool temp = false;
            foreach (var el in canvas.Children)
            {
                try
                {
                    Ellipse my_eliplse = (Ellipse)el;
                    GeneralTransform t1 = my_eliplse.TransformToVisual(this);
                    GeneralTransform t2 = player.TransformToVisual(this);
                    Rect r1 = t1.TransformBounds(new Rect() { X = 0, Y = 0, Width = my_eliplse.ActualWidth, Height = my_eliplse.ActualHeight });
                    Rect r2 = t2.TransformBounds(new Rect() { X = 0, Y = 0, Width = player.ActualWidth, Height = player.ActualHeight });
                    bool result = r1.IntersectsWith(r2);
                    if (result)
                    {
                        return true;
                    }
                }

                catch { }
            }
            return temp;
        }


        private void Moving(object sender, KeyEventArgs e)
        {
            if (e.Key== System.Windows.Input.Key.E)
            { 
            if(IsLetter())
               {
                for (int i = 0; i < canvas.Children.Count; i++)
                {
                    try
                    {
                        Ellipse my_eliplse = (Ellipse)canvas.Children[i];
                        GeneralTransform t1 = my_eliplse.TransformToVisual(this);
                        GeneralTransform t2 = player.TransformToVisual(this);
                        Rect r1 = t1.TransformBounds(new Rect() { X = 0, Y = 0, Width = my_eliplse.ActualWidth, Height = my_eliplse.ActualHeight });
                        Rect r2 = t2.TransformBounds(new Rect() { X = 0, Y = 0, Width = player.ActualWidth, Height = player.ActualHeight });
                        bool result = r1.IntersectsWith(r2);
                        if (result)
                        {
                            canvas.Children.RemoveAt(canvas.Children.IndexOf(my_eliplse));
                            player.count_of_papers++;
                            papers.Content = "Count of letters" + player.count_of_papers.ToString() + "/3";
                        }
                    }
                    catch (Exception)
                    {}
                } 
            }
          
            }

            if ((e.Key == System.Windows.Input.Key.A || e.Key == System.Windows.Input.Key.Left) && Canvas.GetLeft(player) > 1)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - 3);
                if (IsIntersect())
                {
                    Canvas.SetLeft(player, Canvas.GetLeft(player) + 3);
                }
            }
            if ((e.Key == System.Windows.Input.Key.D || e.Key == System.Windows.Input.Key.Right) && Canvas.GetLeft(player) < Width-38)
            {          
                Canvas.SetLeft(player, Canvas.GetLeft(player) + 3);
                if (IsIntersect())
                {
                    Canvas.SetLeft(player, Canvas.GetLeft(player) - 3);
                }
            }   
            if ((e.Key == System.Windows.Input.Key.W || e.Key == System.Windows.Input.Key.Up) && Canvas.GetTop(player) >= -2)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) - 3);
                if (IsIntersect())
                {
                    Canvas.SetTop(player, Canvas.GetTop(player) + 3);
                }
                
            }
            if ((e.Key == System.Windows.Input.Key.S || e.Key == System.Windows.Input.Key.Down) && Canvas.GetTop(player) < Height-57)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) + 3);
                if (IsIntersect())
                {
                    Canvas.SetTop(player, Canvas.GetTop(player) - 3);
                }
                
            }
        }
    }
}
