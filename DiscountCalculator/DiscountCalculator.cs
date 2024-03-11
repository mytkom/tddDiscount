namespace DiscountCalculator;

public class DiscountCalculator {
  Dictionary<string, decimal> activeDiscountCodes = new Dictionary<string, decimal>() {
    { "SAVE10NOW", 0.9M },
    { "DISCOUNT20OFF", 0.8M },
  };

  public decimal CalculateDiscount(decimal price, string discountCode) {
    if(price < 0)
    {
      throw new ArgumentException("Negatives not allowed");
    }

    if(discountCode.Length == 0)
    {
      return price;
    }

    if(!activeDiscountCodes.ContainsKey(discountCode))
    {
      throw new ArgumentException("Invalid discount code");
    }

    return price * activeDiscountCodes[discountCode]; 
  }
};
