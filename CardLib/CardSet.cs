using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLib
{
    public class CardSet: IEnumerable<Card>
    {

        private static readonly Random random = new Random();
        private List<Card> cards = new List<Card>();
        
        public int Count { get => cards.Count; }
        public Card LastCard { get => cards[cards.Count - 1]; }

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
            for (int j = 0; j < 5; j++)
            {

                for (int i = 0; i < Count; i++)
                {
                    int randNum = random.Next(Count);
                    Card temp = cards[i];
                    cards[i] = cards[randNum];
                    cards[randNum] = temp;
                }
            }
        }
        public Card Pull(Card equalsCard)
        {
            Card foundCard = cards.FirstOrDefault(c => c.Equals(equalsCard));
            if (foundCard != null) Remove(foundCard);
            return foundCard;
        }
        public Card Pull(int index = 0)
        {
            if (index < 0 || index >= Count)
                return null;
            Card card = cards[index];
            Remove(index);
            return card;
        }
        public CardSet Deal(int countOfCards)  
        {
            if (countOfCards < 0)
            {
                throw new Exception("Count of card to deal must be greater than zero");
            }
            if (countOfCards > Count) countOfCards = Count;
            CardSet CardSetInHand = new CardSet();

            for (int i = 0; i < countOfCards; i++)
            {
                CardSetInHand.Add(Pull());      
            }

            return CardSetInHand;
        }
        public void Sort()
        {
            cards.Sort((card1, card2) => card1.Rank.CompareTo(card2.Rank) == 0 ?
                                              card1.Suit.CompareTo(card2.Suit) :
                                              card1.Rank.CompareTo(card2.Rank));
        }
        public void Add(CardSet CardSet)
        {
            foreach (var card in CardSet)
            {
                cards.Add(card);
            }
        }
        public void Add(params Card[] cards)
        {
            this.cards.AddRange(cards);
        }
        public void Add(List<Card> cards)
        {
            Add(cards.ToArray());
                       
        }
        public virtual void Remove(Card card)
        {
            cards.Remove(card);
        }
        public void Remove(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("Incorrect index");
            Remove(cards[index]);
        }
        public void RemoveRange(int startIndex, int length)
        {
            for (int i = startIndex; i < startIndex + length; i++)
            {
                Remove(cards[i]);
            }
        }
        public void CutTo(int countOfCards) 
        {
            while (Count > countOfCards)
                Remove(0);
        }
        public void Clear()
        {
            CutTo(0);
        }
        public void Full(int countOfCards)
        {
            Full();
            CutTo(countOfCards);
        }
        public void Full()
        {
            foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                { 
                    foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                    {
                        cards.Add(new Card(rank, suit));
                    }
                }
            
        }

        public IEnumerator<Card> GetEnumerator() => cards.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => cards.GetEnumerator();
    }
}