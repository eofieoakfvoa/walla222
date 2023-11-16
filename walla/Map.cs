using System;
using Raylib_cs;

public class Map
{
    //Cellsize = xPx x yPx, Mapsize = antal cells, Mapsize * cellsize = pixel width pixel height
    public static List<Cell> gridcells = new();
    public static int MapSize = 100;
    public static int CellSize = 32;
    
    public static void Render()
    {
        /*
        den gör 2 styckna for loopar för x och y, den börjar med x=0, sen utifrån det så gör den antal int i Mapsize 
        till Y sen när den har gjort det så byter den till nästa x
        */
        for (var x = 0; x < MapSize; x++)
        {
            for (var y = 0; y < MapSize; y++)
            {
            Cell cellAdd = tiles(x,y);
            gridcells.Add(cellAdd);
            cellAdd.Position = new Rectangle(x*CellSize, y*CellSize, CellSize, CellSize);
            }
        }
    } 
    /*
    tänkte att det skulle va bra att försöka göra så att mapen är customizable, sen märkte jag att det nog inte är 
    det viktigaste för mig just nu. så allt det här gör är att byter ut alla celler till gräs
    */
    public static Cell tiles(int x, int y)
    {
        if (x >= 0 || y >= 0)
        {
            return new Grass();
        }
        return new Cell();
    }
}
