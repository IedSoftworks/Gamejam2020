using OpenTK;
using SM.Data.Models;
using SM.Data.Types.VectorTypes;
using SM.Scene;
using SM.Scene.Cameras;
using SM.Scene.Draw;
using SM.Scene.Lights;

namespace Gamejam_2020
{
    public class GameScene : Scene
    {
        DrawObject ship = new DrawObject()
        {
            Mesh = Models.Spaceship,
            Material = new Material(){DiffuseColor = new Color(1,0,0)}
        };
        DrawObject pyramid = new DrawObject()
        {
            Mesh = Models.Pyramid,
            Position = new Position(0, z:5)
        };
        DrawObject cube = new DrawObject()
        {
            Mesh = Models.Cube,
            Position = new Position(0, z: 10)
        };
        DrawObject tri = new DrawObject()
        {
            Mesh = Models.Triangle,
            Position = new Position(0, z: 15)
        };

        public GameScene()
        {
            Lights.Ambient = new Color(.1f,.1f,.1f);
            Lights.Add(new Sun(new Vector3(0,-1,-5)));

            Background = new Background();
        }
    }
}