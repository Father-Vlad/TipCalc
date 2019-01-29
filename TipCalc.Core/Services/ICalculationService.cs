namespace TipCalc.Core.Services
{
    public interface ICalculationService
    {
        double TipAmount(double subTotal, int generosity);
        double TotalAmount(double subTotal, double tip);
    }
}
