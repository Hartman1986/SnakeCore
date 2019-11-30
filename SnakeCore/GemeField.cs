using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SnakeCore
{
    public class GemeField
    {
        private Timer GameTurn;
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public SnakeList Snake { get; set; }

        public GemeField(int x, int y)
        {
            SizeX = x;
            SizeY = y;
            GameTurn = new Timer();
            Snake = new SnakeList();
        }

        public void Start(int speed)
        {
            
        }
    }
}
