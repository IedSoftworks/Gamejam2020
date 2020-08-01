using OpenTK;
using SM.Data.Models;
using SM.Data.Types.VectorTypes;
using SM.Scene.Draw;

namespace Gamejam_2020
{
    public class GameObject
    {
        public Matrix4 GlobalMatrix => DrawCall.ModelMatrix * CallParameter.ModelMatrix;

        public Vector3 RelativePosition;

        public DrawCall DrawCall;
        public CallParameter CallParameter;
        public virtual Mesh Mesh { get; set; }
        public virtual Material Material { get; set; }

        public virtual void Collision()
        {

        }
    }
}