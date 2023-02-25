using System;
using System.Collections.Generic;
using System.Text;

namespace CardLib
{
    internal class CardSet
    {

        private static readonly Random random = new Random();
        private List<Card> cards = new List<Card>();
        

        public CardSet()
        {
        }
        public CardSet(params Card[] cards)
        {
            this.cards = new List<Card>(cards);
        }
        public CardSet(List<Card> cards)
        {
            this.cards = new List<Card>(cards);
        }
        
        public Card this[int i]
        {
            get => cards[i];
            set => cards[i] = value;
        }

        public void Shuffle()
        {
            int n = cards.Count;

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card card = cards[k];
                cards[k] = cards[n];
                cards[n] = card;
            }
        }
        public CardSet Deal(int countOfCards)  
        {
            
            CardSet CardSetInHand = new CardSet();

            for (int i = 0; i < countOfCards; i++)
            {
                if (cards.Count > 0)
                {
                    Card card = cards[0];
                    cards.RemoveAt(0);
                    CardSetInHand.Add(card);
                }
                else
                    break;
              
            }

            return CardSetInHand;
        }
        public void Sort()
        {
            cards.Sort(new CardComparer());
        }
        public void SortCardSet()
        {
            cards.Sort((card1, card2) => card1.Rank.CompareTo(card2.Rank));
        }
        public Card Pull(Card card)
        {
            Remove(card);
            return card;
        }
        public Card Pull(int index)
        {
            Card card = cards[index];
            cards.RemoveAt(index);
            return card;
        }
        public void Add(CardSet Cards)
        {
            Add(Cards.cards);
        }
        public void Add(params Card[] cards)
        {
            
            for (int i = 0; i < cards.Length; i++)
            {
                this.cards.Add(cards[i]);
            }
        }
        public void Add(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                this.cards[this.cards.Count + i] = cards[i];
            }
            
        }
        public void Remove(Card card)
        {
            cards.Remove(card);
        }
        public void Remove(int index)
        {
            cards.RemoveAt(index);
        }
        public void RemoveRange(int startIndex, int length)
        {
            cards.RemoveRange(startIndex, length);
        }
        public void Clear()
        {
            cards.Clear();
        }
        public void Full(int countOfCards)
        {
            for (int i = 0; i < countOfCards; i++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                    {
                        cards.Add(new Card(rank, suit));
                    }
                }
            }
        }
    }
}