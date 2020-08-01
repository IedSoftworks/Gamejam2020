using System.Linq;
using OpenTK;
using SM.Scene.Draw;

namespace Gamejam_2020
{
    public static class CollisionTester
    {
        public static bool Test(DrawObject a, DrawObject b)
        {
            var aMin = a.Mesh.OBB_Min + a.Position;
            var aMax = a.Mesh.OBB_Max + a.Position;
            var bMin = b.Mesh.OBB_Min + a.Position;
            var bMax = b.Mesh.OBB_Max + a.Position;
            var boundsA = MakeBoundPoints(new[] {a.Mesh.OBB_Min, a.Mesh.OBB_Max});
            var boundsB = MakeBoundPoints(new[] {b.Mesh.OBB_Min, b.Mesh.OBB_Max});
            return boundsA.Any(p => IsInBounds(p, bMin, bMax)) || boundsB.Any(p => IsInBounds(p, aMin, aMax));
        }

        public static bool IsInBounds(Vector3 needle, Vector3 hayMin, Vector3 hayMax)
        {
            return needle.X > hayMin.X && needle.Y > hayMin.Y && needle.Z > hayMin.Z && needle.X < hayMax.X &&
                   needle.Y < hayMax.Y && needle.Z < hayMax.Z;
        }
        public static Vector3[] MakeBoundPoints(Vector3[] array)
        {
            var x = array[1];
            var i = array[0];
            var array2 = new Vector3[8];
            array2[0] = new Vector3(i.X, i.Y, i.Z);
            array2[1] = new Vector3(x.X, i.Y, i.Z);
            array2[2] = new Vector3(i.X, x.Y, i.Z);
            array2[3] = new Vector3(i.X, i.Y, x.Z);
            array2[4] = new Vector3(x.X, i.Y, x.Z);
            array2[5] = new Vector3(x.X, x.Y, i.Z);
            array2[6] = new Vector3(i.X, x.Y, x.Z);
            array2[7] = new Vector3(x.X, x.Y, x.Z);
            return array2;
        }
    }
}