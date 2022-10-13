using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVendingMachine
{
    public class VendingMachine : IVending
    {
        private List<Product> _products;
        public IEnumerable<Product> Products { get { return _products; } }
        public List<Product> UsersItems { get; private set; }
        public int MoneyPool { get; private set; } = 0;
        private readonly int[] _denomination = { 1, 5, 10, 20, 50, 100, 500, 1000 };

        public VendingMachine()
        {
            _products = new List<Product>();
            UsersItems = new List<Product>();
            SetupMachine();
        }

        private void SetupMachine()
        {
            _products.Add(new Candy("Chocolate Bar", 16));
            _products.Add(new Candy("Cheesecake Bar", 18));
            _products.Add(new Candy("Gold Bar 24", 250));
            _products.Add(new Chips("Grill & Charcoal Crispy", 26));
            _products.Add(new Chips("Sour and Dry Chippy", 22));
            _products.Add(new Soda("Coca Cola", 22));
            _products.Add(new Soda("Fanta", 22));
        }

        public Dictionary<int, int> EndTransaction()
        {
            var change = new Dictionary<int, int>();

            if (MoneyPool > 0)
            {
                for (int i = _denomination.Length - 1; i >= 0; i--)
                {
                    if (MoneyPool / _denomination[i] > 0)
                    {
                        change[_denomination[i]] = MoneyPool / _denomination[i];
                    }
                    MoneyPool = MoneyPool % _denomination[i];
                }
            }

            return change;
        }

        // For Test
        public void InsertMoneyTest(int input)
        {
            MoneyPool = input;
        }

        public void InsertMoney()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("You can only use: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 0; i < _denomination.Length; i++)
                {
                    Console.Write($"{_denomination[i]}kr, ");
                }
                Console.ResetColor();
                Console.WriteLine("\nEnter 0 when you want to stop inserting money");
                Console.WriteLine("Start inserting money");
                Console.Write(":> ");
                if (!int.TryParse(Console.ReadLine(), out int userInserted))
                {
                    Console.WriteLine("Invalid input, try again!");
                }
                else
                {
                    if (userInserted == 0)
                        break;

                    if (_denomination.Contains(userInserted))
                    {
                        MoneyPool += userInserted;
                    }
                    else
                    {
                        Console.WriteLine("Invalid denomination, try again!");
                    }

                }

                Console.WriteLine($"\nSaldo: {MoneyPool}");
            }
        }

        public void Purchase(int selection)
        {
            if (!(selection < _products.Count) && selection > 0)
            {
                Console.WriteLine("Invalid, try again!");
            }
            else
            {
                if (MoneyPool >= _products[selection].PriceProduct)
                {
                    UsersItems.Add(_products[selection]);
                    MoneyPool -= _products[selection].PriceProduct;
                    Console.WriteLine($"You now have an item of: {_products[selection].NameProduct}");
                }
                else
                {
                    Console.WriteLine("You don't have sufficient saldo to buy this!");
                }
            }
        }

        public void ShowAll()
        {
            foreach (var product in _products)
            {
                Console.WriteLine($" * {product.Examine()} and the price is: {product.PriceProduct}Kr");
            }
        }
    }
}
