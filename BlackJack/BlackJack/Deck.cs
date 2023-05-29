using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {
        private List<Card> cards = new List<Card>();

        public Deck()
        {
            foreach (Card.ESuit suit in Enum.GetValues(typeof(Card.ESuit)))
            {
                foreach (Card.EFace face in Enum.GetValues(typeof(Card.EFace)))
                {
                    cards.Add(new Card { Suit = suit, Face = face });
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();

            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card DealCard()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }

}
