using System;
using System.Collections.Generic;
using System.Text;

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

        public Game(ref Menu _menu)
        {
            menu = _menu;
            snake = new Snake();
            grid = new Grid();
            score = 0;
        }

        public void run()
        {
            running = true;
            while(running)
            {
                game_loop();
            }
        }
        public void reset()
        {
            snake = new Snake();
            grid = new Grid();
            score = 0;
        }

        void game_loop()
        {
            snake.move();

            if (snake.segments[0].IsTheSame(fruit.postion))
            {
                snake.addSegment();
                score++;
                spawn_fruit();
            }
            for (int i = 1; i<snake.segments; i++)
            {
                if (snake.segments[0].IsTheSame(snake.segments[i]))
                {
                    end();
                    return;
                }
            }
            if (snake.segments[0].posx = 0)
            {
                end();
                return;
            }
            if (snake.segments[0].posy = 0)
            {
                end();
                return;
            }
            if (snake.segments[0].posx = 16)
            {
                end();
                return;
            }
            if (snake.segments[0].posy = 16)
            {
                end();
                return;
            }
            print();
        }

        void print()
        {
            snake.draw();
            fruit.draw();
            grid.draw();
        }

        void end()
        {
            running = false;
            menu.end(score);
        }

        void spawn_fruit()
        {
            fruit.position = ; // Random position where there is no snake element
        }

    }
}
