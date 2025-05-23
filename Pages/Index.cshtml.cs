using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokedex.Service;

namespace Pokedex.Pages;

public class IndexModel : PageModel
{
    private readonly IPokedexService _pokeApiService;

    public PokemonList PokemonList { get; set; }
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 20;

    public IndexModel(IPokedexService pokeApiService)
    {
        _pokeApiService = pokeApiService;
    }

    public async Task OnGetAsync(int? currentPage)
    {
        CurrentPage = currentPage ?? 1;
        int offset = (CurrentPage - 1) * PageSize;
        PokemonList = await _pokeApiService.GetPokemonListAsync(PageSize, offset);
    }
}