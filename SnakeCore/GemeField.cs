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
        
        private Timer GameTurn;
        public MoveDirection CurrentMoveDirection { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public SnakeList Snake { get; set; }


        public GameField(int x, int y)
        {
            SizeX = x;
            SizeY = y;
            GameTurn = new Timer();
            Snake = new SnakeList(3, 5, (int)SizeY/2, true);
            CurrentMoveDirection = MoveDirection.Right;
            
        }

        public void Start(int speed)
        {
            if (speed == 0) speed = 1;
            GameTurn.Interval = 1000 / speed;
            GameTurn.Enabled = true;
            GameTurn.Elapsed += Game_cycle;
        }

        private void Game_cycle(object sender, ElapsedEventArgs e)
        {
            Segment head = Snake.FirstOrDefault();
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

        public void Pause()
        {
            GameTurn.Enabled = false;
        }

        public void Resume()
        {
            GameTurn.Enabled = true;
        }
    }
}
