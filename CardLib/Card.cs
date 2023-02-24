using System;
using System.Collections.Generic;

namespace CardLib
{
    public class Card
    {
        private static Dictionary<Rank, string> strRanks = new Dictionary<Rank, string>() { };
        private static Dictionary<Suit, string> strSuit = new Dictionary<Suit, string>()
        {
            [Suit.Club] = "♣️",
            [Suit.Diamond] = "♦️",
            [Suit.Spade] = "♠️",
            [Suit.Heart] = "♥️"
        };
        static Card()
        {
            for (int i = 2; i <= 10; i++)
            {
                strRanks[(Rank)i] = i.ToString();
            }
            strRanks[Rank.Jack] = "J";
            strRanks[Rank.Queen] = "Q";
            strRanks[Rank.King] = "K";
            strRanks[Rank.Ace] = "A";
        }
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Card card &&
                   Rank == card.Rank &&
                   Suit == card.Suit;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rank, Suit);
        }

        public override string ToString()
        {
            return $"{strRanks[Rank]}{strSuit[Suit]}";
        }
       
    }
}