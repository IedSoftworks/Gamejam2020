using SM.Data.Models;
using SM.Data.Types.VectorTypes;
using SM.Scene;
using SM.Scene.Cameras;
using SM.Scene.Draw;

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
            Lights.Ambient = new Color(1,1,1);

            AddRange(ship, pyramid, cube, tri);
            ((PerspectiveCamera)Camera).Position = new Position(5, 2, 7.5f);
            ((PerspectiveCamera)Camera).Target = new Position(0, z: 7.5f);
        }
    }
}