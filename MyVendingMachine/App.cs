using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVendingMachine
{
    public class App
    {
        public void Run(VendingMachine vending)
        {
            var isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("********   VENDING SPECIALIST   ********");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nCurrent saldo: {vending.MoneyPool}");
                Console.ResetColor();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1 - Show Available Product Items");
                Console.WriteLine("2 - Insert Money");
                Console.WriteLine("3 - Buy an Item");
                Console.WriteLine("4 - Get your Items and Change");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nMake a selection");
                Console.Write(":> ");
                Console.ResetColor();

                if (int.TryParse(Console.ReadLine(), out int selection))
                {
                    switch (selection)
                    {
                        case 1:
                            ShowVendingProducts(vending);
                            break;
                        case 2:
                            vending.InsertMoney();
                            break;
                        case 3:
                            BuyProducts(vending);
                            break;
                        case 4:
                            GetItemsAndChange(vending);
                            isRunning = false;
                            break;
                        default:
                            Message("Invalid Menu Selection");
                            break;
                    }
                }

                Console.WriteLine("\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void GetItemsAndChange(VendingMachine vending)
        {
            Console.Clear();

            var changes = vending.EndTransaction();

            if (!(changes.Count <= 0))
            {
                Console.WriteLine("You get back your change:\n");
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var change in changes)
                {
                    if (change.Key > 10)
                    {
                        Console.WriteLine($"{change.Value}: {change.Key} note back");
                    }
                    else
                    {
                        Console.WriteLine($"{change.Value}: {change.Key} coin back");
                    }
                }
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("No Change to receive");
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var item in vending.UsersItems)
            {
                item.Use();
            }
            Console.ResetColor();
        }

        private void BuyProducts(VendingMachine vending)
        {
            Console.Clear();
            Message("Select an item to Buy\n");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            int counter = 1;
            foreach (var item in vending.Products)
            {
                Console.WriteLine($"{counter++} - {item.NameProduct}: {item.PriceProduct}Kr");
            }
            Console.ResetColor();

            Console.Write("\n:> ");

            if (int.TryParse(Console.ReadLine(), out int userChoise))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                vending.Purchase(userChoise - 1);
                Console.ResetColor();
            }
            else
            {
                Message("Make a Valid Selection");
            }
        }

        private void ShowVendingProducts(VendingMachine vending)
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            vending.ShowAll();
            Console.ResetColor();
        }

        private void Message(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
