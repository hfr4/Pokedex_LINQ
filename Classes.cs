using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using Raylib_cs;

class Pokemon
{
    public int PokemonId { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public Texture2D Image { get; set; }
}

class Type
{
    public int TypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public Texture2D Image { get; set; }

    public List<Pokemon> PokemonIds { get; set; }
}

class XmlHelper
{
    public static List<Pokemon> LoadPokemonsFromXml(string xmlFilePath)
    {
        var xdoc = XDocument.Load(xmlFilePath);
        var pokemons = xdoc.Descendants("Pokemon").Select(p => new Pokemon
        {
            PokemonId = (int)    p.Element("PokemonId"),
            Name      = (string) p.Element("Name"),
            ImagePath = (string) p.Element("ImagePath"),
            Image     = Raylib.LoadTexture((string) p.Element("ImagePath"))
        }).ToList();

        return pokemons;
    }
}

class JsonHelper
{
    public static Dictionary<string, Type> LoadTypesFromJson(string jsonFilePath)
    {
        var jsonString = File.ReadAllText(jsonFilePath);
        var types = JsonSerializer.Deserialize<Dictionary<string, Type>>(jsonString);
        return types;
    }
}
