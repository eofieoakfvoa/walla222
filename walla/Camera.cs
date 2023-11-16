using System;
using Raylib_cs;
using System.Numerics;
/*
Här har jag allt för kameran, jag gjorde en egen fil för kameran eftersom att ifall jag hade gjort ett störe spel
så skulle kameran va en viktig del där jag kanske har många olika modes den kan va i t.ex att den rör sig från en position
till en annan istället för att va locked till personen
*/
public class Camera
{
    public Camera2D camera;
    public Camera(Settings Settings)
    {
        camera.zoom = (float)1.25;
        camera.rotation = 0;
        camera.offset = new Vector2(Settings.ScreenWidth / 2, Settings.ScreenHeight / 2);

    }
    public void cameraup(Player Character, Settings Settings)
    {
        camera.target = new Vector2(Player.Position.x, Player.Position.y);

    }
}
