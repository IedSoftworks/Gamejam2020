using Assimp;
using SM.Data.Models.Import;
using Mesh = SM.Data.Models.Mesh;
using PrimitiveType = OpenTK.Graphics.OpenGL4.PrimitiveType;

namespace Gamejam_2020
{
    public class Models
    {
        public static ImportedMesh Spaceship;
        public static ImportedMesh Pyramid;
        public static ImportedMesh Cube;
        public static Mesh Triangle;

        public static void OpenModels()
        {
            ImportedMesh[] importedMeshes = Importer.ImportMeshes("Models.obj", true, ModelImportOptions.None,
                PostProcessSteps.CalculateTangentSpace);

            foreach (ImportedMesh mesh in importedMeshes)
            {
                switch (mesh.Name)
                {
                    case "3DView.006_Spaceship":
                        Spaceship = mesh;
                        break;
                    case "Cone.003_Pyramid":
                        Pyramid = mesh;
                        break;
                    case "Cube.001_Cube":
                        Cube = mesh;
                        break;
                }
            }

            Triangle = new Mesh()
            {
                Vertices =
                {
                    {-.5f, .5f},
                    {0, -.5f},
                    {.5f, .5f},
                },
                Normals =
                {
                    {0,0,1},
                    {0,0,1},
                    {0,0,1},
                },
                PrimitiveType = PrimitiveType.Triangles
            };
        }
    }
}