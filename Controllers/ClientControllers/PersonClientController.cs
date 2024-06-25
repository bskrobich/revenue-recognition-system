using Microsoft.AspNetCore.Mvc;
using RevenueRecognitionSystem.CustomExceptions;
using RevenueRecognitionSystem.RequestModels;
using RevenueRecognitionSystem.Services.ClientServices;

namespace RevenueRecognitionSystem.Controllers.ClientControllers;

[ApiController]
[Route("api/person-client")]
public class PersonClientController(IPersonClientService clientService) : ControllerBase
{
    [HttpPost("add-client")]
    public async Task<IActionResult> AddNewPersonClient(AddPersonClientRequestModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        await clientService.AddPersonClient(model);

        return Created();
    }

    [HttpPut("update-client/{PESEL}")]
    public async Task<IActionResult> UpdatePersonClient(UpdatePersonClientRequestModel model, string PESEL)
    {
        if (PESEL.Length != 11)
        {
            return BadRequest("PESEL must be 11 digits long.");
        }
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await clientService.UpdatePersonClient(model, PESEL);
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }
        
        return Ok();
    }

    [HttpDelete("delete-client/{PESEL}")]
    public async Task<IActionResult> DeletePersonClient(string PESEL)
    {
        if (PESEL.Length != 11)
        {
            return BadRequest("PESEL must be 11 digits long.");
        }

        try
        {
            await clientService.DeletePersonClient(PESEL);
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }

        return NoContent();
    }
}