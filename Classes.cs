using System.Text.Json;
using System.Xml.Linq;
using Raylib_cs;

class Pokemon
{
    public int PokemonId { get; set; }
    public int TypeId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ImagePath { get; set; }
    public required string SoundPath { get; set; }
    public Texture2D Image { get; set; }
    public Sound Sound { get; set; }
}

class Type
{
    public int TypeId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ImagePath { get; set; }
    public required string SoundPath { get; set; }
    public Texture2D Image { get; set; }
    public Sound Sound { get; set; }
    public required List<int> PokemonIds { get; set; }
}

class XmlHelper
{
    public static List<Pokemon> LoadPokemonsFromXml(string path)
    {
        var xmlDocument = XDocument.Load(path);
        var pokemons = xmlDocument.Descendants("Pokemon").Select(p => new Pokemon
        {
            PokemonId   = (int)    p.Element("PokemonId"),
            TypeId      = (int)    p.Element("TypeId"),
            Name        = (string) p.Element("Name"),
            Description = (string) p.Element("Description"),
            ImagePath   = (string) p.Element("ImagePath"),
            SoundPath   = (string) p.Element("SoundPath"),
            Image       = Raylib.LoadTexture((string) p.Element("ImagePath")),
            Sound       = Raylib.LoadSound((string) p.Element("SoundPath")),
        }).ToList();

        return pokemons;
    }
}

class JsonHelper
{
    public static List<Type> LoadTypesFromJson(string path)
    {
        var jsonString = File.ReadAllText(path);
        var types = JsonSerializer.Deserialize<List<Type>>(jsonString).Select(t => new Type 
        {
            TypeId      = t.TypeId,
            Name        = t.Name,
            Description = t.Description,
            ImagePath   = t.ImagePath,
            SoundPath   = t.SoundPath,
            Image       = Raylib.LoadTexture(t.ImagePath),
            Sound       = Raylib.LoadSound(t.SoundPath),
            PokemonIds  = t.PokemonIds,
        })
        .ToList();

        return types;
    }
}
