using System;
using Raylib_cs;
/*
Det här används för att rita ut de olika menyerna i spelet, logiken för menyerna finns I StartMenu.cs
*/
public static class Menu
{
    public static void Draw(string Scene)
    {
        if (Scene == "Start")
        {
        Raylib.DrawText("Press Here To Start!", 500, 500, 30, Color.BLACK);
        Raylib.DrawText("WASD to move", 50, 600, 30, Color.BLACK);
        Raylib.DrawText("Press E to use tool", 50, 550, 30, Color.BLACK);
        Raylib.DrawText("1-6 to cycle inventory", 50, 500, 30, Color.BLACK);
        Raylib.DrawText("C debug inventory", 50, 450, 30, Color.BLACK);
        Raylib.DrawText("ESC to exit", 50, 400, 30, Color.BLACK);
        Raylib.DrawRectangle((int)StartMenu.ControlsButton.x, (int)StartMenu.ControlsButton.y, (int)StartMenu.ControlsButton.width, (int)StartMenu.ControlsButton.height, Color.BLACK);
        Raylib.DrawRectangle((int)Player.MouseCursor.x, (int)Player.MouseCursor.y, (int)Player.MouseCursor.width, (int)Player.MouseCursor.height, Color.BLACK);
        }
        if (Scene == "Controls")
        {
        }
    }
}
