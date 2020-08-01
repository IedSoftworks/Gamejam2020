using System.Linq;
using OpenTK;
using SM.Scene.Draw;

namespace Gamejam_2020
{
    public static class CollisionTester
    {
        public static bool Test(GameObject ga, GameObject gb)
        {
            
            var aMin = ga.Mesh.OBB_Min + ga.CallParameter.Position;
            var aMax = ga.Mesh.OBB_Min + ga.CallParameter.Position;
            var bMin = gb.Mesh.OBB_Min + gb.CallParameter.Position;
            var bMax = gb.Mesh.OBB_Min + gb.CallParameter.Position;
            var boundsA = MakeBoundPoints(new[] {ga.Mesh.OBB_Min, ga.Mesh.OBB_Max});
            var boundsB = MakeBoundPoints(new[] {gb.Mesh.OBB_Min, gb.Mesh.OBB_Max});
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