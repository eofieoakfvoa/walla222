using System.Numerics;
using Raylib_cs;
public class Chunk
{
    public List<Cell> cellsInChunk = new();
    public Vector2 chunkPosition;

}
public class Cell
{
    public bool Walkable;
    public bool Farmable;
    public bool playerStanding;
    public bool interactable;
    public string Texture = "Textures/black.png";

    public Vector2 Position;

    /*
    <T> är något man skriver in när man kallar functionen dock så i det här fallet står det where T : Cell, new().
    detta betyder att T måste inheritance från Cell och den måste kunna göra new(), så hade jag skrivit t.ex 
    changeTile<Grass> så skulle det fungera medans någon annan class som inte har inheritance av Cell skulle inte fungera
    */
    public T changeTile<T>(Cell old) where T : Cell, new()
    {
        T newTile = new();
        newTile.Position = old.Position;
        return newTile;
        //jag returnar så att jag kan byta ut den I listan med alla celler
    }
}
public class Grass : Cell
{
    //construct
    public Grass()
    {
        Walkable = true;
        Farmable = true;
        interactable = true;
        Texture = "Textures/Grass.png";
    }
}
public class farmLand : Cell
{
    public farmLand()
    {
      Walkable = true;
      Farmable = false;
      interactable = true;
      Texture = "Textures/farmLand.png";
    }

}
public class water : Cell
{

}
