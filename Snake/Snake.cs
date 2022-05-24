
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    class Snake
    {

        public List<Vector2d> segments { get; set; }
        public ConsoleColor snakecolor { get; set; }

        public string shape { get; set; }

        private Direction direction;

        public Snake(ConsoleColor _color)
        {
            snakecolor = _color;
            segments = new List<Vector2d> {
                new Vector2d(5, 5)
            };
            direction = Direction.Down;
            shape = "#";
        }


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
        public void add_segments()
        {
            segments.Add(new Vector2d(segments.Last().posx, segments.Last().posy));
        }

        public void move()
        {
            if (Console.KeyAvailable) {
                var command = Console.ReadKey().Key;
                switch (command)
                {
                    case ConsoleKey.DownArrow:
                        direction = Direction.Down;
                        break;
                    case ConsoleKey.UpArrow:
                        direction = Direction.Up;
                        break;
                    case ConsoleKey.LeftArrow:
                        direction = Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        direction = Direction.Right;
                        break;
                    default:
                        break;
                }
            }
            
            switch (direction)
            {
                case Direction.Up:
                    segments[0].posy--;
                    break;
                case Direction.Down:
                    segments[0].posy++;
                    break;
                case Direction.Left:
                    segments[0].posx--;
                    break;
                case Direction.Right:
                    segments[0].posx++;
                    break;
            }

            move_segments();
        }
        public void draw_segments()
        {
            for (int i = 0; i < segments.Count; i++)
            {
                draw(segments[i].posx, segments[i].posy);
            }
        }
    }
}
