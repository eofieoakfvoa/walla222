using System.Numerics;
using Raylib_cs;
class GameManager
{
    
    
    public void Init(Camera camera)
    {
        Raylib.BeginMode2D(camera.camera);
        camera.FollowPlayer(new Vector2(Player.Position.x, Player.Position.y));
        Player.GetMovement(true);
        Raylib.DrawTexturePro(Player.Sprite, new Rectangle(0,0,80,80), Player.Position, new Vector2(40,40), 0, Color.WHITE);  
    }
    private void DrawMap()
    {
    }
}