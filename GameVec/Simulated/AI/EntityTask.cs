namespace WinXPP.GameVec.Simulated.AI
{
    public abstract class EntityTask : IBehaviorComponent
    {
        public abstract TickState Tick(TickArgs args);
    }
}
