using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProblem
{
    class Hand
    {
        public int[] cards = new int[5];
        public bool flush;

        public Hand(string[] cardsRaw)
        {
            HashSet<char> suit = new HashSet<char>();
            for (int i = 0; i < 5; i++)
            {
                suit.Add(cardsRaw[i][cardsRaw[i].Length-1]);
                cardsRaw[i] = cardsRaw[i].Substring(0,cardsRaw[i].Length - 1);
                if (cardsRaw[i] == "A")
                    cards[i] = 14;
                else if (cardsRaw[i] == "K")
                    cards[i] = 13;
                else if (cardsRaw[i] == "Q")
                    cards[i] = 12;
                else if (cardsRaw[i] == "J")
                    cards[i] = 11;
                else if (cardsRaw[i] == "T")
                    cards[i] = 10;
                else
                    cards[i] = Convert.ToInt32(cardsRaw[i]);
            }

            Array.Sort(cards);

            if (suit.Count() == 1)
                flush = true;
            else
                flush = false;
        }
    }
}
