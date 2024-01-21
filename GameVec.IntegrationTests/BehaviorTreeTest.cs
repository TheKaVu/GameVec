using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinXPP.GameVec.Simulated;
using WinXPP.GameVec.Simulated.AI;

namespace WinXPP.GameVec.IntegrationTests
{
    public class EntityTypes
    {
        public static readonly EntityType<MyIntelligent> MyIntelligent = EntityType.Register<MyIntelligent>("my_intelligent");
    }

    public class MyIntelligent : Entity, IIntelligent<MyIntelligent>
    {

        public EntityBrain<MyIntelligent> Brain => throw new System.NotImplementedException();

        public MyIntelligent() : base(EntityTypes.MyIntelligent, EntityAttributes.Empty, null) { }

        public override bool IsOnGround() => false;

        public override void Move(Vec3 force) { }

        public override void Rotate(Vec3 force) { }
    }

    [TestClass]
    public class BehaviorTreeTest
    {
        public static int Test = 0;

        [TestMethod]
        public void ShouldFollowBehaviorTree()
        {
            var a1 = new MyAction(1);
            var a2 = new MyAction(2);
            var a3 = new MyAction(3);
            var a4 = new MyAction(4);

            var d1 = new Decorator(a1, args => Test <= 1);
            var d3 = new Decorator(a3, args => Test == 4);

            Sequencer seq = new Sequencer(new IBehaviorComponent[]{ d1, a2 }, 0);
            Selector sel = new Selector(new IBehaviorComponent[] { d3, a4 });

            Selector root = new Selector(new IBehaviorComponent[] {seq, sel });

            var entity = new MyIntelligent();
            var brain = new EntityBrain<MyIntelligent>(entity, root);

            brain.Tick();
            Assert.AreEqual(1, Test);
            brain.Tick();
            Assert.AreEqual(2, Test);
            brain.Tick();
            Assert.AreEqual(4, Test);
            brain.Tick();
            Assert.AreEqual(3, Test);
        }

        public class MyAction : EntityTask
        {
            private readonly int _value;

            public MyAction(int value)
            {
                _value = value;
            }

            public override TickState Tick(TickArgs args)
            {
                Test = _value;
                return TickState.Success;
            }
        }
    }
}
