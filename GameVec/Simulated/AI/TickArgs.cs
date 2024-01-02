using System;

namespace WinXPP.GameVec.Simulated.AI
{
    public class TickArgs
    {
        public Entity TickedEntity { get; internal set; } = null;
        public DateTime TickTime { get; } = DateTime.Now;
    }
}
