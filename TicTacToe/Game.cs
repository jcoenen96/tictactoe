using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace TicTacToe
{
    public class Game
    {
        private int[] turns;
        public int[] Turns
        {
            get { return this.turns; }
            set { this.turns = value; }
        }

        public Game(int[] _turns)
        {
            this.turns = _turns;
        }

        public int NextMove()
        {
            for(int x = 1; x > -1; x--)
            {
                //horizontaal checken
                for (int i = 0; i < 9; i = i + 3)
                {
                    if (this.turns[i] == x && this.turns[i + 1] == x && this.turns[i + 2] == -1)
                    {
                        return i + 2;
                    }
                    if (this.turns[i] == -1 && this.turns[i + 1] == x && this.turns[i + 2] == x)
                    {
                        return i;
                    }
                    if (this.turns[i] == x && this.turns[i + 1] == -1 && this.turns[i + 2] == x)
                    {
                        return i + 1;
                    }
                }
                
                //verticaal checken
                for (int i = 0; i < 3; i++)
                {
                    if (this.turns[i] == x && this.turns[i + 3] == x && this.turns[i + 6] == -1)
                    {
                        return i + 6;
                    }
                    if (this.turns[i] == -1 && this.turns[i + 3] == x && this.turns[i + 6] == x)
                    {
                        return i;
                    }
                    if (this.turns[i] == x && this.turns[i + 3] == -1 && this.turns[i + 6] == x)
                    {
                        return i + 3;
                    }
                }

                //schuin checken
                if (this.turns[0] == x && this.turns[4] == x && this.turns[8] == -1)
                {
                    return 8;
                }
                if (this.turns[0] == -1 && this.turns[4] == x && this.turns[8] == x)
                {
                    return 0;
                }
                if (this.turns[0] == x && this.turns[4] == -1 && this.turns[8] == x)
                {
                    return 4;
                }
                if (this.turns[3] == x && this.turns[4] == x && this.turns[6] == -1)
                {
                    return 6;
                }
                if (this.turns[3] == -1 && this.turns[4] == x && this.turns[6] == x)
                {
                    return 3;
                }
                if (this.turns[3] == x && this.turns[4] == -1 && this.turns[6] == x)
                {
                    return 6;
                }
            }

            int amountOfTurns = 0;
            foreach(int i in this.turns)
            {
                if(i != -1)
                {
                    amountOfTurns++;
                }
            }

            if(amountOfTurns == 1 && (this.turns[0] == 0 || this.turns[2] == 0 || this.turns[6] == 0 || this.turns[8] == 0))
            {
                return 4;
            }
            if(amountOfTurns == 3 && ((this.turns[0] == 0 && this.turns[8] == 0) || (this.turns[2] == 0 && this.turns[6] == 0)))
            {
                int[] possibleActions =
                {
                    1,
                    3,
                    5,
                    7
                };
                Random rnd = new Random();
                return possibleActions[rnd.Next(0, 4)];
            }
            return -1;
        }

        public int WinCheck()
        {
            if ((this.turns[0] == 0 && this.turns[1] == 0 && this.turns[2] == 0) ||
                (this.turns[3] == 0 && this.turns[4] == 0 && this.turns[5] == 0) ||
                (this.turns[6] == 0 && this.turns[7] == 0 && this.turns[8] == 0) ||
                (this.turns[0] == 0 && this.turns[3] == 0 && this.turns[6] == 0) ||
                (this.turns[1] == 0 && this.turns[4] == 0 && this.turns[7] == 0) ||
                (this.turns[2] == 0 && this.turns[5] == 0 && this.turns[8] == 0) ||
                (this.turns[0] == 0 && this.turns[4] == 0 && this.turns[8] == 0) ||
                (this.turns[2] == 0 && this.turns[4] == 0 && this.turns[6] == 0))
            {
                return 0;
            }
            if ((this.turns[0] == 1 && this.turns[1] == 1 && this.turns[2] == 1) ||
               (this.turns[3] == 1 && this.turns[4] == 1 && this.turns[5] == 1) ||
               (this.turns[6] == 1 && this.turns[7] == 1 && this.turns[8] == 1) ||
               (this.turns[0] == 1 && this.turns[3] == 1 && this.turns[6] == 1) ||
               (this.turns[1] == 1 && this.turns[4] == 1 && this.turns[7] == 1) ||
               (this.turns[2] == 1 && this.turns[5] == 1 && this.turns[8] == 1) ||
               (this.turns[0] == 1 && this.turns[4] == 1 && this.turns[8] == 1) ||
               (this.turns[2] == 1 && this.turns[4] == 1 && this.turns[6] == 1))
            {
                return 1;
            }
            return -1;
        }

        public bool DrawCheck()
        {
            if (!this.turns.Contains(-1))
            {
                return true;
            }
            return false;
        }
        
    }
}
