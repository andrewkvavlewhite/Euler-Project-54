using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProblem
{
    class Compare
    {
        public Hand p1;
        public Hand p2;

        public Compare(Hand player1, Hand player2)
        {
            p1 = player1;
            p2 = player2;
        }

        public int play()
        {
            int player1Score = getHandValue(p1);
            int player2Score = getHandValue(p2);

            if (player1Score > player2Score)
                return 1;
            else if (player2Score > player1Score)
                return 2;
            else
                return highCard(p1, p2);
        }

        private int getHandValue(Hand hand)
        {
            double score = 0;

            int[] array = new int[15];

            Array.Clear(array, 0, array.Count());

            for (int i = 0; i < hand.cards.Count(); i++)
            {
                array[hand.cards[i]]++;
            }

            int pairMultiplier = 1;
            for (int i = 0; i < array.Count(); i++)
            {
                score += Math.Pow(10, array[i]);

                if (array[i] == 2)
                {
                    score += i-1 * pairMultiplier;
                    pairMultiplier = 15;
                }
                if (array[i] > 2)
                {
                    score += i-1 * 15;
                }
            }

            if (score == 60)
            {
                if (hand.cards[4] - hand.cards[0] == 4)
                    score = 1050;

                if (hand.flush)
                    score *= 18;
            }

            return (int)score;
        }

        private int highCard(Hand p1, Hand p2)
        {
            for (int i = 4; i >= 0; i--)
            {
                if (p1.cards[i] > p2.cards[i])
                    return 1;
                if (p2.cards[i] > p1.cards[i])
                    return 2;
            }

            return 0;
        }
    }
}
