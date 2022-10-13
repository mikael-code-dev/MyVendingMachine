using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVendingMachine
{
    public abstract class Product
    {
        public string NameProduct { get; private set; }
        public int PriceProduct { get; private set; }

        public Product(string nameProduct, int priceProduct)
        {
            NameProduct = nameProduct;
            PriceProduct = priceProduct;
        }

        public virtual string Examine()
        {
            return "This is:";
        }

        public virtual void Use()
        {
            Console.WriteLine("...let's use it");
        }
    }
}
