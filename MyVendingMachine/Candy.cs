using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVendingMachine
{
    public class Candy : Product
    {
        public Candy(string nameProduct, int priceProduct) : base(nameProduct, priceProduct)
        {
        }

        public override string Examine()
        {
            return $"{base.Examine()} a CANDY BAR! It is called {NameProduct}";
        }

        public override void Use()
        {
            Console.Write($"Your candy bar: {NameProduct} ");
            base.Use();
        }
    }
}
