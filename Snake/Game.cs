﻿using System;
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

        public Game(Menu _menu)
        {
            menu = _menu;
            snake = new Snake(ConsoleColor.DarkRed);
            grid = new Grid(25, 25, ConsoleColor.Green);
            fruit = new Fruit(1, 7, 7);
            score = 0;
        }

        public void run()
        {
            running = true;
            while(running)
            {
                Thread.Sleep(500);
                game_loop();
            }
        }
        public void reset()
        {
            snake = new Snake(ConsoleColor.DarkRed);
            grid = new Grid(25, 25, ConsoleColor.Green);
            score = 0;
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
            if (snake.segments[0].posx == 25)
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
        }

        void end()
        {
            running = false;
            menu.end(score);
        }

        
        void spawn_fruit()
        {
            fruit.position = new Vector2d(7, 5); // Random position where there is no snake element
        }
        

    }
}
