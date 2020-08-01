using System;
using OpenTK;
using SM.Core.Enums;
using SM.Core.Plugin;
using SM.Core.Window;
using SM.Scene;
using SM.Scene.Cameras;

namespace Gamejam_2020
{
    public class GameWindow : WindowPlugin
    {
        public override WindowUsage NeededUsage { get; } = WindowUsage.All;
        public override void AfterUpdate(FrameEventArgs e, GLWindow window)
        {
            base.AfterUpdate(e, window);
            ((GameScene) GameScene.Current).player.Tick();
        }

        public override void Loading(EventArgs e, GLWindow window)
        {
            OrthographicCamera.WidthScale = 1000;

            Models.OpenModels();
            Scene.ChangeScene(new GameScene());
        }
    }
}