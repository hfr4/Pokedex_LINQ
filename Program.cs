using Raylib_cs;

class Program
{
    public static void Main()
    {
        Raylib.InitWindow(800, 480, "Pokédex");

        Texture2D background = Raylib.LoadTexture("Data/Images/background.png");

        Texture2D pikachu    = Raylib.LoadTexture("Data/Images/pikachu.png");
        Texture2D charmander = Raylib.LoadTexture("Data/Images/charmander.png");
        Texture2D squirtle   = Raylib.LoadTexture("Data/Images/squirtle.png");
        Texture2D bulbasaur  = Raylib.LoadTexture("Data/Images/bulbasaur.png");
        Texture2D eevee      = Raylib.LoadTexture("Data/Images/eevee.png");
        Texture2D jolteon    = Raylib.LoadTexture("Data/Images/jolteon.png");
        Texture2D vaporeon   = Raylib.LoadTexture("Data/Images/vaporeon.png");
        Texture2D flareon    = Raylib.LoadTexture("Data/Images/flareon.png");
        Texture2D electabuzz = Raylib.LoadTexture("Data/Images/electabuzz.png");
        Texture2D horsea     = Raylib.LoadTexture("Data/Images/horsea.png");
        Texture2D caterpie   = Raylib.LoadTexture("Data/Images/caterpie.png");
        Texture2D magmar     = Raylib.LoadTexture("Data/Images/magmar.png");

        Texture2D normal    = Raylib.LoadTexture("Data/Images/normal.png");
        Texture2D electric  = Raylib.LoadTexture("Data/Images/electric.png");
        Texture2D fire      = Raylib.LoadTexture("Data/Images/fire.png");
        Texture2D water     = Raylib.LoadTexture("Data/Images/water.png");
        Texture2D grass     = Raylib.LoadTexture("Data/Images/grass.png");

        while (!Raylib.WindowShouldClose())
        {
            var mouse_position = Raylib.GetMousePosition();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            Raylib.DrawTexture(background, 0               , 0, new Color(255, 255, 255, 30));
            Raylib.DrawTexture(background, background.Width, 0, new Color(255, 255, 255, 30));

            Raylib.DrawText("Pokédex !", 12, 12, 20, Color.Black);

            Raylib.DrawTexture(pikachu   , 200, 200, Color.White);


            Raylib.DrawTexture(charmander, 300, 200, Color.White);
            Raylib.DrawTexture(squirtle  , 400, 200, Color.White);
            Raylib.DrawTexture(bulbasaur , 500, 200, Color.White);
            Raylib.DrawTexture(eevee     , 600, 200, Color.White);
            Raylib.DrawTexture(jolteon   , 700, 200, Color.White);
            Raylib.DrawTexture(vaporeon  , 200, 300, Color.White);
            Raylib.DrawTexture(flareon   , 300, 300, Color.White);
            Raylib.DrawTexture(electabuzz, 400, 300, Color.White);
            Raylib.DrawTexture(horsea    , 500, 300, Color.White);
            Raylib.DrawTexture(caterpie  , 600, 300, Color.White);
            Raylib.DrawTexture(magmar    , 700, 300, Color.White);

            Raylib.DrawTexture(normal    , 100, 100, Color.White);
            Raylib.DrawTexture(electric  , 200, 100, Color.White);
            Raylib.DrawTexture(fire      , 300, 100, Color.White);
            Raylib.DrawTexture(water     , 400, 100, Color.White);
            Raylib.DrawTexture(grass     , 500, 100, Color.White);

            var pikachu_rect = new Rectangle(200, 200, pikachu.Width, pikachu.Height);
            if (Raylib.CheckCollisionPointRec(mouse_position, pikachu_rect)) {
                Raylib.DrawText("Pikachu !", (int) mouse_position.X, (int) mouse_position.Y, 20, Color.Black);
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}

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