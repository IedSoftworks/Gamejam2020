using SM.Data.Models;

namespace Gamejam_2020
{
    public class Block : GameObject
    {
        public override Mesh Mesh { get; set; } = Models.Cube;
        public override Material Material { get; set; } = Spike.defaultMaterial;
    }
}