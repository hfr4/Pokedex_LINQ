
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;

public static class XmlHelper
{
    public static List<Pokemon> LoadPokemonsFromXml(string xmlFilePath)
    {
        var xdoc = XDocument.Load(xmlFilePath);
        var pokemons = xdoc.Descendants("Pokemon").Select(p => new Pokemon
        {
            PokemonId = (int)p.Element("PokemonId"),
            Name = (string)p.Element("Name"),
            Image = (string)p.Element("Image")
        }).ToList();

        return pokemons;
    }
}

public static class JsonHelper
{
    public static Dictionary<string, Type> LoadTypesFromJson(string jsonFilePath)
    {
        var jsonString = File.ReadAllText(jsonFilePath);
        var types = JsonSerializer.Deserialize<Dictionary<string, Type>>(jsonString);
        return types;
    }
}
