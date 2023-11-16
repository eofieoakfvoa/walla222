using System.Numerics;
using Raylib_cs;
/*
Förlåt för sent inlämmnad trodde idag (Fredag) var sista dagen att arbeta,
Program.cs filen är där jag gör så att funktioner används när de ska användas, jag skulle dock kunna dra ner längden på koden
*/
bool walking;

Player Character = new Player();

Vector2 previousMousePos = new Vector2(0, 0);
Cell selectedGrid = new Cell();
int selectedGridIndex = 1;
bool gridIsSelected = false;


TextureManager textureManager = new();
Inventory InventoryManager = new();
Settings Settings = new();
Camera Camera = new(Settings);

int SelectedInventory = 1;


string Scene = "Start";

Seed See1d = new Seed();

Settings.Init();
Map.Render();
while (Raylib.WindowShouldClose() == false)
{
    Player.MouseCursorPosition();
    if (Scene == "Game")
    {
        if (Raylib.IsKeyDown((KeyboardKey)Settings.walkUp))
        {
            Player.Movement("Verticle", -4);
        }
        if (Raylib.IsKeyDown((KeyboardKey)Settings.walkDown))
        {
            Player.Movement("Verticle", 4);
        }
        if (Raylib.IsKeyDown((KeyboardKey)Settings.walkLeft))
        {
            Player.Movement("Horizontal", -4);
        }
        if (Raylib.IsKeyDown((KeyboardKey)Settings.walkRight))
        {
            Player.Movement("Horizontal", 4);
        }
        for (var i = 49; i <= 57; i++)
        {
            if (Raylib.IsKeyPressed((KeyboardKey)i))
            {
                int valueToNumber = i - 49; // minus 49 istället för 48 eftersom att invetoryit börjar på 0
                SelectedInventory = valueToNumber;
            }
        }



        if (Raylib.IsKeyReleased(KeyboardKey.KEY_C))
        {
            InventoryManager.addToInvetory("Hoe", new Hoe(), 1);
            InventoryManager.addToInvetory("Seed", See1d, 3);
            InventoryManager.addToInvetory("Shovel", new Shovel(), 1);
        }

    }

    //Walking är ett dåligt variable namn, det är till för att se ifall personen interagerar med spelet, som sparar på resurser
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_D) || Vector2.Distance(Player.MousePosition, previousMousePos) > 0 || Raylib.IsKeyReleased(KeyboardKey.KEY_E))
    {
        walking = true;
    }
    else
    {
        walking = false;
    }
    if (Scene == "Start")
    {
        Scene = StartMenu.buttonClick(Character);
        Menu.Draw(Scene);
    }
    if (Scene == "Controls")
    {
        Menu.Draw(Scene);
    }
    previousMousePos = Player.MousePosition;

    Camera.cameraup(Character, Settings);
    
    float screenLeft = Player.Position.x - Settings.ScreenWidth / 2;
    float screenTop = Player.Position.y + Settings.ScreenHeight / 2;


    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    Vector2 worldMousePos = Raylib.GetScreenToWorld2D(Player.MousePosition, Camera.camera);




    if (Scene == "Game")
    {
        Raylib.BeginMode2D(Camera.camera);
        if (gridIsSelected == true && Raylib.IsKeyReleased(KeyboardKey.KEY_E))
        {
                if (InventoryManager.InventorySlots[SelectedInventory] == "Empty")
                {
                }
                else
                {
                    items ItemInHold = InventoryManager.itemsInInventory[InventoryManager.InventorySlots[SelectedInventory]];
                    Cell Newtile = new Cell();

                    if (SelectedInventory == 0)
                    {
                        //I det här fallet är farmLand = T i Cell.cs
                        //just nu behöver jag hardcodea vilka tiles jag vill ändra till
                        Newtile = selectedGrid.changeTile<farmLand>(selectedGrid);
                    }
                    if (SelectedInventory == 1)
                    {
                        Newtile = selectedGrid.changeTile<Grass>(selectedGrid);
                    }
                    if (SelectedInventory == 2)
                    {
                        Newtile = selectedGrid.changeTile<Grass>(selectedGrid);
                    }
                    Map.gridcells[selectedGridIndex] = Newtile;
                    //här byter jag ut cellen mot den nya
                }

        }
        int index = 0;

        // Rita ut Celler

        foreach (var item in Map.gridcells)
        {
            //Item är varje cell
            Color color = Color.WHITE;

            if (walking == true)
            {
                if (item.Position.x < worldMousePos.X && item.Position.x > worldMousePos.X - 32 && item.Position.y < worldMousePos.Y && item.Position.y > worldMousePos.Y - 32)
                {
                    //den här delen av kod används för att selecta en cell
                    selectedGrid = item;
                    selectedGridIndex = index;
                    gridIsSelected = true;
                }
            }

            //Från test har jag märkt att DrawTexturePro tar mycket av datorn, därför har jag gjort så att bara det som skärmen kan se är vad som renderas
            if (item.Position.x < screenLeft + Settings.ScreenWidth && item.Position.x > screenLeft && item.Position.y < screenTop && item.Position.y > screenTop - Settings.ScreenHeight)
            {
                Raylib.DrawTexturePro(textureManager.LoadTexture(item.Texture), new Rectangle(0, 0, Map.CellSize, Map.CellSize), item.Position, new Vector2(0, 0), 0, color);
            }
            index++;
        }
        Raylib.DrawTexturePro(textureManager.LoadTexture(selectedGrid.Texture), new Rectangle(0, 0, Map.CellSize, Map.CellSize), selectedGrid.Position, new Vector2(0, 0), 0, Color.ORANGE);
        Raylib.DrawTexturePro(Player.Sprite, new Rectangle(0, 0, 80, 80), Player.Position, new Vector2(40, 40), 0, Color.WHITE);
        Raylib.DrawFPS(150, -50);


        // Inventory drawing
        int itemIndex = 0;
        foreach (var item in InventoryManager.InventorySlots)
        {
            //Raylib.DrawTexture(textureManager.LoadTexture(itemData.Texture), 0,0, Color.WHITE);
            if (item.Value == "Empty")
            {
                Raylib.DrawRectangle((int)Player.Position.x - 400 + 86 * itemIndex, (int)screenTop - 128, 64, 64, Color.BEIGE);

            }
            else
            {
                items itemData = InventoryManager.itemsInInventory[item.Value];
                Raylib.DrawTexturePro(textureManager.LoadTexture(itemData.Texture), new Rectangle(0, 0, 64, 64), new Rectangle((int)Player.Position.x - 400 + 86 * itemIndex, (int)screenTop - 128, 64, 64), new Vector2(0, 0), 0, itemData.color);
            }
            itemIndex++;
            if (itemIndex == InventoryManager.InventorySlots.Count())
            {
                itemIndex = 0;
            }
        }


    }



    Raylib.EndDrawing();
}
