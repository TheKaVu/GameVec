using System;
using System.Collections.Generic;

namespace WinXPP.GameVec.Simulated.AI
{
    public class Decorator : IBehaviorComponent, ICompositeNode
    {
        private readonly IBehaviorComponent _target;
        private readonly Predicate<TickArgs> _condition;
        private readonly Func<TickState, TickState> _processor;

        public ICollection<IBehaviorComponent> Children => new List<IBehaviorComponent>() { _target };

        public Decorator(IBehaviorComponent target, Predicate<TickArgs> condition) : this(target, condition, t => t) { }

        public Decorator(IBehaviorComponent target, Func<TickState, TickState> processor) : this(target, args => true, processor) { }

        public Decorator(IBehaviorComponent target, Predicate<TickArgs> condition, Func<TickState, TickState> processor)
        {
            _target = target ?? throw new ArgumentNullException("target");
            _condition = condition ?? throw new ArgumentNullException("condition");
            _processor = processor ?? throw new ArgumentNullException("processor");
        }

        public TickState Tick(TickArgs args)
        {
            if (_condition.Invoke(args))
            {
                return _processor.Invoke(_target.Tick(args));
            }
            return TickState.Failure;
        }
    }
}
