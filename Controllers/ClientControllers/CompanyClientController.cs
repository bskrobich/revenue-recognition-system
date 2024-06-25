using Microsoft.AspNetCore.Mvc;
using RevenueRecognitionSystem.CustomExceptions;
using RevenueRecognitionSystem.RequestModels;
using RevenueRecognitionSystem.Services.ClientServices;

namespace RevenueRecognitionSystem.Controllers.ClientControllers;

[ApiController]
[Route("api/company-client")]
public class CompanyClientController(ICompanyClientService clientService) : ControllerBase
{
    [HttpPost("add-company")]
    public async Task<IActionResult> AddNewCompanyClient(AddCompanyClientRequestModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await clientService.AddCompanyClient(model);
        
        return Created();
    }

    [HttpPut("update-client/{KRS}")]
    public async Task<IActionResult> UpdateCompanyClient(UpdateCompanyClientRequestModel model, string KRS)
    {
        if (KRS.Length < 9 || KRS.Length > 14)
        {
            return BadRequest("KRS must be between 9-14 digits long.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await clientService.UpdateCompanyClient(model, KRS);
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }

        return Ok();
    }
}