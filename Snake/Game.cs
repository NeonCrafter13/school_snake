using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake
{
    class Game
    {
        private Snake snake;
        private Fruit fruit;
        private int score;
        private Grid grid;
        private Menu menu;
        private bool running;
        private int speed;
        public Game(Menu _menu)
        {
            menu = _menu;
            snake = new Snake(ConsoleColor.DarkRed);
            grid = new Grid(50, 25, ConsoleColor.Green);
            fruit = new Fruit(0, 7, 7);
            score = 0;
            speed = 1;
        }

        public void run()
        {
            running = true;
            while(running)
            {
                Thread.Sleep(150 / speed);
                game_loop();
            }
        }
        public void reset()
        {
            snake = new Snake(ConsoleColor.DarkRed);
            grid = new Grid(50, 25, ConsoleColor.Green);
            score = 0;
            speed = 1;
        }

        void game_loop()
        {
            snake.move();
            
            for (int i = 1; i<snake.segments.Count; i++)
            {
                if (snake.segments[0].IsTheSame(snake.segments[i]))
                {
                    end();
                    return;
                }
            }
            if (snake.segments[0].IsTheSame(fruit.position))
            {
                snake.add_segments();
                score++;
                if (fruit.Get_type() == 1 )
                {
                    speed = 2;
                }
                else
                {
                    speed = 1;
                }
                spawn_fruit();
            }
            
            if (snake.segments[0].posx == 0)
            {
                end();
                return;
            }
            if (snake.segments[0].posy == 0)
            {
                end();
                return;
            }
            if (snake.segments[0].posx == 50)
            {
                end();
                return;
            }
            if (snake.segments[0].posy == 25)
            {
                end();
                return;
            }
            print();
        }

        void print()
        {
            Console.Clear();
            fruit.draw();
            grid.draw();
            snake.draw_segments();
            Console.SetCursorPosition(60, 10);
            Console.WriteLine("Current Score: "+ score);
        }

        void end()
        {
            running = false;
            menu.end(score);
        }

        
        void spawn_fruit()
        {
            Random rnd = new Random();
            fruit = new Fruit(rnd.Next(3), rnd.Next(2, 49), rnd.Next(2, 24));
        }
        

    }
}
