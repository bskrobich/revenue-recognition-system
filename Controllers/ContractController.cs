using Microsoft.AspNetCore.Mvc;
using RevenueRecognitionSystem.CustomExceptions;
using RevenueRecognitionSystem.RequestModels;
using RevenueRecognitionSystem.Services;

namespace RevenueRecognitionSystem.Controllers;

[ApiController]
[Route("api/contract")]
public class ContractController(IContractService contractService) : ControllerBase 
{

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
    
}