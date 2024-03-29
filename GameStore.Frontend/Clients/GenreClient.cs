using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenreClient
{
    private readonly HttpClient _httpClient;
    public GenreClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Genre[]?> GetGenresAsync() 
        => await _httpClient.GetFromJsonAsync<Genre[]>("genres");
}