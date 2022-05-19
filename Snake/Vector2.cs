using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Vector2d
    {
        public int posx { get; set; }
        public int posy { get; set; }

        public bool IsTheSame(Vector2d _o)
        {
            if (posx == _o.posx && posy == _o.posy)
            {
                return true;
            }
            return false;
        }

        public void update_x(int amount)
        {
            posx += amount;
        }

        public void update_y(int amount)
        {
            posy += amount;
        }

        public Vector2d(int _x, int _y)
        {
            posx = _x;
            posy = _y;
        }
    }
}
