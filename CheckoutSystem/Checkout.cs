using System.Collections.Generic;

namespace CheckoutSystem
{
    public class Checkout : ICheckout
    {
        //dictionary item for products with standalone pricing
        private readonly Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)> _products;

        public Checkout()
        {
            _products = new Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)>
            {
                { "A", (50,(3,130)) },
                { "B", (30,(2,45))},
                { "C", (20,(0,0))},
                { "D", (15,(0,0))}
            };
        }

        //class method to generate the 'final price' 
        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (var item in _scannedItems)
            {
                //get unit price and special pricing for item
                var unitPrice = _products[item.Key].unitPrice;
                var specialPrice = _products[item.Key].specialPrice;

                //calculate total price for item
                int qty = item.Value;
                int specialQty = specialPrice.Quantity;
                int specialPriceValue = specialPrice.specialPrice;

                //validate if special pricing applies
                if (specialQty > 0 && qty >= specialQty)
                {
                    //C# int division will discard remainders & returns wholly divided number
                    int SpecialPriceQty = qty / specialQty;

                    //modulus, gets remainder of qty/specialQty
                    int NormalPriceQty = qty % specialQty;

                    totalPrice += (SpecialPriceQty * specialPriceValue) + (NormalPriceQty * unitPrice);
                }
                else
                {
                    totalPrice += unitPrice * qty;
                }
            }
            return totalPrice;
        }

        //instantiate dictionary to hold scanned items, to then generate final price
        private readonly Dictionary<string, int> _scannedItems = new Dictionary<string, int>();

        public void Scan(string Item)
        {
            //if scanned item doesn't exist in the product dictionary
            if (!_products.ContainsKey(Item))
            {
                throw new ArgumentException($"Item not in our system - please scan another item");
            }
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