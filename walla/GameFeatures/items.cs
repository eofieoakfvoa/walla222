using System;
using Raylib_cs;

public class items
{
    public bool Stackable;
    public bool Placable;
    public int Stacks;
    public string Name;
    public string Description;
    public string Texture;
    public Color color;
}
public class  Hoe : items
{
    //construct
    public Hoe()
    {
        Stackable = false;
        Placable = false;
        Name = "Hoe";
        Description = "Used to farm land";
        Texture = "Textures/Hoe.png";
        color = Color.WHITE;

    }
}
public class Seed : items
{
    public Seed()
    {
        Stackable = true;
        Placable = true;
        Name = "Seed";
        Description = "Seed";
        Texture = "Textures/Seed.png";
        color = Color.WHITE;
        
    }
}
public class Shovel : items
{
    public Shovel()
    {
        Stackable = false;
        Placable = true;
        Name = "Shovel";
        Description = "Shovel";
        Texture = "Textures/Shovel.png";
        color = Color.WHITE;
        
    }
}
public class GrassBlock : items
{
    public GrassBlock()
    {
        Stackable = true;
        Placable = true;
        Name = "GrassBlock";
        Description = "yes";
        Texture = "Textures/Grass.png";
    }
}
