using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevenueRecognitionSystem.CustomExceptions;
using RevenueRecognitionSystem.RequestModels;
using RevenueRecognitionSystem.Services;

namespace RevenueRecognitionSystem.Controllers;

[ApiController]
[Route("api/contracts")]
public class ContractController(IContractService contractService) : ControllerBase 
{
    [Authorize]
    [HttpPost("create-contract")]
    public async Task<IActionResult> CreateNewContract(CreateContractRequestModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await contractService.CreateNewContract(model);
        }
        catch (SoftwareNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }

        return Created();
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("delete-contract/{id:int}")]
    public async Task<IActionResult> DeleteContract(int id)
    {
        try
        {
            await contractService.DeleteContract(id);
        }
        catch (ContractNotFoundException e)
        {
            return NotFound(e.Message);
        }

        return NoContent();
    }
    
}