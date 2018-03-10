using System;
using System.Collections.Generic;
namespace deckOfCards
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();

        public Deck()
        {
            reset();
            shuffle();
            deal();
        }

        // reset method that resets the cards property to the contain the original 52 cards
        public Deck reset()
        {
            string[] suits = {"Hearts", "Diamonds", "Clubs", "Spades"};
            string[] stringVals = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};

            foreach (string suit in suits)
            {
                for (int idx = 0; idx < stringVals.Length; idx++)
                {
                    Card newCard = new Card(suit, stringVals[idx], idx + 1);
                    cards.Add(newCard);
                }
            }
            return this;
        }

        // deal method that selects the "top-most" card, 
        // removes it from the list of cards, 
        // and returns the Card
        public Deck deal()
        {
            if(cards.Count > 0) 
            {
                Card first = cards[0];
                cards.RemoveAt(0);
                return first;
            } 
            else 
            {
                reset();
                return deal();
            }
        }

        // shuffle method that randomly reorders the deck's cards
        public void shuffle()
        {
            //iterate backwards through deck
            Random rand = new Random();
            for(int end = cards.Count-1; end >= 0; end --)
            {
            //assigns temp to shuffle variable, a random card in the deck    
            int shuffle = rand.Next(0, cards.Count-1);
            Card temp = cards[shuffle];
            
            cards[shuffle] = cards[end];
            cards[end] = temp;
            }  
        }
    }
}