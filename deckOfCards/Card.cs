using System;

namespace deckOfCards
{
    public class Card
    {
        public string stringVal;
        public string suit;
        public int val;

        public Card(string stv, string s, int v)
        {
            stringVal = stv;
            suit = s;
            val = v;
        }
    }
}