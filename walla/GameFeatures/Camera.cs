using System;
using Raylib_cs;
using System.Numerics;

public class Camera
{
    public Camera2D camera;
    public Camera(Settings Settings)
    {
        camera.zoom = (float)1.25;
        camera.rotation = 0;
        camera.offset = new Vector2(Settings.ScreenWidth / 2, Settings.ScreenHeight / 2);
    }
    public void FollowPlayer(Vector2 playerPosition)
    {
        //Istället för seperate Cameramodes ha en function där man kan byta mellan
        camera.target = playerPosition;

    }
}
