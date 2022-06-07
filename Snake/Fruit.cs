using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Fruit
    {
        private int type;
        public string shape;
        public ConsoleColor fruitcolour;

        public Vector2d position;

        public Fruit(int Typ, int _x, int _y)
        {
            type = Typ;
            switch (type)
            {
                case 0:
                    shape = "%";
                    fruitcolour = ConsoleColor.Blue;
                    break;
                case 1:
                    shape = "#";
                    fruitcolour = ConsoleColor.Green;
                    break;
                case 2:
                    shape = "Y";
                    fruitcolour = ConsoleColor.Yellow;
                    break;
                case 3:
                    shape = "X";
                    fruitcolour = ConsoleColor.Magenta;
                    break;

            }

            position = new Vector2d(_x, _y);
        }

        public int Get_type()
        {
            return type;
        }
        public string Get_shape()
        {
            return shape;
        }
        public ConsoleColor Get_fruitcolour()
        {
            return fruitcolour;
        }

        public void draw()
        {
            Console.ForegroundColor = fruitcolour;
            Console.SetCursorPosition(position.posx, position.posy);
            Console.WriteLine(shape);
        }

    }
}
