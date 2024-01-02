using System.Collections.Generic;

namespace WinXPP.GameVec.Render
{
    public class Vertice 
    {
        private readonly HashSet<Vertice> _targets = new HashSet<Vertice>();
        public Vec3 Pos {get;}
        public HashSet<Vertice> Targets => new HashSet<Vertice>(_targets);

        public Vertice(Vec3 pos, HashSet<Vertice> targets)
        {
            Pos = pos;
            _targets = new HashSet<Vertice>(targets);
        }
    }
}
