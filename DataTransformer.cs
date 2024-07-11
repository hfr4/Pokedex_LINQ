
using System.Collections.Generic;
using System.Linq;

public static class DataTransformer
{
    public static List<Pokemon> AddTypesToPokemons(List<Pokemon> pokemons, Dictionary<string, Type> types)
    {
        foreach (var type in types)
        {
            foreach (var pokemonId in type.Value.PokemonIds)
            {
                var pokemon = pokemons.FirstOrDefault(p => p.PokemonId == pokemonId);
                if (pokemon != null)
                {
                    if (pokemon.Types == null)
                    {
                        pokemon.Types = new List<string>();
                    }
                    pokemon.Types.Add(type.Key);
                }
            }
        }

        return pokemons;
    }
}
