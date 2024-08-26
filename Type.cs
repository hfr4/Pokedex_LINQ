using System.Text.Json;
using Raylib_cs;

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
