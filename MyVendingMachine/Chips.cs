using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVendingMachine
{
    public class Chips : Product
    {
        public Chips(string nameProduct, int priceProduct) : base(nameProduct, priceProduct)
        {
        }

        public override string Examine()
        {
            return $"{base.Examine()} a BAG OF CHIPS! It is called {NameProduct}";

        }

        public override void Use()
        {
            Console.Write($"Your bag of chips: {NameProduct} ");
            base.Use();
        }
    }
}
