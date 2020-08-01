using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using SM;
using SM.Core;
using SM.Data.Models;
using SM.Data.Types;
using SM.Data.Types.VectorTypes;
using SM.Keybinds;
using SM.Scene;
using SM.Scene.Draw;
using SM.Scene.Draw.Particles;

namespace Gamejam_2020
{
    public class Player : DrawObject
    {
        private static Rotation particleRotation = new Rotation(0, 0, 180);

        public static Player PlayerObject;

        public Direction Velocity = new Direction(0,0,0);
        public Position StartPoint = new Position(0, 0, 7);
        public Direction lastVelocity = new Direction(0,0,0);
        public Player()
        {
            PlayerObject = this;

            Mesh = Models.Spaceship;
            Rotation = new Rotation(0, 180, 0);
            //Position = StartPoint;
            Position = new Position(StartPoint.X, StartPoint.Y, StartPoint.Z);
            float globalSpeed = 3f;

            KeybindCollection.AutoCheckKeybindCollections.Add(new KeybindCollection{new Keybind((k) =>
            {
                float speed = globalSpeed * (float)SMGlobals.UpdateDeltatime;
                Velocity.X -= speed;
            }, Key.D),
                new Keybind((k) =>
                {
                    float speed = globalSpeed * (float)SMGlobals.UpdateDeltatime;
                    Velocity.X += speed;
                }, Key.A),
                new Keybind((k) =>
                {
                    float speed = globalSpeed * (float)SMGlobals.UpdateDeltatime;
                    Velocity.Y += speed;
                }, Key.W),
                new Keybind((k) =>
                {
                    float speed = globalSpeed * (float)SMGlobals.UpdateDeltatime;
                    Velocity.Y -= speed;
                }, Key.S)});

            Timer particleTimer = new Timer(1/30f, true);
            particleTimer.End += timer =>
            {
                Color4[] colorlist = new[] { Color4.Orange, Color4.OrangeRed, Color4.Red };

                GameScene.Current.Add(new DrawParticles(new ConeParticles() { Amount = 1, RotateTowardsOrigin = true, Cone = new Vector2(.25f), MaxSize = .5f, MaxSpeed = 10f})
                {
                    Position = new Position(Position.X, Position.Y, StartPoint.Z - Models.Spaceship.OBB_Max.Z),
                    Rotation = particleRotation,
                    Time = TimeSpan.FromSeconds(1),
                    FadeInEndTime = 0.1f,
                    FadeOutStartTime = 0.1f,
                    Mesh = Models.Triangle,
                    Material = {DiffuseColor = colorlist[SMGlobals.Randomizer.Next(colorlist.Length)], AllowLight = false}
                });
            };
            particleTimer.Start();
        }

        public void Tick()
        {
            if (lastVelocity.Length == Velocity.Length)
            {
                var prevVec = VectorType.Clone(Velocity);

                var direction = VectorType.Clone(Position - StartPoint) * -1;
                direction.W = 0;
                if (direction.Length > 1)
                {
                    direction.Normalize();
                }

                direction.Mul(0.1f);

                Velocity.Add(direction);

                if (Velocity.Length > prevVec.Length && Velocity.Length > 1)
                {
                    Velocity.Normalize();
                    Velocity.Mul(Math.Max(prevVec.Length, 1));
                }
            }

            var vec = Velocity * (float) SMGlobals.UpdateDeltatime;
            Position.Add(vec);
            Position.W = 1;
            GameScene.Current.Camera.Position.Add(vec);

            lastVelocity = VectorType.Clone(Velocity);
        }

        public void Kill()
        {

        }
    }
}
