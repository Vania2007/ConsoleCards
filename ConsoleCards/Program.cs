using CardLib;
using System;
using System.Text;

namespace ConsoleCards
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(new Card(CardRank.King, CardSuit.Heart));
        }
    }
}
