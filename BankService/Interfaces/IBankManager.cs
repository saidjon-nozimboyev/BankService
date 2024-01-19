using BankService.Modules;

namespace BankService.Interfaces
{
    internal interface IBankManager
    {
        void Register();
        User Login();
        void CreateCard(User user);
        void BlockCard(User user, string cardNumber);
        void UnblockCard(User user, string cardNumber);
        void ShowCards(User User);
        void ShowBalance(User user, string cardNumber);
        void ShowAllBalance(User user);
        void ShowBankInfo();
        void Deposit(User user, string cardNumber);
        void WithDraw(User user, string cardNumber, string pin);
    }
}
