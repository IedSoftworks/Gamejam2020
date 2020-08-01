using SM.Data.Models;
using SM.Data.Types.VectorTypes;

namespace Gamejam_2020
{
    public class Spike : GameObject
    {
        public static Material defaultMaterial = new Material()
        {
            DiffuseColor = new Color(.1f, .1f, .1f),
            Shininess = 64
        };

        public override Mesh Mesh { get; set; } = Models.Pyramid;
        public override Material Material { get; set; } = defaultMaterial;

        public override void Collision()
        {
            ((GameScene)GameScene.Current).player.Kill();
        }
    }
}