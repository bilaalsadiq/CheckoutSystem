using CheckoutSystem;

namespace CheckoutSystem.Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void Test_ScanSingleItem_ItemA()
        {
            //arrange
            var checkout = new Checkout();

            //act
            checkout.Scan("A");

            //assert
            Assert.Equal(50, checkout.GetTotalPrice());
        }
        [Fact]
        public void Test_ScanSingleItem_ItemB()
        {
            //arrange
            var checkout = new Checkout();

            //act
            checkout.Scan("B");

            //assert
            Assert.Equal(30, checkout.GetTotalPrice());
        }
        [Fact]
        public void Test_ScanSingleItem_ItemC()
        {
            //arrange
            var checkout = new Checkout();

            //act
            checkout.Scan("C");

            //assert
            Assert.Equal(20, checkout.GetTotalPrice());
        }
        [Fact]
        public void Test_ScanSingleItem_ItemD()
        {
            //arrange
            var checkout = new Checkout();

            //act
            checkout.Scan("D");

            //assert
            Assert.Equal(15, checkout.GetTotalPrice());
        }
        [Fact]
        public void Test_ScanAllItemsOnce()
        {
            //arrange
            var checkout = new Checkout();

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
            var checkout = new Checkout();

            //act
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            checkout.Scan("B"); 
            checkout.Scan("B");
            
            //assert
            Assert.Equal(210, checkout.GetTotalPrice());
        }
    }
}