using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private HttpClient _httpClient;
    public GamesClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<GameSummary[]?> GetGamesAsync() 
        => await _httpClient.GetFromJsonAsync<GameSummary[]>("games");

    public async Task AddGameAsync(GameDetails game)
        => await _httpClient.PostAsJsonAsync("games", game);

    public async Task<GameDetails> GetGameAsync(int id)
        => await _httpClient.GetFromJsonAsync<GameDetails>($"games/{id}")
           ?? throw new Exception("Could not find game!");

    public async Task UpdateGameAsync(GameDetails updatedGame)
        => await _httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);

    public async Task DeleteGameAsync(int id)
        => await _httpClient.DeleteAsync($"games/{id}");
}