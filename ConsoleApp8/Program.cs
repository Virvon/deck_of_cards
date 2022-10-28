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
            Deck deck = new Deck();
            User user = new User();
            Random random = new Random();

            while (isNumber == false)
            {
                Console.Write("Какое количество карт вы хотите достать: ");

                if (int.TryParse(Console.ReadLine(), out int cardsCount))
                {
                    if (deck.CheckCardsCount(cardsCount))
                    {
                        isNumber = true;
                        deck.GiveCards(user, random, cardsCount);
                    }
                    else
                        Console.WriteLine("Недостаточно карт");
                }
                else
                    Console.WriteLine("Некоректная команда");
            }

            user.ShowCards();
            Console.ReadKey();
        }
    }

    class User
    {
        private List<Card> _cards = new List<Card>();

        public void TakeCard(Card card)
        {
            _cards.Add(card);
        }

        public void ShowCards()
        {
            Console.WriteLine("\nВаши карты:\n");

            foreach(var card in _cards)
            {
                Console.WriteLine($"{card.Value} {card.Suit}");
            }
        }
    }

    class Deck
    {
        private List<Card> _cards;

        public Deck()
        {
            _cards = CreateDeck();
        }

        public void GiveCards(User user, Random random, int cardsCount)
        {
            for(int i = 0; i < cardsCount; i++)
            {
                int index = random.Next(0, _cards.Count);

                user.TakeCard(_cards[index]);
                _cards.RemoveAt(index);
            }
        }

        public bool CheckCardsCount(int rightAmount)
        {
            return rightAmount <= _cards.Count;
        }

        private List<Card> CreateDeck()
        {
            List<Card> cards = new List<Card>();
            string[] suit = new string[] {"черви", "пики", "бубны", "трефы"};
            string[] value = new string[] { "шестерка", "семерка", "восьмерка", "девятка", "десятка", "валет", "дама", "король", "туз" };

            for(int i = 0; i < suit.Length; i++)
            {
                for(int j = 0; j < value.Length; j++)
                {
                    cards.Add(new Card(suit[i], value[j]));
                }
            }

            return cards;
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
