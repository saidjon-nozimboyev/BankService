using BankService.Modules;

namespace BankService.Interfaces
{
    internal interface IAccountManager
    {
        void Register();
        User Login();

    }
}
