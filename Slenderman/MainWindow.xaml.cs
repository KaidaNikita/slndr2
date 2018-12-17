﻿using System;
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
using System.Windows.Threading;

namespace Slenderman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player player;
        Slender slender;
        DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        DispatcherTimer dts = new DispatcherTimer();
        static Map mymap = new Map();
        bool Shift = true;

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
            dts.Stop();
            dts.Tick -= new EventHandler(LeftS);
            dts.Tick -= new EventHandler(RightS);
            dts.Tick -= new EventHandler(UpS);
            dts.Tick -= new EventHandler(DownS);
            int tmpx1 = ((int)Canvas.GetLeft(player) / 25);
            int tmpy1 = ((int)Canvas.GetTop(player) / 25);
            int tmpx2 = ((int)Canvas.GetLeft(slender) / 25);
            int tmpy2 = ((int)Canvas.GetTop(slender) / 25);
            Tuple<string[,],int> maptemp = mymap.FindWave(tmpx2, tmpy2, tmpx1, tmpy1);
            int sY=0;
            int sX=0;
            for (int y = 0; y < mymap.MapHeight; y++)
            {
                for (int x = 0; x < mymap.MapWidth; x++)
                {
                    if (maptemp.Item1[y,x] == " S ")
                    {
                        sY = y;
                        sX = x;
                    }
                }
            }
            for (int y = 0; y < mymap.MapHeight; y++)
            {
                for (int x = 0; x < mymap.MapWidth; x++)
                {
                    if (maptemp.Item1[y, x] == (" " + (maptemp.Item2 - 1).ToString() + " "))
                    {
                        if (sY == y)
                        {
                            if (sX > x)
                            {
                                dts.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 25);
                                dts.Tick += new EventHandler(LeftS);
                                dts.Start();

                            }
                            if (sX < x)
                            {
                                dts.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 25);
                                dts.Tick += new EventHandler(RightS);
                                dts.Start();

                            }
                        }
                        else
                        if (sX == x)
                        {
                            if (sY < y)
                            {
                                dts.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 25);
                                dts.Tick += new EventHandler(DownS);
                                dts.Start();

                            }
                            if (sY > y && sX == x)
                            {
                                dts.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 25);
                                dts.Tick += new EventHandler(UpS);
                                dts.Start();

                            }
                        }
                    }
                }
            }
        }

        void DownS(object sender, EventArgs e)
        {
            Canvas.SetTop(slender, Canvas.GetTop(slender) + 1);
        }
        void UpS(object sender, EventArgs e)
        {
            Canvas.SetTop(slender, Canvas.GetTop(slender) - 1);
        }
        void LeftS(object sender, EventArgs e)
        {
            Canvas.SetLeft(slender, Canvas.GetLeft(slender) - 1);
        }
        void RightS(object sender, EventArgs e)
        {
            Canvas.SetLeft(slender, Canvas.GetLeft(slender) + 1);
        }

        void SetSlender()
        {
            slender = new Slender();
            slender.Source = new BitmapImage(new Uri(@"Textures/slender.jpg", UriKind.Relative));
            slender.Height = 20;
            slender.Width = 20;
            slender.Tag = "slender";
            canvas.Children.Add(slender);
            Canvas.SetTop(slender, 100);
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
            for (int i = 0; i < mymap.map.Count; i++)
            {
                
                if (mymap.map[i] == 1)
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
                if (mymap.map[i] == 0)
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
                if (mymap.map[i] == 2)
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
            int tmpx1 = ((int)Canvas.GetLeft(player) + (int)player.ActualWidth + player.speed) / 25;
            int tmpx2 = (int)((Canvas.GetLeft(player) + (int)player.ActualWidth + player.speed) / 25);
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
            int tmpx1 = ((int)Canvas.GetLeft(player) - 2*player.speed) / 25;
            int tmpx2 = (int)((Canvas.GetLeft(player) - player.speed) / 25);
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

        bool IsWallBottom()
        {
            int tmpx1 = ((int)Canvas.GetLeft(player)) / 25;
            int tmpx2 = (((int)Canvas.GetLeft(player) + (int)player.ActualWidth) / 25);
            int tmpy = (((int)Canvas.GetTop(player) + (int)player.ActualHeight + player.speed) / 25);
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

        bool IsWallTop()
        {
            int tmpx1 = ((int)Canvas.GetLeft(player)) / 25;
            int tmpx2 = (((int)Canvas.GetLeft(player) + (int)player.ActualWidth) / 25);
            int tmpy = ((int)Canvas.GetTop(player)-player.speed*2) / 25;
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

        void SpeederC(object sender, EventArgs e)
        {
            byte t = 1;
            Speeder.Value -= 1;
            if ((Speeder.Foreground as SolidColorBrush).Color.R < (byte)255)
            {
                Speeder.Foreground = new SolidColorBrush(Color.FromRgb((byte)((Speeder.Foreground as SolidColorBrush).Color.R + t), (Speeder.Foreground as SolidColorBrush).Color.G, (Speeder.Foreground as SolidColorBrush).Color.B));
            }
            if ((Speeder.Foreground as SolidColorBrush).Color.R == (byte)255)
            {
                Speeder.Foreground = new SolidColorBrush(Color.FromRgb((Speeder.Foreground as SolidColorBrush).Color.R, (byte)((Speeder.Foreground as SolidColorBrush).Color.G - t), (Speeder.Foreground as SolidColorBrush).Color.B));
            }
            if (Speeder.Value == 0)
            {
                (sender as DispatcherTimer).Stop();
                Speeder.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                UpdateSpeeder();
            }
        }

        void SpeederC1(object sender, EventArgs e)
        {
            byte t = 1;
            Speeder.Value += 1;
            if ((Speeder.Foreground as SolidColorBrush).Color.G < (byte)255)
            {
                Speeder.Foreground = new SolidColorBrush(Color.FromRgb((Speeder.Foreground as SolidColorBrush).Color.R, (byte)((Speeder.Foreground as SolidColorBrush).Color.G + t), (Speeder.Foreground as SolidColorBrush).Color.B));
            }
            if ((Speeder.Foreground as SolidColorBrush).Color.G == (byte)255)
            {
                Speeder.Foreground = new SolidColorBrush(Color.FromRgb((byte)((Speeder.Foreground as SolidColorBrush).Color.R - t), (Speeder.Foreground as SolidColorBrush).Color.G, (Speeder.Foreground as SolidColorBrush).Color.B));
            }
            
            if (Speeder.Value == 510)
            {
                Speeder.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                (sender as DispatcherTimer).Stop();
                Shift = true;
            }
        }

        void UpdateSpeeder()
        {
            player.speed = 1;
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, (int)(16000 / 510));
            dt.Tick += new EventHandler(SpeederC1);
            dt.Start();
        }

        private void Moving(object sender, KeyEventArgs e)
        {
            if (Shift == true)
            {
                if (e.Key == System.Windows.Input.Key.LeftShift || e.Key == System.Windows.Input.Key.LeftShift)
                {
                    player.speed = 2;
                    DispatcherTimer dt = new DispatcherTimer();
                    dt.Interval = new TimeSpan(0, 0, 0, 0, (int)(8000 / 510));
                    dt.Tick += new EventHandler(SpeederC);
                    dt.Start();
                    Shift = false;
                }
            }
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
                    Canvas.SetLeft(player, Canvas.GetLeft(player) - player.speed);
                }
            }
            if ((e.Key == System.Windows.Input.Key.D || e.Key == System.Windows.Input.Key.Right))
            {       
                if (!IsWallRight())
                {
                    Canvas.SetLeft(player, Canvas.GetLeft(player) + player.speed);
                }
            }   
            if ((e.Key == System.Windows.Input.Key.W || e.Key == System.Windows.Input.Key.Up))
            {
                if (!IsWallTop())
                {
                    Canvas.SetTop(player, Canvas.GetTop(player) - player.speed);
                }
                
            }
            if ((e.Key == System.Windows.Input.Key.S || e.Key == System.Windows.Input.Key.Down))
            {
                if (!IsWallBottom())
                {
                    Canvas.SetTop(player, Canvas.GetTop(player) + player.speed);
                }
            }
        }
    }
}
