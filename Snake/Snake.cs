
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {

        public List<Vector2d> segments { get; set; }
        public ConsoleColor snakecolor { get; set; }

        public string shape { get; set; }

        public void draw(int x, int y)
        {
            Console.ForegroundColor = snakecolor;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(shape);
        }
        public void move_segments()
        {
            for (int i = segments.Count; i > 1; i--)
            {
                segments[i - 1] = segments[i - 2];

            }
        }
        public void add_segments(Vector2d v)
        {
            segments.Add(v);
        }

        public void move()
        {
            var command = Console.ReadKey().Key;
            switch (command)
            {
                case ConsoleKey.DownArrow:
                    segments[0].posy++;
                    break;                                                  //Snake  muss noch mit Directions move,mache ich Dienstag.
                case ConsoleKey.UpArrow:
                    segments[0].posy--;
                    break;
                case ConsoleKey.LeftArrow:
                    segments[0].posx--;
                    break;
                case ConsoleKey.RightArrow:
                    segments[0].posx++;
                    break;
                default:
                    break;
            }
        }
        public void draw_segments()
        {
            for (int i = 0; i <= (segments.Count - 1); i++)
            {
                draw(segments[i].posx, segments[i].posy);
            }
        }
    }
}
