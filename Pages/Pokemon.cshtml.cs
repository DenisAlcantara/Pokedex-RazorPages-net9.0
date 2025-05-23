using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokedex.Service;

namespace Pokedex.Pages
{
    public class PokemonModel : PageModel
    {
        private readonly IPokedexService _pokedexService;

        public Pokemon Pokemon { get; set; }

        public PokemonModel(IPokedexService pokedexService)
        {
            _pokedexService = pokedexService;
        }

        public async Task OnGetAsync(int id)
        {
            Pokemon = await _pokedexService.GetPokemonAsync(id);
        }
    }
}
