using BankService.Modules;

namespace BankService.Interfaces
{
    internal interface ICardManager
    {
        Card CreateCard(User user);
        Card GetCard(string cardNumber);
        Card GetCard(User user, string cardNumber);
        void BlockCard(User user, string cardNumber);
        void Unblock(User user, string cardNumber);
    }
}
