using System.Xml.Linq;

namespace BankManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Account> accounts = new Dictionary<string, Account>();
            Console.WriteLine($"Български/Английски");
            string language = Console.ReadLine();
            if (language.ToLower() == "български")
            {

                BulgarianMenu();

                string input = Console.ReadLine();

                while (input != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Въведете името на собственика на сметката:");
                    string ownerName = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            if (!accounts.ContainsKey(ownerName))
                            {
                                Console.WriteLine("Въведете начален баланс:");
                                decimal balance = decimal.Parse(Console.ReadLine());

                                Console.WriteLine($"Акаунтът е създаден успешно!");

                                Account newAccount = new Account(ownerName, balance);

                                accounts.Add(ownerName, newAccount);
                            }
                            else
                            {
                                Console.WriteLine("Вече съществува сметка с това име!");
                            }
                            break;
                        case "2":
                            if (accounts.ContainsKey(ownerName))
                            {
                                Console.WriteLine("Въведете сума за вкарване:");
                                decimal balanceDeposit = decimal.Parse(Console.ReadLine());

                                accounts[ownerName].Balance += balanceDeposit;

                                Console.WriteLine($"Успешно вкарахте пари!");
                                Console.WriteLine($"Баланса е ${accounts[ownerName].Balance:f2}");
                            }
                            else 
                            {
                                Console.WriteLine($"Сметката не е намерена!");
                            }
                            break;
                        case "3":
                            if (accounts.ContainsKey(ownerName))
                            {
                                Console.WriteLine("Въведете сума за теглене:");
                                decimal balanceWithdrawl = decimal.Parse(Console.ReadLine());


                                if (accounts[ownerName].Balance - balanceWithdrawl < 0)
                                {
                                    Console.WriteLine($"Недостатъчно средства!");
                                    Console.WriteLine($"Баланса е ${accounts[ownerName].Balance:f2}");
                                }
                                else
                                {
                                    accounts[ownerName].Balance -= balanceWithdrawl;

                                    Console.WriteLine($"Успешно изтеглихте пари!");
                                }      
                            }
                            else
                            {
                                Console.WriteLine($"Сметката не е намерена!");
                            }
                            break;
                        case "4":
                            if (accounts.ContainsKey(ownerName))
                            {
                                Account acc = accounts[ownerName];
                                Console.WriteLine($"Баланса на {acc.UserName} е: ${acc.Balance:f2}");
                            }
                            else
                            {
                                Console.WriteLine($"Сметката не е намерена!");
                            }
                            break;
                        default:
                            Console.WriteLine($"Невалиден избор. Опитайте отново.");
                            break;
                    }

                    BulgarianMenu();
                    input = Console.ReadLine();
                }
                Console.Clear();
                Console.WriteLine($"Благодарим, че използвахте BankSystem. Довиждане!");
            }
            else if (language.ToLower() == "английски")
            {
                EnglishMenu();

                string input = Console.ReadLine();

                while (input != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Enter the account owner's name:");
                    string ownerName = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            if (!accounts.ContainsKey(ownerName))
                            {
                                Console.WriteLine("Enter initial balance:");
                                decimal balanceInput = decimal.Parse(Console.ReadLine());

                                Console.WriteLine("Account has been created successfully!");

                                Account newAccount = new Account(ownerName, balanceInput);

                                accounts.Add(ownerName, newAccount);
                            }
                            else
                            {
                                Console.WriteLine("An account with this name already exists!");
                            }
                            break;
                        case "2":
                            if (accounts.ContainsKey(ownerName))
                            {
                                Console.WriteLine("Enter amount to deposit:");
                                decimal balanceDeposit = decimal.Parse(Console.ReadLine());

                                accounts[ownerName].Balance += balanceDeposit;

                                Console.WriteLine($"Money deposited successfully!");
                                Console.WriteLine($"Balance is ${accounts[ownerName].Balance:f2}");
                            }
                            else
                            {
                                Console.WriteLine($"Account not found!");
                            }
                            break;
                        case "3":
                            if (accounts.ContainsKey(ownerName))
                            {
                                Console.WriteLine("Enter amount to withdraw:");
                                decimal balanceWithdrawl = decimal.Parse(Console.ReadLine());


                                if (accounts[ownerName].Balance - balanceWithdrawl < 0)
                                {
                                    Console.WriteLine($"Insufficient funds!");
                                    Console.WriteLine($"Balance is ${accounts[ownerName].Balance:f2}");
                                }
                                else
                                {
                                    accounts[ownerName].Balance -= balanceWithdrawl;

                                    Console.WriteLine($"Money withdrawn successfully!");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Account not found!");
                            }
                            break;
                        case "4":
                            if (accounts.ContainsKey(ownerName))
                            {
                                Account acc = accounts[ownerName];
                                Console.WriteLine($"The balance for {acc.UserName} is: ${acc.Balance:f2}");
                            }
                            else
                            {
                                Console.WriteLine($"Account not found!");
                            }
                            break;
                        default:
                            Console.WriteLine($"Invalid choice. Please try again.");
                            break;
                    }

                    EnglishMenu();
                    input = Console.ReadLine();
                }
                Console.Clear();
                Console.WriteLine($"Thank you for using BankSystem. Goodbye!");
            }
            else
            {
                Console.WriteLine($"Невалиден език/Wrong language");
                return;
            }
        }

        public static void BulgarianMenu()
        {
            Console.WriteLine($"===============================");
            Console.WriteLine($"         Моята Банка          ");
            Console.WriteLine($"===============================");
            Console.WriteLine($"1.Създай нова сметка");
            Console.WriteLine($"2.Внеси пари");
            Console.WriteLine($"3.Изтегли пари");
            Console.WriteLine($"4.Провери баланс");
            Console.WriteLine($"0.Изход");
            Console.WriteLine($"===============================");
        }

        public static void EnglishMenu()
        {
            Console.WriteLine($"===============================");
            Console.WriteLine($"         BANK SYSTEM           ");
            Console.WriteLine($"===============================");
            Console.WriteLine($"1.Create new account");
            Console.WriteLine($"2.Deposit money");
            Console.WriteLine($"3.Withdraw money");
            Console.WriteLine($"4.Check balance");
            Console.WriteLine($"0.Exit");
            Console.WriteLine($"===============================");
        }

    }
    class Account 
    {
        public Account(string userName, decimal balance)
        {
            UserName = userName;
            Balance = balance;
        }

        public string UserName { get; set; }

        public decimal Balance { get; set; }

    }
}
