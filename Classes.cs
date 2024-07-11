using System.Collections.Generic;


class Pokemon
{
    int PokemonId { get; set; }
    string Name { get; set; }
    string Image { get; set; }

    public virtual Type Type { get; set; }
}

class Type
{
    int TypeId { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string Image { get; set; }

    public virtual List<Pokemon> Pokemons { get; set; }
}