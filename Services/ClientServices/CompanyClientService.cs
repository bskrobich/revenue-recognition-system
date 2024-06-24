using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Contexts;
using RevenueRecognitionSystem.CustomExceptions;
using RevenueRecognitionSystem.Models;
using RevenueRecognitionSystem.RequestModels;

namespace RevenueRecognitionSystem.Services.ClientServices;

public interface ICompanyClientService
{
    Task AddCompanyClient(AddCompanyClientRequestModel request);
    Task UpdateCompanyClient(UpdateCompanyClientRequestModel request, string KRS);
}
public class CompanyClientService(DatabaseContext dbContext) : ICompanyClientService
{
    public async Task AddCompanyClient(AddCompanyClientRequestModel request)
    {
        var companyClient = new CompanyClient
        {
            KRS = request.KRS,
            Name = request.Name,
            Address = request.Address,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };

        await dbContext.Companies.AddAsync(companyClient);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateCompanyClient(UpdateCompanyClientRequestModel request, string KRS)
    {
        var existingCompanyClient = await dbContext.Companies
            .FirstOrDefaultAsync(c => c.KRS == KRS);
        if (existingCompanyClient is null)
        {
            throw new ClientNotFoundException($"Client with KRS: {KRS} does not exist.");
        }

        existingCompanyClient.Name = request.Name;
        existingCompanyClient.Address = request.Address;
        existingCompanyClient.Email = request.Email;
        existingCompanyClient.PhoneNumber = request.PhoneNumber;

        dbContext.Companies.Update(existingCompanyClient);
        await dbContext.SaveChangesAsync();
    }
}