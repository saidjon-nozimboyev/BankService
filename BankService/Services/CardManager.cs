using BankService.Interfaces;
using BankService.Modules;
using System.Globalization;

namespace BankService.Services
{
    internal class CardManager : ICardManager
    {
        private List<Card> _cards = new();
        private int _count;

        public void BlockCard(User user, string cardNumber)
        {
            try
            {
                foreach (Card card in user.Cards)
                {
                    if (card.Number == cardNumber)
                    {
                        if (card.Blocked == false)
                        {
                            Console.WriteLine("Card has blocked");
                            card.Blocked = true;
                        }
                        else
                        {
                            Console.WriteLine("Card is blocked. Operation is invalid");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void Unblock(User user, string cardNumber)
        {
            try
            {
                foreach (Card card in user.Cards)
                {
                    if (card.Number == cardNumber)
                    {
                        if (card.Blocked == true)
                        {
                            Console.WriteLine("Card has unblocked");
                            card.Blocked = false;
                        }
                        else
                        {
                            Console.WriteLine("Card is not blocked. Operation is invalid");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public Card CreateCard(User user)
        {
            Random Random = new Random();
            try
            {
                char[] arr = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];
                string cardNumber = "8600 ";
                int cnt = 0;
                for (int i = 0; i < 12; i++)
                {
                    cardNumber += arr[Random.Next(arr.Length)];
                    cnt++;
                    if (cnt == 4)
                    {
                        cardNumber += " ";
                        cnt = 0;
                    }
                }
                cardNumber = cardNumber.Trim();
                Console.Write("Please enter pin code for card: ");
                string password = Console.ReadLine();
                Console.Write("Expire At (yyyy-MM): ");
                string expireAtString = Console.ReadLine();

                DateTime expireAt = DateTime.ParseExact(expireAtString + "-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
                Console.WriteLine($"Card number is: {cardNumber}");

                Card card = new Card(cardNumber, password, expireAt);

                _cards.Add(card);
                user.Cards.Add(card);
                return card;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please enter a valid year and month (yyyy-MM).");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            return null;
        }
        public Card GetCard(string cardNumber)
        {
            foreach (Card card in _cards)
            {
                if (card.Number == cardNumber)
                {
                    return card;
                }
            }
            return null;
        }
        public Card GetCard(User user, string cardNumber)
        {
            foreach (Card card in user.Cards)
            {
                if (card.Number == cardNumber)
                {
                    return card;
                }
            }
            return null;
        }

    }
}
