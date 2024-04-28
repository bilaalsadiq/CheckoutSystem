using System.Collections.Generic;

namespace CheckoutSystem
{
    public class Checkout : ICheckout
    {
        //dictionary item for products with standalone pricing
        private readonly Dictionary<string, int> _products;

        public Checkout()
        {
            _products = new Dictionary<string, int>
            {
                { "A", 50 },
                { "B", 30 },
                { "C", 20 },
                { "D", 15 }
            };
        }

        //class method to generate the 'final price' 
        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (var item in _scannedItems)
            {
                //get unit price from 'products' dictionary
                var unitPrice = _products.Where(x => x.Key == item.Key).Select(x => x.Value).FirstOrDefault();
                int qty = item.Value;

                totalPrice += unitPrice * qty;
            }
            return totalPrice;
        }

        //instantiate dictionary to hold scanned items, to then generate final price
        private readonly Dictionary<string, int> _scannedItems = new Dictionary<string, int>();

        public void Scan(string Item)
        {
            //if item doesn't already exist,set quantity to 1, otherwise add another instance of item to dictionary
            if (!_scannedItems.ContainsKey(Item))
            {
                _scannedItems[Item] = 1;
            }
            else
            {
                _scannedItems[Item]++;
            }
        }
    }
}