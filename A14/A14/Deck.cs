using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A14
{
    class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            cards = CreateDeck();
        }

        List<Card> CreateDeck()
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

        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                var r = new Random();
                Card temp = cards[i];
                int randomIndex = r.Next(i, cards.Count);
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }
        }

        public void Show()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Console.Write(cards[i].Rank);
                Console.WriteLine(cards[i].Suit);
            }
        }



    }
}
