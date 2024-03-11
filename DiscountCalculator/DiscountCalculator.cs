namespace DiscountCalculator;

public class DiscountCalculator {
  private Dictionary<string, (decimal multiplier, int? count)> _activeDiscountCodes = new Dictionary<string, (decimal, int?)>() {
    { "SAVE10NOW", (0.9M, null) },
    { "DISCOUNT20OFF", (0.8M, null) },
    { "abc", (0.5M, 1) },
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

    if(!_activeDiscountCodes.ContainsKey(discountCode) || _activeDiscountCodes[discountCode].count == 0)
    {
      throw new ArgumentException("Invalid discount code");
    }

    var codePair = _activeDiscountCodes[discountCode];

    if(codePair.count != null)
    {
      _activeDiscountCodes[discountCode] = new (codePair.multiplier, codePair.count - 1);
    }

    return price * _activeDiscountCodes[discountCode].multiplier; 
  }
};
