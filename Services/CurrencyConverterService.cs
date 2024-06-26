using System.Text.Json;
using RevenueRecognitionSystem.ResponseModels;

namespace RevenueRecognitionSystem.Services;

public interface ICurrencyConverterService
{
    Task<decimal> GetExchangeRate(string targetCurrency);
}
public class CurrencyConverterService(IConfiguration configuration, HttpClient httpClient) : ICurrencyConverterService
{
    public async Task<decimal> GetExchangeRate(string targetCurrency)
    {
        var apiKey = configuration["ExchangeRateApiKey"];
        var requestUrl = $"https://v6.exchangerate-api.com/v6/{apiKey}/latest/PLN";

        var response = await httpClient.GetAsync(requestUrl);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        var data = JsonSerializer.Deserialize<ExchangeRateResponse>(responseContent);
        if (data?.Rates == null || !data.Rates.TryGetValue(targetCurrency.ToUpper(), out var rate))
        {
            throw new Exception("Target currency not found or no rates available.");
        }

        return rate;
    }
}