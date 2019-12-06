using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SnakeCore
{
    public class SnakeList : ObservableCollection<Segment>
    {
        public new void Add(Segment segment)
        {
            if(Count == 0)
            {
                base.Add(segment);
            }
            else
            {
                this.Last().NextSegment = segment;
                base.Add(segment);
            }
        }

        public SnakeList(int size, int startX, int startY, bool IsHor)
        {
            if (size <= 0) throw new ArgumentOutOfRangeException("Размер змейки не может быть равен нулю");
            Segment head = new Segment() { X = startX, Y = startY };
            Add(head);
            int x = startX;
            int y = startY;
            if (IsHor && size > 1)
            {
                for (int i = 0; i < size - 1; i++)
                {
                    Segment segment = new Segment() { X = x - 1, Y = startY };
                    Add(segment);
                    x--;
                }
            }
            else if(size > 1)
            {
                for (int i = 0; i < size - 1; i++)
                {
                    Segment segment = new Segment() { X = startX, Y = y - 1 };
                    Add(segment);
                    y--;
                }
            }
        }
    }
}
