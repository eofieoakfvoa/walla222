using System;
using System.Diagnostics;
using System.Numerics;
using Raylib_cs;

public class Map
{
    //Cellsize = xPx x yPx, Mapsize = antal cells, Mapsize * cellsize = pixel width pixel height
    public static List<Chunk> activeChunks = new();
    public static Dictionary<Vector2, Chunk> chunkDictionary = new();
    public static int MapSize = 100;
    public static int CellSize = 32;
    public static int chunkSize = 32;
    public static int renderDistance = 32;
    public static Vector2 playerChunk; 

    public static void Render()
    {
        playerChunk = new((int)Player.Position.x / chunkSize * chunkSize, (int)Player.Position.y / chunkSize * chunkSize);
        
        for (int x = (int)(playerChunk.X - renderDistance); x <= playerChunk.X + renderDistance; x += chunkSize)
        {
            for (int y = (int)(playerChunk.Y - renderDistance); y < playerChunk.Y + renderDistance; y += chunkSize)
            {
                Vector2 position = new(x, y);
                GetChunk(position);
            }
        }

    }
    public static void GetChunk(Vector2 Position)
    {
        if (!chunkDictionary.ContainsKey(Position))
        {
            GenerateChunk(Position);
        }
        else
        {
            Chunk chunk = chunkDictionary[Position];
            activeChunks.Add(chunk);
        }
    }
    private static void GenerateChunk(Vector2 Position)
    {
        Chunk addedChunkk = new()
        {
            chunkPosition = Position
        };
        getTiles(addedChunkk);

    }
    private static void getTiles(Chunk addToChunk)
    {
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 16; y++)
            {
                Cell newTile = new()
                {
                    Position = new Vector2((int)addToChunk.chunkPosition.X + x, addToChunk.chunkPosition.Y + y)
                    //Få texturen och egenskaper
                };
                addToChunk.cellsInChunk.Add(newTile);
            }            
        }
        Debug.WriteLine(addToChunk.cellsInChunk.Count);
    }

}
