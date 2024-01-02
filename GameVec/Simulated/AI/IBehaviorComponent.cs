namespace WinXPP.GameVec.Simulated.AI
{
    public interface IBehaviorComponent
    {
        TickState Tick(TickArgs args);
    }
}
