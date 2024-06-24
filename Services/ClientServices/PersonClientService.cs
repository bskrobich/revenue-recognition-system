using RevenueRecognitionSystem.Contexts;
using RevenueRecognitionSystem.CustomExceptions;
using RevenueRecognitionSystem.Models;
using RevenueRecognitionSystem.RequestModels;

namespace RevenueRecognitionSystem.Services.ClientServices;

public interface IPersonClientService
{
    Task AddPersonClient(AddPersonClientRequestModel request);
    Task UpdatePersonClient(UpdatePersonClientRequestModel request, string PESEL);
    Task DeletePersonClient();

}

public class PersonClientService(DatabaseContext dbContext) : IPersonClientService
{
    public async Task AddPersonClient(AddPersonClientRequestModel request)
    {
        var personClient = new PersonClient
        {
            PESEL = request.PESEL,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.Address,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };

        await dbContext.People.AddAsync(personClient);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdatePersonClient(UpdatePersonClientRequestModel request, string PESEL)
    {
        var existingPersonClient = await dbContext.People.FindAsync(PESEL);
        if (existingPersonClient is null)
        {
            throw new ClientNotFoundException($"Client with PESEL: {PESEL} does not exist.");
        }

        existingPersonClient.FirstName = request.FirstName;
        existingPersonClient.LastName = request.LastName;
        existingPersonClient.Address = request.Address;
        existingPersonClient.Email = request.Email;
        existingPersonClient.PhoneNumber = request.PhoneNumber;

        dbContext.People.Update(existingPersonClient);
        await dbContext.SaveChangesAsync();
    }

    public Task DeletePersonClient()
    {
        throw new NotImplementedException();
    }
}