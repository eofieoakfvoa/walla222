using System.Diagnostics;
using System.Numerics;
using Raylib_cs;

bool walking;


Settings Settings = new();
Camera Camera = new(Settings);

Renderer GameRenderer = new();


Settings.Init();
Map.Render();
while (!Raylib.WindowShouldClose())
{
    Player.MouseCursorPosition();
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    Renderer.Scenes Scene = Renderer.GetCurrentScene();
    //Debug.WriteLine(Scene);
    if(Scene == Renderer.Scenes.Controls || Scene == Renderer.Scenes.StartMenu)
    {
        Menu.Draw(Scene);
    }
    else
    {
        
    }

    Raylib.EndDrawing();
}
