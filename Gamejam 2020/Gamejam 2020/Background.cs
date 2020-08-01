using SM;
using SM.Core;
using SM.Core.Window;
using SM.Data.Types.VectorTypes;
using SM.Scene.Cameras;
using SM.Scene.Draw;

namespace Gamejam_2020
{
    public class Background : SMItemCollection
    {
        private const float Width = 5f;
        private const float Height = 5f;

        private DrawCall call;

        public Background()
        {
            call = new DrawCall();
            Add(call);

            Timer timer = new Timer(1/60f, true)
            {
                Repeat = true
            };
            timer.End += TimerSys;
            timer.Start();
        }

        private void TimerSys(Timer timer)
        {
            Position pos = new Position();
            pos.X = (float)(SMGlobals.Randomizer.NextDouble() * (Width * 2) - Width);
            pos.Y = (float)(SMGlobals.Randomizer.NextDouble() * (Height * 2) - Height);
        }
    }
}