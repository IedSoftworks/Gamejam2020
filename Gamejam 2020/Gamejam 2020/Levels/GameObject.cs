using SM.Data.Models;
using SM.Data.Types.VectorTypes;

namespace Gamejam_2020
{
    public class GameObject
    {
        public Position RelativePosition;

        public virtual Mesh Mesh { get; set; }
        public virtual Material Material { get; set; }

        public virtual void Collision()
        {

        }
    }
}