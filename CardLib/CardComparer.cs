using System;
using System.Collections.Generic;
using System.Text;

namespace CardLib
{
    public class CardComparer : IComparer<Card>
    {
        public int Compare(Card card1, Card card2)
        {
            if (card1.Rank > card2.Rank)
            {
                return 1;
            }
            else if (card1.Rank < card2.Rank)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
