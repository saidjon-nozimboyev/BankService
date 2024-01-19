using BankService.Interfaces;
using BankService.Modules;
using System.Collections;

namespace BankService.Services
{
    internal class BankManager : IBankManager
    {
        private IAccountManager accountManager = new AccountManager();
        private ICardManager cardManager = new CardManager();
        ArrayList myArrayList = new ArrayList();
        private Bank bank = new("Najot Talim", "Fergana, Uzbekistan", "77 777 77 77", DateTime.Now);

        public void Register()
        {
            accountManager.Register();
        }
        public User Login()
        {
            return accountManager.Login();
        }
        public void CreateCard(User user)
        {
            cardManager.CreateCard(user);
        }
        public void BlockCard(User user, string cardNumber)
        {
            cardManager.BlockCard(user, cardNumber);
        }
        public void UnblockCard(User user, string cardNumber)
        {
            cardManager.Unblock(user, cardNumber);
        }
        public void Deposit(User user, string cardNumber)
        {
            foreach (var card in user.Cards)
            {
                if (card.Number == cardNumber)
                {
                    if (card.Blocked == false)
                    {
                        Console.Write("How much money would you like to deposit: ");
                        try
                        {
                            double deposit = double.Parse(Console.ReadLine());
                            card.Balance += deposit;
                            Console.WriteLine("Money is deposited");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Card is blocked. Operation is invalid");
                    }
                }
                else
                {
                    Console.WriteLine("Incorect card number");
                }
            }
        }
        public void ShowAllBalance(User user)
        {
            double sum = 0;
            foreach (Card card in user.Cards)
            {
                sum += card.Balance;
            }
            Console.WriteLine($"All balance of {user.FullName} is {sum.ToString("c")}");
        }
        public void ShowBalance(User user, string cardNumber)
        {
            foreach (Card card in user.Cards)
            {
                if (card.Number == cardNumber)
                {
                    Console.WriteLine($"Balance of this card is: ${card.Balance}");
                }
            }
        }
        public void ShowBankInfo()
        {

            Console.WriteLine($"Bank name: {bank.name}");
            Console.WriteLine($"Bamk address: {bank.address}");
            Console.WriteLine($"Bank phone number: {bank.phone}");
        }
        public void ShowCards(User user)
        {
            Console.WriteLine("Card Number         | Expire At           | Blocked          | Balance");
            Console.WriteLine("--------------------|---------------------|------------------|---------");

            foreach (Card card in user.Cards)
            {
                Console.WriteLine($"{card.Number,-18} | {card.ExpireAt:MM/dd/yyyy}          | {card.Blocked,-8}         | {card.Balance,-3:0}");
            }


        }
        public void WithDraw(User user, string cardNumber, string pin)
        {
            foreach (Card card in user.Cards)
            {
                if (card.Number == cardNumber && card.Pin == pin)
                {
                    if (card.Blocked == false)
                    {
                        Console.Write("How much money would you like to withdraw: ");
                        try
                        {
                            double money = double.Parse(Console.ReadLine());
                            if (card.Balance < money)
                            {
                                Console.WriteLine("Not enough money");
                            }
                            else
                            {

                                Console.WriteLine("Operation has finished sucessfully");
                                card.Balance -= money;
                            }
                        }
                        catch (Exception e) { Console.WriteLine(e); }
                    }
                    else
                    {
                        Console.WriteLine("Card is blocked. Opeation is invalid");
                    }
                }

                else
                {
                    Console.WriteLine("Incorrect number of card or pin code");
                }
            }
        }

    }
}
