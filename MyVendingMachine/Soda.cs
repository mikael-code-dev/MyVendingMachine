using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVendingMachine
{
    public class Soda : Product
    {
        public Soda(string nameProduct, int priceProduct) : base(nameProduct, priceProduct)
        {
        }

        public override string Examine()
        {
            return $"{base.Examine()} a can of SODA! It is called {NameProduct}";
        }

        public override void Use()
        {
            Console.Write($"Your can of soda: {NameProduct} ");
            base.Use();
        }
    }
}
