using SnakeCore;
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

namespace Snake
{
   
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameField Game;
        private Timer gameTimer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            Pause_resumebtn.Visibility = Visibility;
            startbtn.Visibility = Visibility.Collapsed;
            Game = new GameField(45, 30);
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
            rect.Stroke = Brushes.Gray;
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
            
        }

        private void Pause_resumebtn_Click(object sender, RoutedEventArgs e)
        {
            switch (Pause_resumebtn.Content.ToString())
            {
                case "Старт":
                    gameTimer = new Timer(Game.GameTick, null,0, 200);
                    Pause_resumebtn.Content = "Пауза";
                    break;
                case "Пауза":
                    gameTimer.Dispose();
                    Pause_resumebtn.Content = "Возобновить";
                    
                    break;
                case "Возобновить":
                    Pause_resumebtn.Content = "Пауза";
                    gameTimer = new Timer(Game.GameTick, null, 0, 200);
                    break;
            }
        }

       

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    break;
                case Key.Space:
                    Pause_resumebtn_Click(Pause_resumebtn, new RoutedEventArgs());
                    break;
                case Key.Left:
                case Key.A:
                    Game.SetMoveDirection(MoveDirection.Left);
                    break;
                case Key.Up:
                case Key.W:
                    Game.SetMoveDirection(MoveDirection.Up);
                    break;
                case Key.Right:
                case Key.D:
                    Game.SetMoveDirection(MoveDirection.Right);
                    break;
                case Key.Down:
                case Key.S:
                    Game.SetMoveDirection(MoveDirection.Down);
                    break;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if(gameTimer != null) gameTimer.Dispose();
        }
    }
}
