using System.Collections.Generic;
using System;

namespace Snake {
    class Menu {
        private Game game;
        private Highscore highscore;
        private string current_player; 

        public Menu()
        {
            game = new Game(this);
            List<Highscoredata> a = new List<Highscoredata>();
            highscore = new Highscore(a);
            highscore.txttolisthighscores();
        }

        private void start()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            if(name == "")
            {
                name = "Unknown Player";
            }
            current_player = name;           
            game.run();
        }
        public void end(int score)
        {
            Highscoredata highscoredata = new Highscoredata();
            highscoredata.score = score;
            highscoredata.name = current_player;
            highscore.add_score(highscoredata);
            highscore.sort();
            highscore.bestscores();
            game.reset();
            input(true);
        }

        private void print_row()
        {
            int w = Console.WindowWidth;
            for (int i = 0; i<w; i++) {
                Console.Write("-");
            }
            Console.Write("\n");
        }

        public void input(bool select)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            print(select);
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.UpArrow) {
                select = !select;
                input(select);
            }
            else if (key == ConsoleKey.DownArrow)
            {
                select = !select;
                input(select);
            }
            else if (key == ConsoleKey.Enter) {
                if (select == true) {
                    start();
                }
            }
            else {
                input(select);
            }

        }

        private void print(bool select)
        {
            Console.WriteLine(@"
 ____              _
/ ___| _ __   __ _| | _____
\___ \| '_ \ / _` | |/ / _ \
 ___) | | | | (_| |   <  __/
|____/|_| |_|\__,_|_|\_\___|
            ");
            highscore.print();

            int w = Console.WindowWidth;
            print_row();
            int x_pos = (w / 2) - 2;
            Console.Write("|");
            if (select == true){
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            for (int i = 1; i<w-1; i++)
            {
                if (i == x_pos) 
                {
                    Console.Write("P");
                }
                else if (i == x_pos + 1)
                {
                    Console.Write("l");
                }
                else if (i == x_pos + 2)
                {
                    Console.Write("a");
                }
                else if (i == x_pos + 3)
                {
                    Console.Write("y");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("|");
            print_row();

            print_row();
            x_pos = (w / 2) - 2;
            Console.Write("|");

            if (select == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            for (int i = 1; i < w - 1; i++)
            {
                if (i == x_pos)
                {
                    Console.Write("E");
                }
                else if (i == x_pos + 1)
                {
                    Console.Write("x");
                }
                else if (i == x_pos + 2)
                {
                    Console.Write("i");
                }
                else if (i == x_pos + 3)
                {
                    Console.Write("t");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("|");
            print_row();

        }

    }
}