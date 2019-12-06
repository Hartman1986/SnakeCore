using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SnakeCore
{
    public class GameField
    {
        public MoveDirection CurrentMoveDirection { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public SnakeList Snake { get; set; }


        public GameField(int x, int y)
        {
            SizeX = x;
            SizeY = y;
            Snake = new SnakeList(3, 5, (int)SizeY/2, true);
            CurrentMoveDirection = MoveDirection.Right;
            
        }
        
        public void GameTick(object state)
        {
            Segment head = Snake.First();
            head.Move(CurrentMoveDirection);
        }

        public void SetMoveDirection(MoveDirection md)
        {
            if (md == CurrentMoveDirection) return;
            switch (md)
            {
                case MoveDirection.Left:
                    if (CurrentMoveDirection == MoveDirection.Right) break;
                    CurrentMoveDirection = md;
                    break;
                case MoveDirection.Right:
                    if (CurrentMoveDirection == MoveDirection.Left) break;
                    CurrentMoveDirection = md;
                    break;
                case MoveDirection.Up:
                    if (CurrentMoveDirection == MoveDirection.Down) break;
                    CurrentMoveDirection = md;
                    break;
                case MoveDirection.Down:
                    if (CurrentMoveDirection == MoveDirection.Up) break;
                    CurrentMoveDirection = md;
                    break;
            }
        }
    }
}
