using System.Collections.Generic;

namespace WinXPP.GameVec.Simulated.AI
{
    internal interface ICompositeNode
    {
        ICollection<IBehaviorComponent> Children { get; }
    }
}
