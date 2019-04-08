using System;
using System.Collections.Generic;
namespace DeckOfCards
{
    class Program
    {
        public class Card{
            public string stringVal;
            public string suit;
            public int val;
            public Card(string sVal, string suitp, int vals){
                stringVal = sVal;   
                suit = suitp;
                val = vals;
            }
          
        }
        public class Deck{


            public List<Card> cards; 
            public Deck(){
                cards = new List<Card>();
                buildDeck();
            }
            public Deck buildDeck(){
                cards.Clear();
                int count = 0;
                string[] suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
                string[] stringVal = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
                for( int i = 0 ; i < suits.Length; i++){
                    for(int j = 0; j <stringVal.Length; j++){
                        cards.Add(new Card(stringVal[j], suits[i], j));
                        count++;
                    }
                }
                return this;
                
            }
            public Card Deal(){
                // System.Console.WriteLine(cards);
                Card currentCard = cards[cards.Count-1];
                System.Console.WriteLine($"dealt {currentCard.stringVal} of {currentCard.suit}");
                cards.RemoveAt(cards.Count-1);

                return currentCard;
            }
            public Deck ShowDeck(){
                for ( int i =0; i < cards.Count; i++) {
                    System.Console.WriteLine($"{cards[i].stringVal} of {cards[i].suit}");
                }
                return this;
            }
            public Deck Shuffle() {
                Random rand = new Random();
                Card temp1;
          
                int tempnum = 0;
                int tempnum2 = 0;
                for (int i = 0; i <= 100; i++) {
                    tempnum = rand.Next(0,51);
                    tempnum2 = rand.Next(0,51);
                    temp1 = cards[tempnum];
                    cards[tempnum] = cards[tempnum2];
                    cards[tempnum2] = temp1;
                }
                return this;
            }

        }
        public class Player{
            List<Card> Hand;
            string Name;
            public Player(string name) {
                Name = name;
                Hand = new List<Card>();
            }
            public Player Draw(Deck myDeck) {
                Card heldCard = myDeck.Deal();
                System.Console.WriteLine($"{heldCard.stringVal} of {heldCard.suit}");
                Hand.Add(heldCard);
                return this;
            }
            public Card Discard(int idx) {
                if(idx < 0 || idx > Hand.Count) {
                    return null;
                }
                else{
                    Card removedCard = Hand[idx];
                    Hand.RemoveAt(idx);
                    return removedCard;
                }
            }
            public Player ShowHand(){
                for ( int i =0; i < Hand.Count; i++) {
                    System.Console.WriteLine($"{Hand[i].stringVal} of {Hand[i].suit}");
                }
                return this;
            }                       
        }                                                    
        static void Main(string[] args)
        {
            Deck mydeck = new Deck();
            Player Me = new Player("Yong");
            // mydeck.ShowDeck();
            // mydeck.Deal();
            // mydeck.ShowDeck();
            // mydeck.buildDeck();
            mydeck.Shuffle();
            // mydeck.ShowDeck();
            // Me.Discard()
            
            Me.Draw(mydeck);
            Me.Draw(mydeck);
            Me.Draw(mydeck);
            System.Console.WriteLine("-------------------------------------------------------");
            Me.ShowHand();

            Me.Discard(0);
            System.Console.WriteLine("-------------------------------------------------------");
            Me.ShowHand();
        }
    }
}
