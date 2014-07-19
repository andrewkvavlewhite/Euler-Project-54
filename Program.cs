using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int player1Wins = 0;
            int player2Wins = 0;
            
            String line;

            System.IO.StreamReader file = new System.IO.StreamReader("poker.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] cards = line.Split(' ');

                Hand player1 = new Hand(cards.Skip(0).Take(5).ToArray());
                Hand player2 = new Hand(cards.Skip(5).Take(5).ToArray());

                Compare game = new Compare(player1, player2);
                int winner = game.play();
                if (winner == 1)
                    player1Wins++;
                else if (winner == 2)
                    player2Wins++;
            }

            file.Close();

            Console.Write("Player1: " + player1Wins + "\nPlayer2: " + player2Wins);
            Console.Read();
        }
    }
}
