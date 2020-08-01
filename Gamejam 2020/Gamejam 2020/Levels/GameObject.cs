using OpenTK;
using SM.Data.Models;
using SM.Data.Types.VectorTypes;
using SM.Scene.Draw;

namespace Gamejam_2020
{
    public class GameObject
    {
        public Vector3 RelativePosition;
        public int Rotation = 0;

        public DrawCall DrawCall;
        public CallParameter CallParameter;
        public virtual Mesh Mesh { get; set; }
        public virtual Material Material { get; set; }

        public virtual void Collision()
        {

        }
    }
}