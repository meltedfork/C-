using System;
using System.Collections.Generic;
namespace deckOfCards
{
    public class Player
    {
        public string name;
        public List<Card> hand;

        public Player(string person)
        {
            name = person;
            hand = new List<Card>();
        }

        // draw method of which draws a card from a deck, 
        // adds it to the player's hand and returns the Card
        public Card draw(Deck addhand)
        {
            Card newCard = addhand.deal();
            hand.Add(newCard);
            return newCard;
        }

        // Give the Player a discard method which discards the Card 
        // at the specified index from the player's hand and returns this Card 
        // or null if the index does not exist
        public Card discard(int idx)
        {
            if (idx < 0 || idx > hand.Count) 
            {
                return null;
            } 

            else 
            {
                Card shuffle = hand[idx];
                hand.RemoveAt(idx);
                return shuffle;
            }
        }
    }
}