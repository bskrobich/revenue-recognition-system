using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Contexts;
using RevenueRecognitionSystem.CustomExceptions;
using RevenueRecognitionSystem.Models;
using RevenueRecognitionSystem.RequestModels;

namespace RevenueRecognitionSystem.Services;

public interface IPaymentService
{
    Task PayContractById(PaymentRequestModel model, int id);
}

public class PaymentService(DatabaseContext dbContext) : IPaymentService
{
    public async Task PayContractById(PaymentRequestModel model, int id)
    {
        var existingContract = await dbContext.Contracts
            .FirstOrDefaultAsync(c => c.Id == id && c.IsSigned == false
            );
        if (existingContract is null)
        {
            throw new ContractNotFoundException($"Contract with Id: {id} does not exist or is already paid.");
        }

        if (existingContract.EndDate < model.PaymentDate)
        {
            existingContract.PaidAmount = 0;
            dbContext.Contracts.Update(existingContract);
            await dbContext.SaveChangesAsync();
            throw new PaymentException($"Payment deadline for Contract Id: {id} has been exceeded.");
        }

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

            if (existingContract.PersonClientId != existingClient.Id)
            {
                throw new ContractNotFoundException(
                    $"There is no existing Contract with Id: {id} for Client with Id: {existingClient.Id}"
                        );
            }

            var newPayment = new Payment
            {
                PersonClientId = model.PersonClientId,
                ContractId = id,
                Amount = model.Amount
            };
            
            existingContract.PaidAmount += model.Amount;
            if (existingContract.PaidAmount > existingContract.FinalPrice)
            {
                existingContract.PaidAmount = existingContract.FinalPrice;
            }
            if (existingContract.PaidAmount == existingContract.FinalPrice)
            {
                existingContract.IsSigned = true;
            }

            await dbContext.Payments.AddAsync(newPayment);
            dbContext.Contracts.Update(existingContract);
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
            
            if (existingContract.CompanyClientId != existingClient.Id)
            {
                throw new ContractNotFoundException(
                    $"There is no existing Contract with Id: {id} for Client with Id: {existingClient.Id}"
                );
            }
            
            var newPayment = new Payment
            {
                CompanyClientId = model.CompanyClientId,
                ContractId = id,
                Amount = model.Amount
            };
            
            existingContract.PaidAmount += model.Amount;
            if (existingContract.PaidAmount == existingContract.FinalPrice)
            {
                existingContract.IsSigned = true;
            }

            await dbContext.Payments.AddAsync(newPayment);
            dbContext.Contracts.Update(existingContract);
        }
        await dbContext.SaveChangesAsync();
    }
}