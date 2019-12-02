using SnakeCore;
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

namespace Snake
{
   
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameField Game;
        public MainWindow()
        {
            InitializeComponent();
            //GameField Game = new GameField(20, 10);

        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            Pause_resumebtn.Visibility = Visibility;
            Game = new GameField(40, 20);
            foreach (var item in Game.Snake)
            {
                CreateRect(item);
            }
            Game.Snake.CollectionChanged += Snake_CollectionChanged;

        }

        private void Snake_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add) {
                CreateRect(e.NewItems[0] as Segment);
            }
        }

        private void CreateRect(Segment segm)
        {
            Rectangle rect = new Rectangle();
            rect.Fill = Brushes.Black;
            rect.Width = field.ActualWidth / Game.SizeX;
            rect.Height = field.ActualHeight / Game.SizeY;

            Binding bindX = new Binding();
            bindX.Converter = new CoordConverter();
            bindX.ConverterParameter = new int[] { (int)field.ActualWidth / Game.SizeX };
            bindX.Source = segm;
            bindX.Path = new PropertyPath("X");
            rect.SetBinding(Canvas.LeftProperty, bindX);


            Binding bindY = new Binding();
            bindY.Converter = new CoordConverter();
            bindY.ConverterParameter = new int[] { (int)field.ActualHeight / Game.SizeY };
            bindY.Source = segm;
            bindY.Path = new PropertyPath("Y");
            rect.SetBinding(Canvas.BottomProperty, bindY);
            
            field.Children.Add(rect);
        }

        private void field_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //foreach (var item in field.Children)
            //{
            //    if(item is Rectangle)
            //    {
            //        Rectangle rect = item as Rectangle;
            //        rect.Width = field.ActualWidth / Game.SizeX;
            //        rect.Height = field.ActualHeight / Game.SizeY;
            //        Canvas.SetLeft(rect, +field.ActualWidth / Game.SizeX);
            //        Canvas.SetBottom(rect, field.ActualHeight / Game.SizeY);
            //    }
            //}
        }

        private void Pause_resumebtn_Click(object sender, RoutedEventArgs e)
        {
            switch (Pause_resumebtn.Content.ToString())
            {
                case "Старт":
                    startbtn.Visibility = Visibility.Collapsed;
                    Game.Start(5);
                    Pause_resumebtn.Content = "Пауза";
                    break;
                case "Пауза":
                    Pause_resumebtn.Content = "Возобновить";
                    Game.Pause();
                    break;
                case "Возобновить":
                    Pause_resumebtn.Content = "Пауза";
                    Game.Resume();
                    break;
            }

        }
    }
}
