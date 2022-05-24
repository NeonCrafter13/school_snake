namespace Snake {
    class Menu {
        private Game game;
        private Highscore highscore;
        private string current_player;

        public Menu()
        {
            game = new Game(this);
            highscore = new Highscore();
        }

        public void start()
        {
            game.run();
        }
        public void end(int score)
        {
            Highscoredata highscoredata = new Highscoredata();
            highscoredata.highscore = score;
            highscoredata.playername = "TEST";
            highscore.add_score(highscoredata);
            game.reset();
            
        }
        public void print()
        {

        }

    }
}