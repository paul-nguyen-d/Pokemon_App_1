using Microsoft.EntityFrameworkCore;
using PokemonApp.Interfaces;
using PokemonApp.Models;
using PokemonApp.PokemonAppDbContext;

namespace PokemonApp.Services
{
    public class PokemonServices : IPokemonServices
    {
        private readonly PokemonDbContext _context;

        public PokemonServices(PokemonDbContext context)
        {
            _context = context;
        }
        public async Task<Pokemon> GetPokemon(int id)
        {
            return await _context.Pokemons.FirstOrDefaultAsync(option => option.Id == id);
        }

        public async Task<List<Pokemon>> GetPokemons()
        {
            return await _context.Pokemons.ToListAsync();
        }

        public async Task<bool> PostPokemon(Pokemon pokemon)
        {
            await _context.Pokemons.AddAsync(pokemon);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
