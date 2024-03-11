namespace DiscountCalculator.UnitTests;

public class DiscountCalculatorTests
{
    [Theory]
    [InlineData(10.0, "", 10.0)]
    [InlineData(100.0, "", 100.0)]
    [InlineData(10.0, "SAVE10NOW", 9.0)]
    [InlineData(100.0, "SAVE10NOW", 90.0)]
    [InlineData(10.0, "DISCOUNT20OFF", 8.0)]
    [InlineData(100.0, "DISCOUNT20OFF", 80.0)]
    public void AppliesCorrectDiscountOnPassedPrice(decimal basePrice, string code, decimal expectedPrice)
    {
      // Arrange
      var calculator = new DiscountCalculator();

      // Act
      decimal resultPrice = calculator.CalculateDiscount(basePrice, code);

      // Assert
      Assert.Equal(expectedPrice, resultPrice);
    }

    [Theory]
    [InlineData(-10.0, "SAVE10NOW", "Negatives not allowed")]
    [InlineData(10.0, "not existing code", "Invalid discount code")]
    public void ThrowsExceptionOnInvalidArgument(decimal basePrice, string code, string expectedErrorMessage)
    {
      // Arrange
      var calculator = new DiscountCalculator();

      // Act & Assert
      ArgumentException ex = Assert.Throws<ArgumentException>(() => calculator.CalculateDiscount(basePrice, code));
      Assert.Equal(expectedErrorMessage, ex.Message);
    }
}
