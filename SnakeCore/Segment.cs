using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SnakeCore
{
    public class Segment : INotifyPropertyChanged
    {
        private int x;
        private int y;
        private Segment nextSegment;

        public int X
        {
            get => x;
            set
            {
                x = value;
                NotifyPropertyChanged("X");
            }
        }
        public int Y
        {
            get => y;
            set
            {
                y = value;
                NotifyPropertyChanged("Y");
            }
        }
        public Segment NextSegment { 
            get => nextSegment;
            set { 
                nextSegment = value;
                
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Move(MoveDirection md)
        {
            switch (md)
            {
                case MoveDirection.Left:
                    X -= 1;
                    break;
                case MoveDirection.Right:
                    X += 1;
                    break;
                case MoveDirection.Up:
                    Y += 1;
                    break;
                case MoveDirection.Down:
                    Y -= 1;
                    break;
            }
        }
    }
}
