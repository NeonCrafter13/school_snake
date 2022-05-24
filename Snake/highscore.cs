using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    struct Highscoredata
    {
        public int highscore { get; set; }
        public string playername { get; set; }
    }
    internal class Highscore
    {        
        public List<Highscoredata> listhighscores { get; set; }

        /*public Highscore(List<Highscoredata> datas)
        {
            listhighscores = datas;
        }*/

        public void add_score(Highscoredata score)
        {
            listhighscores.Add(score);  
        }

        public void sort(List<Highscoredata> list)
        {
            list = listhighscores;

        }

    }
}
