using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace A14
{
    class Card
    {
        public string Value;
        public char Rank;
        public char Suit;

        public Card(string v)
        {
            Value = v;
            Rank = v[0];
            Suit = v[1];
        }

       public int GetRankNum()
        {
            switch (Rank)
            {
                case '6':return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                case 'J': return 11;
                case 'Q': return 12;
                case 'K': return 13;
                case 'A': return 14;
                case '1':  return 10;
                default: throw new Exception("spaz");
            }
        }
        

    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = CreateDeck();
            var tup = Deal(list);
            Play(tup.Item1, tup.Item2);
            Console.ReadLine();
        }
        static List<Card> CreateDeck()
        {
            string[] suits = new string[] { "S", "H", "C", "D", };
            string[] ranks = new string[] { "6", "7", "8", "9", "1", "J", "Q", "K", "A" };
            var list = new List<Card>();
            for (int i = 0; i < ranks.Length; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    Card c = new Card(ranks[i] + suits[j]);
                    list.Add(c);
                }
            }
            return list;
        }
        static void Shuffle(List<Card> deck)
        {
            for (int i = 0; i < deck.Count; i++)
            {
                var r = new Random();
                Card temp = deck[i];
                int randomIndex = r.Next(i, deck.Count);
                deck[i] = deck[randomIndex];
                deck[randomIndex] = temp;
            }
            Console.WriteLine();
        }
        static Tuple<List<Card>,List<Card>> Deal(List<Card> deck)
        {
            Shuffle(deck);
            var list1 = new List<Card>();
            var list2 = new List<Card>();
            for (int i = 0; i < deck.Count; i++)
            {
                if (i % 2 == 0)
                    list1.Add(deck[i]);
                else
                    list2.Add(deck[i]);
            }
            return new Tuple<List<Card>, List<Card>>(list1, list2);
        }
        static void ShowDeck(List<Card> deck)
        {
            for (int i = 0; i < deck.Count; i++)
            {
                Console.Write(deck[i].Rank);
                Console.WriteLine(deck[i].Suit);
            }
        }
        static void Play(List<Card> pile1, List<Card> pile2)
        {
            int i = 0;
            while (pile1.Count != 0 || pile2.Count != 0)
            {
                Console.WriteLine("Spaz #1 " + pile1[i] + " vs Spaz #2 " + pile2[i]);
                if (pile1[i].GetRankNum() > pile2[i].GetRankNum())
                    Spaz1Win(pile1, pile2, i);
                else if (pile2[i].GetRankNum() > pile1[i].GetRankNum())
                    Spaz2Win(pile1, pile2, i);
                else if (pile2[i].GetRankNum() == pile1[i].GetRankNum())
                {
                    Console.WriteLine("Tie! Coinflip incoming!");
                    var r = new Random();
                    int coin = r.Next(1, 3);
                    if (coin == 1)
                        Spaz1Win(pile1, pile2, i);
                    else
                        Spaz2Win(pile1, pile2, i);
                }
                else if (pile1[i].GetRankNum() == 6 && pile2[i].GetRankNum() == 14)
                    Spaz1Win(pile1, pile2, i);
                else if (pile2[i].GetRankNum() == 6 && pile1[i].GetRankNum() == 14)
                    Spaz2Win(pile1, pile2, i);
                i++;
            }
        }

        private static void Spaz1Win(List<Card> pile1, List<Card> pile2, int i)
        {
            pile1.Add(pile2[i]);
            pile2.Remove(pile2[i]);
            Console.WriteLine("Spaz #1 wins!");
        }
        private static void Spaz2Win(List<Card> pile1, List<Card> pile2, int i)
        {
            pile2.Add(pile1[i]);
            pile1.Remove(pile1[i]);
            Console.WriteLine("Spaz #2 wins!");
        }
    }
}   
