using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVendingMachine
{
    public interface IVending
    {
        void Purchase(int selection);
        void ShowAll();
        void InsertMoney();
        Dictionary<int, int> EndTransaction();
    }
}
