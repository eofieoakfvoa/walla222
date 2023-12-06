using System.Numerics;
using Raylib_cs;

bool walking;

Player Character = new();

Vector2 previousMousePos = new(0, 0);
Cell selectedGrid = new();
int selectedGridIndex = 1;
bool gridIsSelected = false;


TextureManager textureManager = new();
Inventory InventoryManager = new();
Settings Settings = new();
Camera Camera = new(Settings);

int SelectedInventory = 1;

Renderer GameRenderer = new();

Seed See1d = new();

Settings.Init();
Map.Render();
Renderer render= new();
while (!Raylib.WindowShouldClose())
{
    Player.MouseCursorPosition();
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    Menu.Draw("Start");

    Raylib.EndDrawing();
}
