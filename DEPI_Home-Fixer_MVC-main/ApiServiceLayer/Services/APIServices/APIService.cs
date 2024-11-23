using ApiServiceLayer.Services.APIServices;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

public class APIService : IAPIService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;


    public APIService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["ApiSettings:BaseUrl"]!;
    }


    public async Task<T> GetAsync<T>(string endPoint)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}{endPoint}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(result);
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(string endPoint)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}{endPoint}");
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();

        // Deserialize the result as a list/array of T
        return JsonConvert.DeserializeObject<IEnumerable<T>>(result);
    }

    public async Task<T> GetPageAsync<T>(string endPoint)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}{endPoint}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(result);
    }

    public async Task<T> PostAsync<T>(string endPoint, object data)
    {
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_baseUrl}{endPoint}", content);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(result);
    }

    public async Task PostWithOutBodyAsync(string endPoint, object data)
    {
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_baseUrl}{endPoint}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task<T> PutAsync<T>(string endPoint, object data)
    {
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseUrl}{endPoint}", content);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(result);
    }

    public async Task PutWithOutBodyAsync(string endPoint, object data)
    {
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseUrl}{endPoint}", content);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
    }

    public async Task PutWithOutBodyAsync(string endPoint)
    {
        var response = await _httpClient.PutAsync($"{_baseUrl}{endPoint}", null); 
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
    }

    public async Task DeleteAsync(string endPoint)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}{endPoint}");
        response.EnsureSuccessStatusCode();  
    }
}
