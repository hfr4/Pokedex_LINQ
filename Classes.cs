using System.Collections.Generic;


class Pokemon
{
    public int PokemonId { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }

    public virtual Type Type { get; set; }
}

class Type
{
    public int TypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

    public virtual List<Pokemon> Pokemons { get; set; }
}