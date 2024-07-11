using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using Raylib_cs;

class Pokemon
{
    public int PokemonId { get; set; }
    public int TypeId { get; set; }
    public required string Name { get; set; }
    public required string ImagePath { get; set; }
    public Texture2D Image { get; set; }
}

class Type
{
    public int TypeId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ImagePath { get; set; }
    public Texture2D Image { get; set; }

    public required List<int> PokemonIds { get; set; }
}

class XmlHelper
{
    public static List<Pokemon> LoadPokemonsFromXml(string xmlFilePath)
    {
        var xdoc = XDocument.Load(xmlFilePath);
        var pokemons = xdoc.Descendants("Pokemon").Select(p => new Pokemon
        {
            PokemonId = (int)    p.Element("PokemonId"),
            TypeId    = (int)    p.Element("TypeId"),
            Name      = (string) p.Element("Name"),
            ImagePath = (string) p.Element("ImagePath"),
            Image     = Raylib.LoadTexture((string) p.Element("ImagePath"))
        }).ToList();

        return pokemons;
    }
}

class JsonHelper
{
    public static List<Type> LoadTypesFromJson(string jsonFilePath)
    {
        var jsonString = File.ReadAllText(jsonFilePath);
        var types = JsonSerializer.Deserialize<List<Type>>(jsonString);

        foreach (var type in types) {
            type.Image = Raylib.LoadTexture(type.ImagePath);
        }

        return types;
    }
}
