using Raylib_cs;

class Renderer
{
    private List<Action> drawQueue = new();
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