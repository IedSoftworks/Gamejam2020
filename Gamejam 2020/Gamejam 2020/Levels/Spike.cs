using SM.Data.Models;
using SM.Data.Types.VectorTypes;

namespace Gamejam_2020
{
    public class Spike : GameObject
    {
        private static Material defaultMaterial = new Material()
        {
            DiffuseColor = new Color(0, 0, 0),
            Shininess = 64
        };

        public override Mesh Mesh { get; set; } = Models.Pyramid;
        public override Material Material { get; set; } = defaultMaterial;

        public override void Collision()
        {

        }
    }
}