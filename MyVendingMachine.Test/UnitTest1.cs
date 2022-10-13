using MyVendingMachine;

namespace MyVendingMachine.Test
{
    public class UnitTest1
    {
        [Fact]
        public void MakePurchaseTest()
        {
            VendingMachine vending = new();
            vending.InsertMoneyTest(250);
            vending.Purchase(2);

            // Expected
            int expectedUserItemsCount = 1;

            // Assert
            Assert.Equal(expectedUserItemsCount, vending.UsersItems.Count);
        }

        [Fact]
        public void MakePurchaseInsufficientMoneyTest()
        {
            VendingMachine vending = new();
            vending.InsertMoneyTest(5);
            vending.Purchase(5);

            // Assert
            Assert.Empty(vending.UsersItems);
        }

        [Fact]
        public void EndTransactionTest()
        {
            VendingMachine vending = new();
            vending.InsertMoneyTest(501);
            var actualChanges = vending.EndTransaction();

            // Expected
            var expectedChanges = new Dictionary<int, int>
            {
                { 500, 1 },
                { 1, 1 }
            };

            // Assert
            Assert.Equal(expectedChanges, actualChanges);

        }

        [Fact]
        public void EndTransactionNoMoneyTest()
        {
            VendingMachine vending = new();
            var actualChanges = vending.EndTransaction();

            Assert.Empty(actualChanges);
        }
    }
}