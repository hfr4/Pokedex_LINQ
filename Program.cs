using System.Numerics;
using Raylib_cs;

class Program
{
    public static void Main()
    {
        Raylib.SetTraceLogLevel(TraceLogLevel.None);
        Raylib.InitWindow(800, 480, "Pokedex");

        var background = Raylib.LoadTexture("Data/Images/background.png");
        Vector2 bg_offset = new Vector2(0, 0);

        var types    = JsonHelper.LoadTypesFromJson("Data/Datasources/Types.json");
        var pokemons = XmlHelper.LoadPokemonsFromXml("Data/Datasources/Pokemons.xml");

        var pokemons_by_type = new Dictionary<string, List<Pokemon>>();

        foreach (var type in types) {
            var pokemonsReq = 
                from p in pokemons
                join t in types 
                on p.TypeId equals t.TypeId
                where t.Name == type.Name
                select p;

            pokemons_by_type.Add(type.Name, pokemonsReq.ToList());
        }

        var shown_pokemons = new List<Pokemon>();
        shown_pokemons = pokemons;

        while (!Raylib.WindowShouldClose())
        {
            var mouse_position = Raylib.GetMousePosition();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            // Draw background
            {
                bg_offset.X += (float) 0.05;
                bg_offset.Y += (float) 0.05;
        
                if (bg_offset.X > background.Width)  bg_offset.X = 0;
                if (bg_offset.Y > background.Height) bg_offset.Y = 0;

                var bg_color = new Color(255, 255, 255, 30);
    
                Raylib.DrawTexture(background, (int) bg_offset.X - background.Width, (int) bg_offset.Y - background.Height, bg_color);
                Raylib.DrawTexture(background, (int) bg_offset.X - background.Width, (int) bg_offset.Y                    , bg_color);
                Raylib.DrawTexture(background, (int) bg_offset.X - background.Width, (int) bg_offset.Y + background.Height, bg_color);
                Raylib.DrawTexture(background, (int) bg_offset.X                   , (int) bg_offset.Y - background.Height, bg_color);
                Raylib.DrawTexture(background, (int) bg_offset.X                   , (int) bg_offset.Y                    , bg_color);
                Raylib.DrawTexture(background, (int) bg_offset.X                   , (int) bg_offset.Y + background.Height, bg_color);
                Raylib.DrawTexture(background, (int) bg_offset.X + background.Width, (int) bg_offset.Y - background.Height, bg_color);
                Raylib.DrawTexture(background, (int) bg_offset.X + background.Width, (int) bg_offset.Y                    , bg_color);
                Raylib.DrawTexture(background, (int) bg_offset.X + background.Width, (int) bg_offset.Y + background.Height, bg_color);
            }

            // Draw title
            Raylib.DrawText("Click on a Type to filter Pokemons of this Type !", 12, 12, 20, Color.Black);

            // Draw Pokemons
            var i = 0;
            foreach (var pokemon in shown_pokemons) {
                var coord_x = i % 6;
                var coord_y = i / 6;

                var x = coord_x * 100 + 100;
                var y = coord_y * 100 + 200;

                Raylib.DrawTexture(pokemon.Image, x, y, Color.White);

                i += 1;
            }

            // Draw "All" button
            {
                var x = 110;
                var y = 111;

                Raylib.DrawText("All", x, y, 30, Color.Black);
                var element_rect = new Rectangle(x - 10, y - 10, 60, 60);

                if (Raylib.CheckCollisionPointRec(mouse_position, element_rect)) {
                    if (Raylib.IsMouseButtonPressed(MouseButton.Left)) {
                        shown_pokemons = pokemons;
                    }
                }
            }

            // Draw "Types"
            i = 0;
            foreach (var type in types) {
                var x = i * 100 + 200;
                var y = 100;

                Raylib.DrawTexture(type.Image, x, y, Color.White);

                i += 1;
            }

            // Draw Pokemons pop-ups
            i = 0;
            foreach (var pokemon in shown_pokemons) {
                var coord_x = i % 6;
                var coord_y = i / 6;

                var x = coord_x * 100 + 100;
                var y = coord_y * 100 + 200;
                
                var element_name = pokemon.Name;
                var element_desc = "This is a description.";
                var element_rect = new Rectangle(x, y, pokemon.Image.Width, pokemon.Image.Height);

                if (Raylib.CheckCollisionPointRec(mouse_position, element_rect)) {
                    var text_rect = new Rectangle( (int) mouse_position.X + 15, (int) mouse_position.Y + 15, 300, 100);
                    Raylib.DrawRectangleRec(text_rect, Color.White);
                    Raylib.DrawRectangleLinesEx(text_rect, 1, Color.Black);
                    Raylib.DrawText(element_name, (int) text_rect.X + 5, (int) text_rect.Y + 5     , 20, Color.Black);
                    Raylib.DrawText(element_desc, (int) text_rect.X + 5, (int) text_rect.Y + 5 + 25, 10, Color.Gray);
                }

                i += 1;
            }

            // Draw Types pop-ups
            i = 0;
            foreach (var type in types) {
                var x = i * 100 + 200;
                var y = 100;

                var element_name = type.Name;
                var element_desc = type.Description;
                var element_rect = new Rectangle(x, y, type.Image.Width, type.Image.Height);

                if (Raylib.CheckCollisionPointRec(mouse_position, element_rect)) {
                    var text_rect = new Rectangle( (int) mouse_position.X + 15, (int) mouse_position.Y + 15, 300, 100);
                    Raylib.DrawRectangleRec(text_rect, Color.White);
                    Raylib.DrawRectangleLinesEx(text_rect, 1, Color.Black);
                    Raylib.DrawText(element_name, (int) text_rect.X + 5, (int) text_rect.Y + 5     , 20, Color.Black);
                    Raylib.DrawText(element_desc, (int) text_rect.X + 5, (int) text_rect.Y + 5 + 25, 10, Color.Gray);

                    if (Raylib.IsMouseButtonPressed(MouseButton.Left)) {
                        shown_pokemons = pokemons_by_type[type.Name];
                    }
                }

                i += 1;
            }


            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}

