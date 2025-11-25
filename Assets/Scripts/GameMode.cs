public abstract class GameMode
{
    public abstract string DisplayName { get; }
    public abstract string SceneName { get; }
}

// --- Modo Offline ---
public class OfflineMode : GameMode
{
    public override string DisplayName => "Simple Mode Offline";
    public override string SceneName => "LevelOffline";
}

// --- Modo Online Simple ---
public class OnlineSimpleMode : GameMode
{
    public override string DisplayName => "Multiplayer Simple Online";
    public override string SceneName => "Level1";
}

// --- Modo Online Hardcore ---
public class OnlineHardcoreMode : GameMode
{
    public override string DisplayName => "Multiplayer Hardcore Online";
    public override string SceneName => "Level2";
}
