using System;
using SM.Core.Enums;
using SM.Core.Plugin;
using SM.Core.Window;
using SM.Scene;

namespace Gamejam_2020
{
    public class GameWindow : WindowPlugin
    {
        public override WindowUsage NeededUsage { get; } = WindowUsage.All;

        public override void Loading(EventArgs e, GLWindow window)
        {
            Models.OpenModels();
            Scene.ChangeScene(new GameScene());
        }
    }
}