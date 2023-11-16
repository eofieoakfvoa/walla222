
using Raylib_cs;
/* 
här sätter jag alla inställningarna för hur spelet ska fungera, för keybinds använder jag integers baserat på vilken int 
som den keybinden relaterar till, t.ex är int 87 där (KeyboardKey)87 är likamed W,


*/
public class Settings
{
    public Dictionary<string, int> settingsDictionary = new();
    public int ScreenWidth = 1280;
    public int ScreenHeight = 720;
    
    public void Init()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(ScreenWidth, ScreenHeight, "game");
    }
    public void ChangeKeybind()
    {
        
    }
    public int walkUp = 87;
    public int walkLeft = 65;
    public int walkDown = 83;
    public int walkRight = 68;
 

}
