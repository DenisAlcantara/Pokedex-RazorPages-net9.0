
namespace Pokedex.Service
{
    public interface IPokedexService
    {
        Task<PokemonList> GetPokemonListAsync(int pageSize, int offset);
        Task<Pokemon> GetPokemonAsync(int id);
    }


    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<PokemonType> Types { get; set; }
        public PokemonSprites Sprites { get; set; }

    }

    public class PokemonType
    {
        public int Slot { get; set; }
        public Type Type { get; set; }

    }


    public class Type
    {
        public string Name { get; set; }
    }

    public class PokemonSprites
    {
        public string front_default { get; set; }
    }

    public class PokemonList
    {
        public int Count { get; set; }
        public List<PokemonListItem> Results { get; set; }
    }

    public class PokemonListItem
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Id => int.Parse(Url.Split('/')[^2]);
    }
}