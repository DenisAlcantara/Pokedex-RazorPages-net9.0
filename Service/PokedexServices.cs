using Newtonsoft.Json;

namespace Pokedex.Service
{
    public class PokedexServices : IPokedexService
    {
        private readonly HttpClient _httpClient;


        public PokedexServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }


        public async Task<Pokemon> GetPokemonAsync(int id)
        {
            var response = await _httpClient.GetAsync($"pokemon/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Pokemon>(content);
        }


        public async Task<PokemonList> GetPokemonListAsync(int limit = 20, int offset = 0)
        {
            var response = await _httpClient.GetAsync($"pokemon?list={limit}&offset={offset}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PokemonList>(content);
        }
    }
}
