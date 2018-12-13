using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        Slender slender;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        static Map mymap = new Map();
        List<int> map_ints = mymap.map;

        public MainWindow()
        {
            InitializeComponent();
            SetMap();
            SetPlayer();
            SetSlender();
            timer.Tick += new EventHandler(Timer_tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_tick(object sender, EventArgs e)
        {
            // code goes here 
        }

        void SetSlender()
        {
            slender = new Slender();
            slender.Source = new BitmapImage(new Uri(@"Textures/slender.jpg", UriKind.Relative));
            slender.Height = 20;
            slender.Width = 20;
            slender.Tag = "slender";
            canvas.Children.Add(slender);
            Canvas.SetTop(slender, 200);
            Canvas.SetLeft(slender, 200);
        }
        
        void SetPlayer()
        {
            player = new Player();
            player.Source = new BitmapImage(new Uri(@"Textures/player.png", UriKind.Relative));
            player.Height = 20;
            player.Width = 20;
            canvas.Children.Add(player);
            Canvas.SetTop(player, 50);
            Canvas.SetLeft(player, 50);
        }

        void SetMap()
        {
                
            int x=0,y=0;
            for (int i = 0; i < map_ints.Count; i++)
            {
                
                if (map_ints[i] == 1)
                {
                    Image wall = new Image();
                    wall.Source= new BitmapImage(new Uri(@"Textures/wall.png", UriKind.Relative));
                    wall.Width = 25;
                    wall.Height = 25;
                    if (i != 0)
                    {
                        x += 25;
                        if (i % 24 == 0)
                        {
                            y += 25;
                            x = 0;
                        }
                    }
                    Canvas.SetTop(wall, y);
                    Canvas.SetLeft(wall, x);
                    canvas.Children.Add(wall);

                }
                //if (map_ints[i] == 8)
                //{
                //    Image wall = new Image();
                //    wall.Source = new BitmapImage(new Uri(@"Textures/slender.jpg", UriKind.Relative));
                //    wall.Width = 25;
                //    wall.Height = 25;

                //    Canvas.SetTop(wall, y);
                //    Canvas.SetLeft(wall, x);
                //    canvas.Children.Add(wall);

                //}
                if (map_ints[i] == 0)
                {
                    Image wall = new Image();
                    wall.Source = new BitmapImage(new Uri(@"Textures/floor.png", UriKind.Relative));
                    wall.Width = 25;
                    wall.Height = 25;
                    if (i != 0)
                    {
                        x += 25;
                        if (i % 24 == 0)
                        {
                            y += 25;
                            x = 0;
                        }
                    }
                    Canvas.SetTop(wall, y);
                    Canvas.SetLeft(wall, x);
                    canvas.Children.Add(wall);

                }
                if (map_ints[i] == 2)
                {
                    Image wall = new Image();
                    wall.Source = new BitmapImage(new Uri(@"Textures/floor.png", UriKind.Relative));
                    wall.Width = 25;
                    wall.Height = 25;
                    if (i != 0)
                    {
                        x += 25;
                        if (i % 24 == 0)
                        {
                            y += 25;
                            x = 0;
                        }
                    }
                    Canvas.SetTop(wall, y);
                    Canvas.SetLeft(wall, x);
                    canvas.Children.Add(wall);
                    Rectangle wall1 = new Rectangle();
                    ImageBrush temp = (ImageBrush)this.FindResource("let");
                    temp.Stretch = Stretch.Uniform;
                    wall1.Fill = temp;
                    wall1.Width = 25;
                    wall1.Height = 25;
                    Canvas.SetTop(wall1, y);
                    Canvas.SetLeft(wall1, x);
                    canvas.Children.Add(wall1);

                }
            }
        }
        


        bool IsLetter()
        {
            bool temp = false;
            foreach (var el in canvas.Children)
            {
                try
                {
                    Image my_eliplse = (Image)el;
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
       
        bool IsWallRight()
        {
            int tmpx1 = ((int)Canvas.GetLeft(player) + (int)player.ActualWidth + 1) / 25;
            int tmpx2 = (int)((Canvas.GetLeft(player) + (int)player.ActualWidth - 1) / 25);
            int tmpy = ((int)Canvas.GetTop(player) / 25);
            int tmpy2 = ((int)Canvas.GetTop(player) + (int)player.ActualHeight) / 25;
            if (tmpy>=1)
            {
                tmpx1 += tmpy * 24;
            }
            if (tmpy2 >= 1)
            {

                tmpx2 += tmpy2 * 24;
            }
            try
            {
                if (mymap.map[tmpx1] == 1 || mymap.map[tmpx2] == 1)
                {
                    return true;
                }
            }
            catch { }
            return false;
        }

        bool IsWallLeft()
        {
            int tmpx1 = ((int)Canvas.GetLeft(player) - 1) / 25;
            int tmpx2 = (int)((Canvas.GetLeft(player) - 1) / 25);
            int tmpy = ((int)Canvas.GetTop(player) / 25);
            int tmpy2 = ((int)Canvas.GetTop(player) + (int)player.ActualHeight) / 25;
            if (tmpy >= 1)
            {
                tmpx1 += tmpy * 24;
            }
            if (tmpy2 >= 1)
            {

                tmpx2 += tmpy2 * 24;
            }
            try
            {
                if (mymap.map[tmpx1] == 1 || mymap.map[tmpx2] == 1)
                {
                    return true;
                }
            }
            catch { }
            return false;
        }

        bool IsWallTop()
        {
            int tmpx1 = ((int)Canvas.GetLeft(player)) / 25;
            int tmpx2 = (((int)Canvas.GetLeft(player) + (int)player.ActualWidth) / 25);
            int tmpy = (((int)Canvas.GetTop(player) + (int)player.ActualHeight + 1) / 25);
            if (tmpy >= 1)
            {
                tmpx1 += tmpy * 24;
                tmpx2 += tmpy * 24;
            }
            try
            {
                if (mymap.map[tmpx1] == 1 || mymap.map[tmpx2] == 1)
                {
                    return true;
                }
            }
            catch { }
            return false;
        }

        bool IsWallBottom()
        {
            int tmpx1 = ((int)Canvas.GetLeft(player)) / 25;
            int tmpx2 = (((int)Canvas.GetLeft(player) + (int)player.ActualWidth) / 25);
            int tmpy = ((int)Canvas.GetTop(player) - 1) / 25;
            if (tmpy >= 1)
            {
                tmpx1 += tmpy * 24;
                tmpx2 += tmpy * 24;
            }
            try
            {
                if (mymap.map[tmpx1] == 1 || mymap.map[tmpx2] == 1)
                {
                    return true;
                }
            }
            catch { }
            return false;
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
                            Rectangle my_eliplse = (Rectangle)canvas.Children[i];
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

            if ((e.Key == System.Windows.Input.Key.A || e.Key == System.Windows.Input.Key.Left))
            {
                if (!IsWallLeft())
                {
                    Canvas.SetLeft(player, Canvas.GetLeft(player) - 1);
                }
            }
            if ((e.Key == System.Windows.Input.Key.D || e.Key == System.Windows.Input.Key.Right))
            {       
                if (!IsWallRight())
                {   
                Canvas.SetLeft(player, Canvas.GetLeft(player) + 1);
                }
            }   
            if ((e.Key == System.Windows.Input.Key.W || e.Key == System.Windows.Input.Key.Up))
            {
                if (!IsWallBottom())
                {
                    Canvas.SetTop(player, Canvas.GetTop(player) - 1);
                }
                
            }
            if ((e.Key == System.Windows.Input.Key.S || e.Key == System.Windows.Input.Key.Down))
            {
                if (!IsWallTop())
                {
                    Canvas.SetTop(player, Canvas.GetTop(player) + 1);
                }
            }
        }
    }
}
