using Microsoft.AspNetCore.Mvc;
using RevenueRecognitionSystem.CustomExceptions;
using RevenueRecognitionSystem.RequestModels;
using RevenueRecognitionSystem.Services;

namespace RevenueRecognitionSystem.Controllers;

[ApiController]
[Route("api/payment")]
public class PaymentController(IPaymentService service) : ControllerBase
{
    [HttpPost("pay-contract-by-id/{id:int}")]
    public async Task<IActionResult> PayContractById(PaymentRequestModel model, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await service.PayContractById(model, id);
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ContractNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (PaymentException e)
        {
            return NotFound(e.Message);
        }

        return Created();
    }
    
}