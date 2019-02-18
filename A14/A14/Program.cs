using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace A14
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck d = new Deck();
            d.Shuffle();
            var tup = Deal(d);
            Play(tup.Item1, tup.Item2);
            Console.ReadLine();
        }

        static Tuple<List<Card>,List<Card>> Deal(Deck deck)
        {
            var list1 = new List<Card>();
            var list2 = new List<Card>();
            for (int i = 0; i < deck.cards.Count; i++)
            {
                if (i % 2 == 0)
                    list1.Add(deck.cards[i]);
                else
                    list2.Add(deck.cards[i]);
            }
            return new Tuple<List<Card>, List<Card>>(list1, list2);
        }
        
        static void Play(List<Card> pile1, List<Card> pile2)
        {
            while (pile1.Count != 0 && pile2.Count != 0)
            {
                
                Console.WriteLine("Spaz #1 " + pile1[0].Value + " vs Spaz #2 " +  pile2[0].Value);
                Card c1 = pile1[0];
                Card c2 = pile2[0];
                int c = CompareRanks(c1.GetRankNum(), c2.GetRankNum());
                if(c==0)
                {
                    Console.WriteLine("Tie! Coinflip incoming!");
                    var r = new Random();
                    int coin = r.Next(1, 3);
                    if (coin == 1)
                        Spaz1Win(pile1, pile2);
                    else
                        Spaz2Win(pile1, pile2);
                }
               else if(c==1)
                    Spaz1Win(pile1, pile2);
               else if (c==2)
                    Spaz2Win(pile1, pile2);
            }
            if (pile1.Count == 0)
                Console.WriteLine("Spaz #2 wins the game!");
            else
                Console.WriteLine("Spaz #1 wins the game!");
        }
        static int CompareRanks(int rank1, int rank2)
        {
            if (rank1 == 6 && rank2 == 14)
                return 1;
            else if (rank2 == 6 && rank1 == 14)
                return 2;
            else if (rank1 > rank2)
                return 1;
            else if (rank2 > rank1)
                return 2;
            else if (rank1 == rank2)
                return 0;
            return -1;
        }

        private static void Spaz1Win(List<Card> pile1, List<Card> pile2)
        {
            Card c1 = pile1[0];
            Card c2 = pile2[0];

            pile1.RemoveAt(0);
            pile2.RemoveAt(0);

            pile1.Add(c1);
            pile1.Add(c2);


            Console.WriteLine("Spaz #1 wins!");
        }
        private static void Spaz2Win(List<Card> pile1, List<Card> pile2)
        {
            Card c1 = pile1[0];
            Card c2 = pile2[0];

            pile2.RemoveAt(0);
            pile1.RemoveAt(0);

            pile2.Add(c1);
            pile2.Add(c2);
            Console.WriteLine("Spaz #2 wins!");

        }
    }
}   
