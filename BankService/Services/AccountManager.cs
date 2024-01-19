using BankService.Interfaces;
using BankService.Modules;

namespace BankService.Services
{
    internal class AccountManager : IAccountManager
    {
        List<User> users = new();


        public void Register()
        {
            try
            {
                Console.Write("Please enter full name: ");
                string fullName = Console.ReadLine();
                Console.Write("Please enter password: ");
                string password = Console.ReadLine();
                Console.Write("Please enter phone number: ");
                string phoneNumber = Console.ReadLine();

                DateTime dateTime = DateTime.Now;

                User user = new(fullName, password, phoneNumber);
                users.Add(user);

                Console.WriteLine("Information has been added sucessfuly!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public User Login()
        {
            Console.Write("Please enter your phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Please enter your password: ");
            string password = Console.ReadLine();
            foreach (var user in users)
            {
                if (user.Password == password && user.Phone == phoneNumber)
                {
                    Console.WriteLine("Logged succcessfuly");
                    return user;
                }

            }
            return null;
        }

    }
}
