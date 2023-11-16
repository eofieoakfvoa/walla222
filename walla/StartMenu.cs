using System;
using Raylib_cs;

public static class StartMenu
{
    public static Rectangle ControlsButton = new Rectangle(500,550,500,100);
    public static Rectangle StartButton = new Rectangle(500,500,500,100);
            //Raylib.DrawText("Press Space To Start", 500, 500, 30, Color.BLACK);
    /*
    jag kollar ifall personens mus och knappen collidar då ifall den klickar så skickar den tillbaka vilken scene.
    */
    public static string buttonClick(Player Character)
    {
        if (Raylib.CheckCollisionRecs(ControlsButton, Player.MouseCursor) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            return "Controls";
        }
        if (Raylib.CheckCollisionRecs(StartButton, Player.MouseCursor) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {         
            return "Game";
        }
        return "Start";
    }
    
    
}
