using System.Collections.Generic; 

namespace WinXPP.GameVec.Render
{
    public interface IModel
    {
        Vec3 Center { get;}
        Vec3 Rotation { get; set; }
        HashSet<IModel> SubModels { get;}
        HashSet<Vertice> Vertices { get;}
    }
}