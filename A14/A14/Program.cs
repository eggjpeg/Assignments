using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                default:  return 10;
            }
        }
        List<Card> CreateDeck()
        {
            char[] suits = new[] { 'S', 'H', 'C', 'D', };

            for (int i = 0; i < length; i++)
            {

            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
       
    }
}
