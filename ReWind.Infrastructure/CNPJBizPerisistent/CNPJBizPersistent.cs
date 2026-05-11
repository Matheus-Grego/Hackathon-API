using System.Text;
using System.Text.Json;
using HackathonEquipe6.Application.ICNPJBizPersistance;
using HackathonEquipe6.Application.Models;
using Microsoft.Extensions.Configuration;

namespace HackathonEquipe6.Infrastructure.CNPJBizPerisistent;

public class CNPJBizPersistent : ICNPJBizPersistance
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public CNPJBizPersistent(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;

        _httpClient.BaseAddress = new Uri(
            _configuration["CNPJBiz:BaseUrl"]!
        );

        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<CNPJApiViewModel> GetEmpresaByCNPJAsync(string cnpj)
    {
        var apiKey = _configuration["CNPJBiz:ApiKey"];

        cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

        var requestBody = new
        {
            cnpj,
            filial = false
        };

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "/api/v2/empresas/cnpj"
        );

        request.Content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json"
        );

        request.Headers.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        request.Headers.Add("Accept", "application/json");

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            return new CNPJApiViewModel();
        }
        
        var content = await response.Content.ReadAsStringAsync();
        
        var data = JsonSerializer.Deserialize<JsonElement>(content);

        var result = new CNPJApiViewModel
        {
            Email = data.GetProperty("email").GetString(),
            ZipCode = data.GetProperty("endereco")
                        .GetProperty("cep")
                        .GetString(),
            Address = $"{data.GetProperty("endereco").GetProperty("logradouro").GetString()}, " +
                      $"{data.GetProperty("endereco").GetProperty("numero").GetString()}",
            Telefones = data.GetProperty("telefones")
                .EnumerateArray()
                .Select(t => new TelefoneDto
                {
                    Telefone = t.GetProperty("telefone").GetString(),
                    Whatsapp = t.GetProperty("whatsapp").GetBoolean()
                })
                .ToList()
        };

        return result;
    }
}
