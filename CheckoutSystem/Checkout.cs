using System.Collections.Generic;

namespace CheckoutSystem
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)> _products;

        public Checkout(Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)> products)
        {
            _products = products;
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (var item in _scannedItems)
            {
                var unitPrice = _products[item.Key].unitPrice;
                var specialPrice = _products[item.Key].specialPrice;

                int qty = item.Value;
                int specialQty = specialPrice.Quantity;
                int specialPriceValue = specialPrice.specialPrice;

                if (specialQty > 0 && qty >= specialQty)
                {
                    int SpecialPriceQty = qty / specialQty;
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

        private readonly Dictionary<string, int> _scannedItems = new Dictionary<string, int>();

        public void Scan(string Item)
        {
            if (!_products.ContainsKey(Item))
            {
                throw new ArgumentException($"Item not in our system - please scan another item");
            }
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