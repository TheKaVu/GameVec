namespace WinXPP.GameVec.Simulated.AI
{
    public interface IIntelligent<T> where T : Entity, IIntelligent<T>
    {
        EntityBrain<T> Brain { get; }
    }
}
