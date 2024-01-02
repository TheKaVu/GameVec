using System;

namespace WinXPP.GameVec.Simulated.AI
{
    public class EntityBrain<T> where T : Entity, IIntelligent<T>
    {
        private readonly IBehaviorComponent _root;

        public bool Frozen { get; set; }
        public T Holder { get; }

        public EntityBrain(T holder, IBehaviorComponent root)
        {
            Holder = holder ?? throw new ArgumentNullException("holder");
            _root = root ?? throw new ArgumentNullException("root");
        }

        public void Tick()
        {
            Tick(new TickArgs() { TickedEntity = Holder });
        }

        public void Tick(TickArgs args)
        {
            if (Frozen) return ;
            if(args != null) args.TickedEntity = Holder;
            _root.Tick(args);
        }
    }
}
