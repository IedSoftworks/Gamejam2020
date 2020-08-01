using OpenTK;
using OpenTK.Input;
using SM.Data.Models;
using SM.Data.Types.VectorTypes;
using SM.Keybinds;
using SM.Scene;
using SM.Scene.Cameras;
using SM.Scene.Draw;
using SM.Scene.Lights;

namespace Gamejam_2020
{
    public class GameScene : Scene
    {
        public Player player;
        public GameScene()
        {
            KeybindCollection.AutoCheckKeybindCollections.Add(new KeybindCollection()
            {
                new Keybind(a => Lights.Ambient = new Color(1,1,1), Key.F11)
            });

            AxisHelper = false;

            Lights.Ambient = new Color(.1f,.1f,.1f);
            Lights.Add(new Sun(new Vector3(0,-1,5)));
            //Lights.Add(new Sun(new Vector3(0,1,5)));

            Add(new Background(this));

            player = new Player();
            Add(player);

            Camera.Position = new Position(0, 3, 0);
            ((PerspectiveCamera) Camera).Target = player.Position;
        }
    }
}