using CheckoutSystem;

namespace CheckoutSystem.Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void Test_ScanSingleItem_ItemA()
        {
            //arrange
            var _products = new Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)>
            {
                { "A", (50,(3,130)) },
                { "B", (30,(2,45))},
                { "C", (20,(0,0))},
                { "D", (15,(0,0))}
            };

            var checkout = new Checkout(_products);

            //act
            checkout.Scan("A");

            //assert
            Assert.Equal(50, checkout.GetTotalPrice());
        }
        [Fact]
        public void Test_ScanSingleItem_ItemB()
        {
            //arrange
            var _products = new Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)>
            {
                { "A", (50,(3,130)) },
                { "B", (30,(2,45))},
                { "C", (20,(0,0))},
                { "D", (15,(0,0))}
            };

            var checkout = new Checkout(_products);

            //act
            checkout.Scan("B");

            //assert
            Assert.Equal(30, checkout.GetTotalPrice());
        }
        [Fact]
        public void Test_ScanSingleItem_ItemC()
        {
            //arrange
            var _products = new Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)>
            {
                { "A", (50,(3,130)) },
                { "B", (30,(2,45))},
                { "C", (20,(0,0))},
                { "D", (15,(0,0))}
            };

            var checkout = new Checkout(_products);

            //act
            checkout.Scan("C");

            //assert
            Assert.Equal(20, checkout.GetTotalPrice());
        }
        [Fact]
        public void Test_ScanSingleItem_ItemD()
        {
            //arrange
            var _products = new Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)>
            {
                { "A", (50,(3,130)) },
                { "B", (30,(2,45))},
                { "C", (20,(0,0))},
                { "D", (15,(0,0))}
            };

            var checkout = new Checkout(_products);

            //act
            checkout.Scan("D");

            //assert
            Assert.Equal(15, checkout.GetTotalPrice());
        }
        [Fact]
        public void Test_ScanAllItemsOnce()
        {
            //arrange
            var _products = new Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)>
            {
                { "A", (50,(3,130)) },
                { "B", (30,(2,45))},
                { "C", (20,(0,0))},
                { "D", (15,(0,0))}
            };

            var checkout = new Checkout(_products);

            //act
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");

            //assert
            Assert.Equal(115, checkout.GetTotalPrice());
        }

        [Fact]
        public void Test_ScanMultipleQtyOfSameSKU_BeforeSpecialPrice()
        {
            //arrange
            var _products = new Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)>
            {
                { "A", (50,(0,0)) },
                { "B", (30,(0,0))},
                { "C", (20,(0,0))},
                { "D", (15,(0,0))}
            };

            var checkout = new Checkout(_products);

            //act
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            checkout.Scan("B"); 
            checkout.Scan("B");
            
            //assert
            Assert.Equal(210, checkout.GetTotalPrice());
        }

        [Fact]
        public void Test_ErrorIfItemNotExistingInRecords()
        {
            //arrange
            var _products = new Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)>
            {
                { "A", (50,(3,130)) },
                { "B", (30,(2,45))},
                { "C", (20,(0,0))},
                { "D", (15,(0,0))}
            };

            var checkout = new Checkout(_products);

            //act
            var ex = Assert.Throws<ArgumentException>(() => checkout.Scan("E"));

            //assert
            Assert.Equal("Item not in our system - please scan another item", ex.Message);
        }

        [Fact]
        public void Test_ApplySpecialPricingForItems_ItemA()
        {
            //arrange
            var _products = new Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)>
            {
                { "A", (50,(3,130)) },
                { "B", (30,(2,45))},
                { "C", (20,(0,0))},
                { "D", (15,(0,0))}
            };

            var checkout = new Checkout(_products);

            //act
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            //assert
            Assert.Equal(130, checkout.GetTotalPrice());
        }

        [Fact]
        public void Test_ApplySpecialPricingForMoreThanDiscountedQty_ItemA()
        {
            //arrange
            var _products = new Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)>
            {
                { "A", (50,(3,130)) },
                { "B", (30,(2,45))},
                { "C", (20,(0,0))},
                { "D", (15,(0,0))}
            };

            var checkout = new Checkout(_products);

            //act
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            //assert
            Assert.Equal(180, checkout.GetTotalPrice());
        }

        
        [Fact]
        public void Test_ApplySpecialPricingForDifferentProductsAndDifferentQtys()
        {
            //arrange
            var _products = new Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)>
            {
                { "A", (50,(3,130)) },
                { "B", (30,(2,45))},
                { "C", (20,(0,0))},
                { "D", (15,(0,0))}
            };

            var checkout = new Checkout(_products);

            //act
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");

            checkout.Scan("C");
            checkout.Scan("D");

            //assert
            Assert.Equal(290, checkout.GetTotalPrice());
        }

        [Fact]
        public void Test_ScanZeroItems_ZeroBags()
        {
            //arrange
            var _products = new Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)>
            {
                { "A", (50,(3,130)) },
                { "B", (30,(2,45))},
                { "C", (20,(0,0))},
                { "D", (15,(0,0))}
            };

            var checkout = new Checkout(_products);

            //act

            //assert
            Assert.Equal(0, checkout.GetTotalPrice());
        }

        [Fact]
        public void Test_ScanOneItem_OneBag()
        {
            //arrange
            var _products = new Dictionary<string, (int unitPrice, (int Quantity, int specialPrice) specialPrice)>
            {
                { "A", (50,(3,130)) },
                { "B", (30,(2,45))},
                { "C", (20,(0,0))},
                { "D", (15,(0,0))}
            };

            var checkout = new Checkout(_products);

            //act
            checkout.Scan("A");

            //assert
            Assert.Equal(55, checkout.GetTotalPrice());
        }

    }
}