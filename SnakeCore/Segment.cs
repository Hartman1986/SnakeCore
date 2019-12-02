using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SnakeCore
{
    public class Segment : INotifyPropertyChanged
    {
        private int x;
        private int y;
        private int oldx;
        private int oldy;

        public int X
        {
            get => x;
            set
            {
                oldx = x;
                x = value;
                NotifyPropertyChanged("X");
                if(NextSegment != null) NextSegment.X = oldx;
            }
        }
        public int Y
        {
            get => y;
            set
            {
                oldy = y;
                y = value;
                NotifyPropertyChanged("Y");
                if (NextSegment != null) NextSegment.Y = oldy;
            }
        }
        public Segment NextSegment { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Move(MoveDirection md)
        {
            switch (md)
            {
                case MoveDirection.Left:
                    X -= 1;
                    Y = y;
                    break;
                case MoveDirection.Right:
                    X += 1;
                    Y = y;
                    break;
                case MoveDirection.Up:
                    X = x;
                    Y += 1;
                    break;
                case MoveDirection.Down:
                    X = x;
                    Y -= 1;
                    break;
            }
        }
    }
}
