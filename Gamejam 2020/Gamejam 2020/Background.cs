using System;
using Assimp;
using OpenTK.Graphics.OpenGL4;
using SM;
using SM.Animations;
using SM.Core;
using SM.Core.Window;
using SM.Data.Models;
using SM.Data.Types.VectorTypes;
using SM.Scene.Cameras;
using SM.Scene.Draw;
using Animation = SM.Animations.Animation;

namespace Gamejam_2020
{
    public class Background : SMItemCollection
    {
        private const float Width = 5f;
        private const float Height = 5f;

        private DrawCall call;

        public Background(Scene scene)
        {
            Camera = new PerspectiveCamera();
            DepthFunc = DepthFunction.Less;

            call = new DrawCall
            {
                Material = {DiffuseColor = new Color(1,1,1)},
                Mesh = Models.Cube
            };
            Add(call);

            Timer timer = new Timer(1/5f, true)
            {
                Repeat = true
            };
            timer.End += TimerSys;
            timer.Start();
        }

        private void TimerSys(Timer timer)
        {
            Position pos = new Position
            {
                X = (float) (SMGlobals.Randomizer.NextDouble() * (Width * 2) - Width),
                Y = (float) (SMGlobals.Randomizer.NextDouble() * (Height * 2) - Height),
                Z = 5f
            };

            CallParameter parameter = new CallParameter()
            {
                Position = pos,
                Size = new Size((float)SMGlobals.Randomizer.NextDouble() * .1f)
            };
            call.DrawCallParameters.Add(parameter);
            Animation animation = new Animation(pos, new AnimationStruct(TimeSpan.FromSeconds(5), false,  pos, new AnimationVector(pos.X, pos.Y, -1)), false);
            animation.End += a => call.DrawCallParameters.Remove(parameter);
            animation.Start();
        }
    }
}