using ATMConsole;

namespace UnitTestingProject
{
    public class UnitTest1
    {
        [Fact]
        public void ViewBalance_ReturnsCurrentBalance()
        {
            // Arrange
            Program.Balance = 0;

            // Act
            decimal actualBalance = Program.ViewBalance();

            // Assert
            Assert.Equal(Program.Balance, actualBalance);
        }


        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        public void Withdraw_ValidAmount_ReturnsWithdrawnAmount(decimal amount)
        {
            // Arrange
            Program.Balance = 200;

            // Act
            decimal actualAmount = Program.Withdraw(amount);

            // Assert
            Assert.Equal(amount, actualAmount);
        }

        [Theory]
        [InlineData(250)]
        [InlineData(300)]
        public void Withdraw_InvalidAmount_ReturnsNegativeValue(decimal amount)
        {
            // Arrange
            Program.Balance = 200;

            // Act
            decimal actualAmount = Program.Withdraw(amount);

            // Assert
            Assert.Equal(-1,actualAmount);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(-20)]
        public void Withdraw_InsufficientFunds_ReturnsNegativeOne(decimal ammount)
        {
            // Arrange
            Program.Balance = 100;

            // Act
            decimal actualAmount = Program.Withdraw(ammount);

            // Assert
            Assert.Equal(-2, actualAmount);
        }

        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        public void Deposit_ValidAmount_ReturnsDepositedAmount(decimal amount)
        {
            // Arrange
            Program.Balance = 0;

            // Act
            decimal actualAmount = Program.Deposit(amount);

            // Assert
            Assert.Equal(amount, actualAmount);
        }

        [Fact]
        public void Deposit_InvalidAmount_ReturnsNegativeOne()
        {
            // Arrange
            Program.Balance = 0;

            // Act
            decimal actualAmount = Program.Deposit(-50);

            // Assert
            Assert.Equal(-1, actualAmount);
        }
    }
}