using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Contexts;

namespace RevenueRecognitionSystem.Services;

public interface IRevenueService
{
    public Task<decimal> CalculateCurrentRevenue();

}
public class RevenueService(DatabaseContext dbContext) : IRevenueService
{
    public async Task<decimal> CalculateCurrentRevenue()
    {
        var currentRevenue = await dbContext.Contracts
            .Where(c => c.IsSigned && c.PaidAmount == c.FinalPrice)
            .SumAsync(c => c.PaidAmount);

        return currentRevenue;
    }
}