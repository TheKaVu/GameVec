using System;
using System.Collections.Generic;
namespace WinXPP.GameVec.Simulated.AI
{
    public class Selector : IBehaviorComponent, ICompositeNode
    {
        private readonly List<IBehaviorComponent> _children;

        public ICollection<IBehaviorComponent> Children => new List<IBehaviorComponent>(_children);

        public Selector(IBehaviorComponent[] children)
        {
            if (children == null) throw new ArgumentNullException("children");
            if (children.Length == 0) throw new ArgumentException("List was empty.", "children");
            _children = new List<IBehaviorComponent>(children);
        }

        public TickState Tick(TickArgs args)
        {
            int i = 0;
            TickState state;
            do
            {
                state = _children[i].Tick(args);
            } while (++i < _children.Count && state == TickState.Failure);

            return state;
        }
    }
}
