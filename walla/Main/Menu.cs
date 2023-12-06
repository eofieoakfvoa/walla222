using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
/*
Det här används för att rita ut de olika menyerna i spelet, logiken för menyerna finns I StartMenu.cs
*/
public static class Menu
{
    internal static void Draw(Renderer.Scenes Scene)
    {
        if (Scene == Renderer.Scenes.StartMenu)
        {
            string? changeScene;
            Rectangle ControlsButton = new(500,575,500,100);
            Rectangle StartButton = new(500,450,500,100);
            Raylib.DrawText("Press Here To Start!", 500, 500, 30, Color.BLACK);
            Raylib.DrawText("WASD to move", 50, 600, 30, Color.BLACK);
            Raylib.DrawText("Press E to use tool", 50, 550, 30, Color.BLACK);
            Raylib.DrawText("1-6 to cycle inventory", 50, 500, 30, Color.BLACK);
            Raylib.DrawText("C debug inventory", 50, 450, 30, Color.BLACK);
            Raylib.DrawText("ESC to exit", 50, 400, 30, Color.BLACK);
            Raylib.DrawRectangle((int)ControlsButton.x, (int)ControlsButton.y, (int)ControlsButton.width, (int)ControlsButton.height, Color.BLACK);
            Raylib.DrawRectangle((int)StartButton.x, (int)StartButton.y, (int)StartButton.width, (int)StartButton.height, Color.PINK);
            Raylib.DrawRectangle((int)Player.mouseCursor.x, (int)Player.mouseCursor.y, (int)Player.mouseCursor.width, (int)Player.mouseCursor.height, Color.BLACK);
            changeScene = Player.ButtonClick(ControlsButton, "Controls");
            changeScene = Player.ButtonClick(StartButton, "Game");
            //Controlls Knappen fungerar inte, ksk göra ett Button class som har detta inbyggt // Typ UIElemets class,, Som har fungerande layers i rendern, basically att For loop för varje layer, detta gör ju så den gör i ordningen
            if (changeScene != null)
            {
                bool Parse = Enum.TryParse(changeScene, out Renderer.Scenes Result);
                if(Parse)
                {
                    Debug.WriteLine(Result);
                    Renderer.SetCurrentScene = Result;
                }
                
            }
        }
        if (Scene == Renderer.Scenes.Controls)
        {
        }
    }
}
