using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutSystem
{
    internal interface ICheckout
    {
        void Scan(string Item);
        int GetTotalPrice();
    }
}
