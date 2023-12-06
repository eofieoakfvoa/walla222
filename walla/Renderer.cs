using Raylib_cs;

class Renderer
{
    private List<Action> drawQueue = new();
    private string? _currentScene;
    public string SetCurrentScene
    {
        get {return _currentScene;}
        set
        {
            _currentScene = value;
            _currentScene ??= "Start";
            HardClear();
        }
    }
    public string GetCurrentScene()
    {
        return _currentScene;
    }
    private void HardClear()
    {
        foreach (Action drawRequest in drawQueue)
        {
            drawQueue.Remove(drawRequest);   
        }
    }
    public void AddToQueue(Action Add)
    {
        drawQueue.Add(Add);
    }
    public void RemoveFromQueue(Action remove)
    {
        drawQueue.Remove(remove);
    }
    public void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        foreach (var item in drawQueue)
        {
            item.Invoke();
        }
        Raylib.EndDrawing();
    }

}