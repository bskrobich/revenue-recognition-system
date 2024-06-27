using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Contexts;
using RevenueRecognitionSystem.CustomExceptions;
using RevenueRecognitionSystem.Models;
using RevenueRecognitionSystem.RequestModels;

namespace RevenueRecognitionSystem.Services;

public interface IContractService
{
    Task CreateNewContract(CreateContractRequestModel model);
    Task DeleteContract(int contractId);
}

public class ContractService(DatabaseContext dbContext) : IContractService
{
    public async Task CreateNewContract(CreateContractRequestModel model)
    {
        var existingSoftware = await dbContext.Software
            .FirstOrDefaultAsync(s => s.Id == model.SoftwareId);
        if (existingSoftware is null)
        {
            throw new SoftwareNotFoundException(
                $"Software with Id: {model.SoftwareVersionId} does not exist."
            );   
        }
        
        var existingSoftwareVersion = await dbContext.Versions
            .FirstOrDefaultAsync(
                s => s.Id == model.SoftwareVersionId && s.SoftwareId == model.SoftwareId
            );
        if (existingSoftwareVersion is null)
        {
            throw new SoftwareNotFoundException(
                $"Software with version Id: {model.SoftwareVersionId} does not exist."
                );
        }
        
        var highestDiscount = await dbContext.Discounts
            .Where(d => d.SoftwareId == model.SoftwareId
                                && d.StartDate <= model.StartDate
                                && d.EndDate >= model.StartDate
                        )
            .OrderByDescending(d => d.PercentageValue)
            .FirstOrDefaultAsync();

        if (model.CompanyClientId is null)
        {
            var existingClient = await dbContext.People
                .FirstOrDefaultAsync(p => p.Id == model.PersonClientId);
            if (existingClient is null)
            {
                throw new ClientNotFoundException(
                    $"Client with Id: {model.PersonClientId} does not exist."
                    );
            }

            var finalPrice = model.Price;
            
            if (model.UpdateYears > 1)
            {
                finalPrice += (model.UpdateYears - 1) * 1000;
            }
            
            if (highestDiscount is not null)
            {
                finalPrice -= finalPrice * (highestDiscount.PercentageValue / 100);
            }

            var returningClient = await dbContext.Contracts
                .FirstOrDefaultAsync(
                    c => c.PersonClientId == model.PersonClientId && c.IsSigned == true
                    );
            if (returningClient is not null)
            {
                finalPrice -= 0.05m * finalPrice;
            }

            var newContract = new Contract
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                UpdateYears = model.UpdateYears,
                FinalPrice = finalPrice,
                IsSigned = false,
                PaidAmount = 0,
                SoftwareVersionId = model.SoftwareVersionId,
                PersonClientId = model.PersonClientId
            };

            await dbContext.Contracts.AddAsync(newContract);
        }
        
        if (model.PersonClientId is null)
        {
            var existingClient = await dbContext.Companies
                .FirstOrDefaultAsync(p => p.Id == model.CompanyClientId);
            if (existingClient is null)
            {
                throw new ClientNotFoundException(
                    $"Client with Id: {model.CompanyClientId} does not exist."
                );
            }

            var finalPrice = model.Price;
            
            if (model.UpdateYears > 1)
            {
                finalPrice += (model.UpdateYears - 1) * 1000;
            }
            
            if (highestDiscount is not null)
            {
                finalPrice -= finalPrice * (highestDiscount.PercentageValue / 100);
            }

            var returningClient = await dbContext.Contracts
                .FirstOrDefaultAsync(
                    c => c.CompanyClientId == model.CompanyClientId && c.IsSigned == true
                );
            if (returningClient is not null)
            {
                finalPrice -= 0.05m * finalPrice;
            }

            var newContract = new Contract
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                UpdateYears = model.UpdateYears,
                FinalPrice = finalPrice,
                IsSigned = false,
                PaidAmount = 0,
                SoftwareVersionId = model.SoftwareVersionId,
                CompanyClientId = model.CompanyClientId
            };

            await dbContext.Contracts.AddAsync(newContract);
        }

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteContract(int contractId)
    {
        var existingContract = await dbContext.Contracts
            .FirstOrDefaultAsync(c => c.Id == contractId);
        if (existingContract is null)
        {
            throw new ContractNotFoundException($"Contract with Id: {contractId} was not found.");
        }

        dbContext.Contracts.Remove(existingContract);
        await dbContext.SaveChangesAsync();
    }
}