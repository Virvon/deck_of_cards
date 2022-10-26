using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deck_of_cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isNumber = false;  
            int cardsCount = 0;
            Deck deck = new Deck();
            User user = new User();
            Random random = new Random();

            while (isNumber == false)
            {
                Console.Write("Какое количество карт вы хотите достать: ");

                if (int.TryParse(Console.ReadLine(), out cardsCount))
                {
                    isNumber = true;
                }
                else
                    Console.WriteLine("Некоректная команда");
            }

            for(int i = 0; i < cardsCount; i++)
            {
                bool isEmpty = deck.GiveCard(user, random);

                if (isEmpty)
                {
                    break;
                }
            }

            user.ShowCards();
            Console.ReadKey();
        }
    }

    class User
    {
        private List<Card> userCards = new List<Card>();

        public void TakeCard(Card card)
        {
            userCards.Add(card);
        }

        public void ShowCards()
        {
            foreach(var card in userCards)
            {
                Console.WriteLine($"{card.Value} {card.Suit}");
            }
        }
    }

    class Deck
    {
        private List<Card> deckCards = new List<Card>() { new Card("черви", "шестерка"), new Card("черви", "семерка"), new Card("черви", "восьмерка"), new Card("черви", "девятка"), new Card("черви", "десятка"), new Card("черви", "валет"), new Card("черви", "дама"), new Card("черви", "король"), new Card("черви", "туз"), new Card("пики", "шестерка"), new Card("пики", "семерка"), new Card("пики", "восьмерка"), new Card("пики", "девятка"), new Card("пики", "десятка"), new Card("пики", "валет"), new Card("пики", "дама"), new Card("пики", "король"), new Card("пики", "туз"), new Card("бубны", "шестерка"), new Card("бубны", "семерка"), new Card("бубны", "восьмерка"), new Card("бубны", "девятка"), new Card("бубны", "десятка"), new Card("бубны", "валет"), new Card("бубны", "дама"), new Card("бубны", "король"), new Card("бубны", "туз"), new Card("трефы", "шестерка"), new Card("трефы", "семерка"), new Card("трефы", "восьмерка"), new Card("трефы", "девятка"), new Card("трефы", "десятка"), new Card("трефы", "валет"), new Card("трефы", "дама"), new Card("трефы", "король"), new Card("трефы", "туз") };

        public bool GiveCard(User user, Random random)
        {
            bool isEmpty = false;

            if (deckCards.Count > 0)
            {
                int index = random.Next(0, deckCards.Count);

                user.TakeCard(deckCards[index]);
                deckCards.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("В колоде нет больше карт");
                isEmpty = true;
            }

            return isEmpty;
        }
    }

    class Card
    {
        public string Suit { get; private set; }
        public string Value { get; private set; }

        public Card(string suit, string value)
        {
            Suit = suit;
            Value = value;
        }
    }
}
