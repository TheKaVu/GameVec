using System;
using System.Collections.Generic;

namespace WinXPP.GameVec.Simulated.AI
{
    public class Sequencer : IBehaviorComponent, ICompositeNode
    {
        private readonly List<IBehaviorComponent> _children;
        private readonly int _tolerance;
        private int _index = 0;
        private int _fails = 0;

        public ICollection<IBehaviorComponent> Children => new List<IBehaviorComponent>(_children);

        public Sequencer(IBehaviorComponent[] children, int tolerance)
        {
            if (children == null) throw new ArgumentNullException("children");
            if (children.Length == 0) throw new ArgumentException("List is empty.", "children");
            _children = new List<IBehaviorComponent>(children);
            _tolerance = tolerance;
        }

        public TickState Tick(TickArgs args)
        {
            TickState state = _children[_index].Tick(args);

            if (state == TickState.Failure) _fails++;
            state = _fails <= _tolerance ? TickState.Success : state;

            if (state == TickState.Success)
            {
                _index++;
                state = (_index == _children.Count) ? TickState.Success : TickState.Running;
            }
            if (state == TickState.Failure || _index == _children.Count)
            {
                _fails = 0;
                _index = 0;
            }
            return state;
        }
    }
}
