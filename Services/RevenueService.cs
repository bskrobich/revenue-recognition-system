using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Contexts;
using RevenueRecognitionSystem.CustomExceptions;

namespace RevenueRecognitionSystem.Services;

public interface IRevenueService
{
    public Task<string> CalculateRevenue();
    public Task<string> CalculateRevenueForProduct(int productId);

}
public class RevenueService(DatabaseContext dbContext) : IRevenueService
{
    public async Task<string> CalculateRevenue()
    {
        var currentRevenue = await dbContext.Contracts
            .Where(c => c.IsSigned && c.PaidAmount == c.FinalPrice)
            .SumAsync(c => c.PaidAmount);

        return $"Calculated revenue = {currentRevenue} PLN";
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
}