using System.Numerics;
using Raylib_cs;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        Raylib.InitWindow(800, 480, "Pokédex");

        Texture2D background = Raylib.LoadTexture("Data/Images/background.png");

        Texture2D normal    = Raylib.LoadTexture("Data/Images/normal.png");
        Texture2D electric  = Raylib.LoadTexture("Data/Images/electric.png");
        Texture2D fire      = Raylib.LoadTexture("Data/Images/fire.png");
        Texture2D water     = Raylib.LoadTexture("Data/Images/water.png");
        Texture2D grass     = Raylib.LoadTexture("Data/Images/grass.png");

        // var types  = JsonHelper.LoadTypesFromJson("Data/Types.json");
        var pokemons = XmlHelper.LoadPokemonsFromXml("Data/Pokemons.xml");



        Vector2 bg_offset = new Vector2(0, 0);


        while (!Raylib.WindowShouldClose())
        {
            var mouse_position = Raylib.GetMousePosition();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            // Draw moving background
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

            Raylib.DrawText("Pokédex !", 12, 12, 20, Color.Black);

            var i = 0;
            foreach (var pokemon in pokemons) {
                var x = i % 6;
                var y = i / 6;

                Raylib.DrawTexture(pokemon.Image, x * 100 + 100, y * 100 + 200, Color.White);
                i += 1;
            }

            Raylib.DrawText("All"        , 50 , 120, 20, Color.Black);
            Raylib.DrawTexture(normal    , 100, 100, Color.White);
            Raylib.DrawTexture(electric  , 200, 100, Color.White);
            Raylib.DrawTexture(fire      , 300, 100, Color.White);
            Raylib.DrawTexture(water     , 400, 100, Color.White);
            Raylib.DrawTexture(grass     , 500, 100, Color.White);

            {
                string element_name = "Normal";
                string element_desc = "This is a normal element.";

                var element_rect = new Rectangle(100, 100, normal.Width, normal.Height);
                if (Raylib.CheckCollisionPointRec(mouse_position, element_rect)) {
                    var text_rect = new Rectangle( (int) mouse_position.X + 15, (int) mouse_position.Y + 15, 300, 100);
                    Raylib.DrawRectangleRec(text_rect, Color.White);
                    Raylib.DrawRectangleLinesEx(text_rect, 1, Color.Black);
                    Raylib.DrawText(element_name, (int) text_rect.X + 5, (int) text_rect.Y + 5     , 20, Color.Black);
                    Raylib.DrawText(element_desc, (int) text_rect.X + 5, (int) text_rect.Y + 5 + 25, 10, Color.Gray);

                    if (Raylib.IsMouseButtonPressed(MouseButton.Left)) {
                        Console.WriteLine("Press Normal !");
                    }
                }
            }

            {
                string element_name = "Electric";
                string element_desc = "This is a electic element.";

                var element_rect = new Rectangle(200, 100, electric.Width, electric.Height);
                if (Raylib.CheckCollisionPointRec(mouse_position, element_rect)) {
                    var text_rect = new Rectangle( (int) mouse_position.X + 15, (int) mouse_position.Y + 15, 300, 100);
                    Raylib.DrawRectangleRec(text_rect, Color.White);
                    Raylib.DrawRectangleLinesEx(text_rect, 1, Color.Black);
                    Raylib.DrawText(element_name, (int) text_rect.X + 5, (int) text_rect.Y + 5     , 20, Color.Black);
                    Raylib.DrawText(element_desc, (int) text_rect.X + 5, (int) text_rect.Y + 5 + 25, 10, Color.Gray);

                    if (Raylib.IsMouseButtonPressed(MouseButton.Left)) {
                        Console.WriteLine("Press Electric !");
                    }
                }
                
            }

            {
                string element_name = "Fire";
                string element_desc = "This is a fire element.";

                var element_rect = new Rectangle(300, 100, fire.Width, fire.Height);
                if (Raylib.CheckCollisionPointRec(mouse_position, element_rect)) {
                    var text_rect = new Rectangle( (int) mouse_position.X + 15, (int) mouse_position.Y + 15, 300, 100);
                    Raylib.DrawRectangleRec(text_rect, Color.White);
                    Raylib.DrawRectangleLinesEx(text_rect, 1, Color.Black);
                    Raylib.DrawText(element_name, (int) text_rect.X + 5, (int) text_rect.Y + 5     , 20, Color.Black);
                    Raylib.DrawText(element_desc, (int) text_rect.X + 5, (int) text_rect.Y + 5 + 25, 10, Color.Gray);

                    if (Raylib.IsMouseButtonPressed(MouseButton.Left)) {
                        Console.WriteLine("Press Fire !");
                    }
                }
                
            }

            {
                string element_name = "Water";
                string element_desc = "This is a water element.";

                var element_rect = new Rectangle(400, 100, water.Width, water.Height);
                if (Raylib.CheckCollisionPointRec(mouse_position, element_rect)) {
                    var text_rect = new Rectangle( (int) mouse_position.X + 15, (int) mouse_position.Y + 15, 300, 100);
                    Raylib.DrawRectangleRec(text_rect, Color.White);
                    Raylib.DrawRectangleLinesEx(text_rect, 1, Color.Black);
                    Raylib.DrawText(element_name, (int) text_rect.X + 5, (int) text_rect.Y + 5     , 20, Color.Black);
                    Raylib.DrawText(element_desc, (int) text_rect.X + 5, (int) text_rect.Y + 5 + 25, 10, Color.Gray);

                    if (Raylib.IsMouseButtonPressed(MouseButton.Left)) {
                        Console.WriteLine("Press Water !");
                    }
                }
                
            }

            {
                string element_name = "Grass";
                string element_desc = "This is a grass element.";
                
                var element_rect = new Rectangle(500, 100, grass.Width, grass.Height);
                if (Raylib.CheckCollisionPointRec(mouse_position, element_rect)) {
                    var text_rect = new Rectangle( (int) mouse_position.X + 15, (int) mouse_position.Y + 15, 300, 100);
                    Raylib.DrawRectangleRec(text_rect, Color.White);
                    Raylib.DrawRectangleLinesEx(text_rect, 1, Color.Black);
                    Raylib.DrawText(element_name, (int) text_rect.X + 5, (int) text_rect.Y + 5     , 20, Color.Black);
                    Raylib.DrawText(element_desc, (int) text_rect.X + 5, (int) text_rect.Y + 5 + 25, 10, Color.Gray);

                    if (Raylib.IsMouseButtonPressed(MouseButton.Left)) {
                        Console.WriteLine("Press Grass !");
                    }
                }
                
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}

