using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Contexts;
using RevenueRecognitionSystem.CustomExceptions;

namespace RevenueRecognitionSystem.Services;

public interface IRevenueService
{
    public Task<string> CalculateRevenue();
    public Task<string> CalculateRevenueForProduct(int productId);
    public Task<string> CalculateRevenueByCurrency(string targetCurrency);
    public Task<string> CalculatePredictedRevenue();
    public Task<string> CalculatePredictedRevenueForProduct(int productId);

}
public class RevenueService(DatabaseContext dbContext, ICurrencyConverterService currencyService) : IRevenueService
{
    public async Task<string> CalculateRevenue()
    {
        var revenue = await dbContext.Contracts
            .Where(c => c.IsSigned && c.PaidAmount == c.FinalPrice)
            .SumAsync(c => c.PaidAmount);
        
        return $"Calculated revenue = {revenue} PLN";
    }
    
    public async Task<string> CalculatePredictedRevenue()
    {
        var revenue = await dbContext.Contracts
            .SumAsync(c => c.FinalPrice);
        
        return $"Predicted revenue = {revenue} PLN";
    }

    public async Task<string> CalculateRevenueForProduct(int productId)
    {
        var existingProduct = await dbContext.Software
            .FirstOrDefaultAsync(s => s.Id == productId);
        if (existingProduct is null)
        {
            throw new SoftwareNotFoundException($"Product with Id: {productId} does not exist.");
        }

        var productRevenue = await dbContext.Contracts
            .Where(c => c.IsSigned &&
                        c.PaidAmount == c.FinalPrice &&
                        c.SoftwareVersion.SoftwareId == productId
            )
            .SumAsync(c => c.PaidAmount);

        return $"Calculated revenue for {existingProduct.Name} = {productRevenue} PLN";
    }
    
    public async Task<string> CalculatePredictedRevenueForProduct(int productId)
    {
        var existingProduct = await dbContext.Software
            .FirstOrDefaultAsync(s => s.Id == productId);
        if (existingProduct is null)
        {
            throw new SoftwareNotFoundException($"Product with Id: {productId} does not exist.");
        }

        var productRevenue = await dbContext.Contracts
            .Where(c => c.SoftwareVersion.SoftwareId == productId)
            .SumAsync(c => c.FinalPrice);

        return $"Predicted revenue for {existingProduct.Name} = {productRevenue} PLN";
    }
    
    public async Task<string> CalculateRevenueByCurrency(string targetCurrency)
    {
        var revenue = await dbContext.Contracts
            .Where(c => c.IsSigned && c.PaidAmount == c.FinalPrice)
            .SumAsync(c => c.PaidAmount);

        if (string.Equals(targetCurrency, "PLN", StringComparison.OrdinalIgnoreCase))
        {
            return $"Calculated revenue = {revenue} PLN";
        }

        var exchangeRate = await currencyService.GetExchangeRate(targetCurrency);
        return $"Calculated revenue = {Math.Round(revenue * exchangeRate, 2)} {targetCurrency}";
    }
}