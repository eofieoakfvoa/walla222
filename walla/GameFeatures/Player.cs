using Raylib_cs;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
/*
Här är olika saker som player controllerar, där man kan ändra Karaktärens movement lätt och så skapar jag en rectangle för musen 
som gör så det är lättare att selecta saker i t.ex menyer.
*/
public class Player
{
    public static Vector2 MousePosition = Raylib.GetMousePosition();
    public static Texture2D Sprite = Raylib.LoadTexture("Textures/Character.png");
    public static Rectangle Position = new(0,0, 40, 80);
    public static Rectangle mouseCursor = new(0,0, 25,25);
    readonly static Settings getSettings = new();
    private static void Movement(string Direction, int Speed)
    {
        if (Direction == "Horizontal")
        {
            Position.x += Speed;
        }
        if (Direction == "Verticle")
        {
            Position.y += Speed;
        }
    }
    public static string? ButtonClick(Rectangle hitBox, string ReturnName)
    {
        if (Raylib.CheckCollisionRecs(hitBox, mouseCursor) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            Console.WriteLine(ReturnName);
            return ReturnName;
        }
        return null;
    }
    public static void MouseCursorPosition()
    {
            MousePosition = Raylib.GetMousePosition();
            mouseCursor.x = MousePosition.X - (mouseCursor.width/2); 
            mouseCursor.y = MousePosition.Y - (mouseCursor.height/2); 
    }
    public static void GetMovement(bool OnOff)
    {
        
        if (Raylib.IsKeyDown((KeyboardKey)getSettings.walkUp))
        {
            Player.Movement("Verticle", -4);
        }
        if (Raylib.IsKeyDown((KeyboardKey)getSettings.walkDown))
        {
            Player.Movement("Verticle", 4);
        }
        if (Raylib.IsKeyDown((KeyboardKey)getSettings.walkLeft))
        {
            Player.Movement("Horizontal", -4);
        }
        if (Raylib.IsKeyDown((KeyboardKey)getSettings.walkRight))
        {
            Player.Movement("Horizontal", 4);
        }
    }
}
