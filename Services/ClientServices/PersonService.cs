using RevenueRecognitionSystem.Contexts;
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

    public Task UpdatePersonClient(UpdatePersonClientRequestModel request, string PESEL)
    {
        throw new NotImplementedException();
    }

    public Task DeletePersonClient()
    {
        throw new NotImplementedException();
    }
}