using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevenueRecognitionSystem.CustomExceptions;
using RevenueRecognitionSystem.Services;

namespace RevenueRecognitionSystem.Controllers;

[ApiController]
[Route("api/revenue")]
public class RevenueController(IRevenueService service) : ControllerBase
{
    [Authorize]
    [HttpGet("calculate")]
    public async Task<IActionResult> GetRevenue()
    { 
        var revenue = await service.CalculateRevenue();
        return Ok(revenue);
    }
    
    [Authorize]
    [HttpGet("predict")]
    public async Task<IActionResult> GetPredictedRevenue()
    { 
        var revenue = await service.CalculatePredictedRevenue();
        return Ok(revenue);
    }

    [Authorize]
    [HttpGet("calculate-for-product")]
    public async Task<IActionResult> GetRevenueForProduct([FromQuery] int productId)
    {
        try
        {
            var revenue = await service.CalculateRevenueForProduct(productId);
            return Ok(revenue);
        }
        catch (SoftwareNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [Authorize]
    [HttpGet("predict-for-product")]
    public async Task<IActionResult> GetPredictedRevenueForProduct([FromQuery] int productId)
    {
        try
        {
            var revenue = await service.CalculatePredictedRevenueForProduct(productId);
            return Ok(revenue);
        }
        catch (SoftwareNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [Authorize]
    [HttpGet("calculate-by-currency")]
    public async Task<IActionResult> GetRevenueByCurrency([FromQuery] string targetCurrency = "PLN")
    {
        try
        {
            var revenue = await service.CalculateRevenueByCurrency(targetCurrency);
            return Ok(revenue);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}