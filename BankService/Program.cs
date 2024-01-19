using BankService.Interfaces;
using BankService.Services;

class Program
{
    static void Main()
    {
        IBankManager bankManager = new BankManager();

        bool isActive = true;
        while (isActive)
        {
            Console.WriteLine("Welcome to Bank of Najot Talim");
            Console.WriteLine("1.   Register");
            Console.WriteLine("2.   Login");
            Console.WriteLine("3.   Show bank info");
            Console.WriteLine("4.   Console Clear");
            Console.WriteLine("5.   Exit");
            try
            {
                Console.Write("Please enter your choice: ");
                byte choice = byte.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        bankManager.Register();
                        break;
                    case 2:
                        {
                            var res = bankManager.Login();
                            bool isSwitch = false;
                            while (!isSwitch)
                            {
                                if (res != null)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Select operation:");
                                    Console.WriteLine("1. Create card");
                                    Console.WriteLine("2. Block card");
                                    Console.WriteLine("3. Unblock card");
                                    Console.WriteLine("4. Show cards");
                                    Console.WriteLine("5. Show balance");
                                    Console.WriteLine("6. Show all balance");
                                    Console.WriteLine("7. Deposit");
                                    Console.WriteLine("8. Withdraw");
                                    Console.WriteLine("0. Exit");
                                    Console.Write("Please enter your choice: ");
                                    byte switch_choice = byte.Parse(Console.ReadLine());

                                    switch (switch_choice)
                                    {
                                        case 1:
                                            bankManager.CreateCard(res);
                                            break;
                                        case 2:
                                            Console.Write("Please enter card number: ");
                                            string cardNumberBlock = Console.ReadLine();
                                            bankManager.BlockCard(res, cardNumberBlock);
                                            break;
                                        case 3:
                                            Console.Write("Please enter card number: ");
                                            string cardNumberUnblock = Console.ReadLine();
                                            bankManager.UnblockCard(res, cardNumberUnblock);
                                            break;
                                        case 4:
                                            bankManager.ShowCards(res);
                                            break;
                                        case 5:
                                            Console.Write("Please enter card number: ");
                                            string cardNumberBalance = Console.ReadLine();
                                            bankManager.ShowBalance(res, cardNumberBalance);
                                            break;
                                        case 6:
                                            bankManager.ShowAllBalance(res);
                                            break;
                                        case 7:
                                            Console.Write("Please enter card number: ");
                                            string cardNumberDeposit = Console.ReadLine();
                                            bankManager.Deposit(res, cardNumberDeposit);
                                            break;
                                        case 8:
                                            Console.Write("Please enter card number: ");
                                            string cardNumberWithdraw = Console.ReadLine();
                                            Console.Write("Please enter pin code: ");
                                            string pinCode = Console.ReadLine();
                                            bankManager.WithDraw(res, cardNumberWithdraw, pinCode);
                                            break;
                                        case 0:
                                            isSwitch = true;
                                            break;
                                        default:
                                            Console.WriteLine("Error in input.  Please try again");
                                            break;

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No matching information");
                                    break;
                                }
                            }

                        }
                        break
                            ;
                    case 3:
                        bankManager.ShowBankInfo();
                        break;
                    case 4:
                        Console.Clear();
                        break;
                    case 5:
                        Console.WriteLine("Thank you for using our app");
                        Thread.Sleep(1500);
                        Console.WriteLine("Bye...");
                        isActive = false;
                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}