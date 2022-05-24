using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Grid
    {
        public int width { get; set; }
        public int height { get; set; }
        public ConsoleColor gridcolor { get; set; }

        public Grid(int _w, int _h, ConsoleColor _c)
        {
            width = _w;
            height = _h;
            gridcolor = _c;
        }

        public void draw()
        {
            Console.ForegroundColor = gridcolor;
            for (int count = 1; count <= width - 1; count++)
            {
                Console.SetCursorPosition(count, 1);
                Console.WriteLine("--");
            }
            for (int count = 1; count <= height - 1; count++)
            {
                Console.SetCursorPosition(1, count + 1);
                Console.WriteLine("|");
            }
            for (int count = 1; count <= width - 1; count++)
            {
                Console.SetCursorPosition(count, height);
                Console.WriteLine("--");
            }
            for (int count = 1; count <= height - 2; count++)
            {
                Console.SetCursorPosition(width, count + 1);
                Console.WriteLine("|");
            }
        }
    }
}