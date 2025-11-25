public static class GameModeSelection
{
    public static GameMode CurrentMode { get; private set; }

    public static void Select(GameMode mode)
    {
        CurrentMode = mode;
    }
}
