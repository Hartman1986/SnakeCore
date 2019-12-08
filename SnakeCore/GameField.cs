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
        public event Action GameOver;
        private bool isGameOver = false;


        public GameField(int x, int y)
        {
            SizeX = x;
            SizeY = y;
            Snake = new SnakeList(3, 5, (int)SizeY/2, true);
            CurrentMoveDirection = MoveDirection.Right;
            
        }
        
        public void GameTick(object state)
        {
            if (isGameOver) return;
            Segment head = Snake.First();
            head.Move(CurrentMoveDirection);

            if (head.X < 0 || head.Y < 0 || head.X > SizeX - 1 || head.Y > SizeY - 1)
            {
                GameOver?.Invoke();
                isGameOver = true;

            }
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
