using System.Numerics;
using Raylib_cs;

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
                }
                
                if (Raylib.IsMouseButtonPressed(MouseButton.Left)) {
                    Console.WriteLine("Press Electric !");
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
                }
                
                if (Raylib.IsMouseButtonPressed(MouseButton.Left)) {
                    Console.WriteLine("Press Fire !");
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
                }
                
                if (Raylib.IsMouseButtonPressed(MouseButton.Left)) {
                    Console.WriteLine("Press Water !");
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
                }
                
                if (Raylib.IsMouseButtonPressed(MouseButton.Left)) {
                    Console.WriteLine("Press Grass !");
                }
            }


            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}

