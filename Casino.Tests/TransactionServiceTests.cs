using Casino.Exceptions;
using Casino.Services;
using Casino.Wrappers;
using Moq;
using Xunit;

namespace Casino.Tests
{
    public class TransactionServiceTests
    {
        private readonly TransactionService _transactionService;
        private readonly Mock<IConsole> _console;

        public TransactionServiceTests()
        {
            this._console = new Mock<IConsole>();
            this._transactionService = new TransactionService(this._console.Object);
        }

        [Fact]
        public void Deposit_ValidAmount_UpdatesBalance()
        {
            // Arrange
            this._console.Setup(c => c.ReadLine())
                .Returns("10");

            // Act
            this._transactionService.Deposit();

            // Assert
            Assert.Equal(10, this._transactionService.Balance);
        }

        [Fact]
        public void Deposit_InvalidAmount_ThrowsInvalidAmountException()
        {
            // Arrange
            this._console.Setup(c => c.ReadLine())
                .Returns("invalid");

            // Act
            var ex = Assert.Throws<InvalidAmountException>(() => this._transactionService.Deposit());

            // Assert
            Assert.Equal(0, this._transactionService.Balance);
            this._console.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void Deposit_ValidAmount_AddsToBalance()
        {
            // Arrange
            this._console.SetupSequence(c => c.ReadLine())
                .Returns("10")
                .Returns("5");

            // Act
            this._transactionService.Deposit();
            this._transactionService.Deposit();

            // Assert
            Assert.Equal(15, this._transactionService.Balance);
        }

        [Fact]
        public void Deposit_ZeroAmount_ThrowsInvalidAmountException()
        {
            // Arrange
            this._console.Setup(c => c.ReadLine()).Returns("0");

            // Act & Assert
            Assert.Throws<InvalidAmountException>(() => this._transactionService.Deposit());
        }
    }
}