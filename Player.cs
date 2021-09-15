using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Player
    {
        private bool turn;
        private int score;
        private String name;
        private String letter;

        public String Letter
        {
            get { return letter; }
            set { letter = value; }
        }

        public bool Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        public int Score
        {
            get { return score; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public Player(bool yourTurn, String yourName)
        {
            turn = yourTurn;
            name = yourName;
            score = 0;
        }

        public void UpdateScore(bool reset)
        {
            score++;

            if (reset)
                score = 0;
        }
    }
}
