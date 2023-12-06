using Raylib_cs;

class Renderer
{
    public enum Scenes
    {
        Game,
        StartMenu,
        Controls,
    }
    private static Scenes? _currentScene = Scenes.StartMenu;
    public static Scenes SetCurrentScene
    {
        get {return (Scenes)_currentScene;}
        set
        {
            _currentScene = value;
            _currentScene ??= Scenes.StartMenu;
            //Clear här ifall jag orkar fixa ett bättre render system
        }
    }
    public static Scenes GetCurrentScene()
    {
        return (Scenes)_currentScene;
    }

    //--Under Fungerar Inte Än--//
    private void HardClear()
    {
    }
    public void AddToQueue()
    {
    }
    public void RemoveFromQueue()
    {
    }
    public void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);


        
        Raylib.EndDrawing();
    }

}