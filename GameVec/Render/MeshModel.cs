using System.Collections.Generic;
using System.Windows.Media;

namespace WinXPP.GameVec.Render
{
    public class MeshModel : IModel
    {
        private readonly HashSet<IModel> _subModels;
        private readonly HashSet<Vertice> _vertices;

        public Color Color { get;}
        public int Thickness { get; }
        public Vec3 Center { get; }
        public Vec3 Rotation { get; set; }
        public string Id { get;}
        public HashSet<IModel> SubModels => new HashSet<IModel>(_subModels);
        public HashSet<Vertice> Vertices => new HashSet<Vertice>(_vertices);

        public MeshModel(HashSet<IModel> subModels, HashSet<Vertice> vertices, Color color, int thickness, Vec3 center, Vec3 rotation, string id)
        {
            _subModels = new HashSet<IModel>(subModels);
            _vertices = new HashSet<Vertice>(vertices);
            Color = color;
            Thickness = thickness;
            Center = center;
            Rotation = rotation;
            Id = id;
        }
    }
}
