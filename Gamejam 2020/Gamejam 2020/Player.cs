using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;
using SM;
using SM.Data.Types.VectorTypes;
using SM.Keybinds;
using SM.Scene;
using SM.Scene.Draw;

namespace Gamejam_2020
{
    public class Player : DrawObject
    {
        public Player()
        {
            Mesh = Models.Spaceship;
            Rotation = new Rotation(0, 180, 0);
            Position = new Position(0, 0, 7);
            float globalSpeed = 3f;

            KeybindCollection.AutoCheckKeybindCollections.Add(new KeybindCollection{new Keybind((k) =>
            {
                float speed = globalSpeed * (float)SMGlobals.UpdateDeltatime;
                Position.X -= speed;
                Scene.Current.Camera.Position.X -= speed;
            }, Key.D),
                new Keybind((k) =>
            {
                float speed = globalSpeed * (float)SMGlobals.UpdateDeltatime;
                Position.X += speed;
                Scene.Current.Camera.Position.X += speed;
            }, Key.A)});
        }
    }
}
