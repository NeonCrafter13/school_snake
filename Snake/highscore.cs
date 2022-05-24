using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Snake
{
    struct Highscoredata
    {
        public int score { get; set; }
        public string name { get; set; }
    }
    internal class Highscore
    {
        public List<Highscoredata> listhighscores { get; set; }

        public Highscore(List<Highscoredata> list)
        {
            listhighscores = list;
        }
        public void add_score(Highscoredata score)
        {
            listhighscores.Add(score);
        }
        public void sort(List<Highscoredata> list)
        {
            list = listhighscores;
            int a = 0;
            while (a < list.Count)
            {
                int minimum = a;
                for (int i = a + 1; i < list.Count; i++)
                {
                    if (list[i].score > list[minimum].score)
                    {
                        minimum = i;
                    }
                }
                Highscoredata temp = list[a];
                list[a] = list[minimum];
                list[minimum] = temp;
                a++;
            }
            listhighscores = list;
        }
        public void txttolisthighscores()
        {
            StreamReader sw = new StreamReader("scores.txt");
            string temp = sw.ReadToEnd();
            string[] array = temp.Split(",");
            List<Highscoredata> list = new List<Highscoredata>();
            int a = 0;
            int b = 1;
            for (int x = 0; x < array.Length / 2; x++)
            {
                Highscoredata c = new Highscoredata();
                c.name = array[a];
                c.score = Convert.ToInt32(array[b]);
                a = a + 2;
                b = b + 2;
                list.Add(c);
            }
            listhighscores = list;
            sw.Close();
        }
        public void bestscores()
        {
            using (StreamWriter sw = new StreamWriter("scores.txt", false))
            {
                for (int x = 0; x < 5; x++)
                {
                    if (x < listhighscores.Count)
                    {
                        sw.Write(listhighscores[x].name + "," + listhighscores[x].score + ",");
                    }
                }
            }
        }
        public void print()
        {
            StreamReader sw = new StreamReader("scores.txt");
            string temp = sw.ReadToEnd();
            string[] array = temp.Split(",");
            int a = 0;
            int b = 1;
            int c = 0;
            for (int x = 1; x < array.Length / 2; x++)
            {
                c = x;
                Console.WriteLine(x + ". " + array[a] + " Score: " + array[b]);
                a = a + 2;
                b = b + 2;
            }
            Console.WriteLine(c + 1 + ". " + array[a] + " Score: " + array[b]);
        }
    }
}
