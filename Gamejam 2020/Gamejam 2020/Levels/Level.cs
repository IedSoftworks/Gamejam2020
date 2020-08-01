using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using SM;
using SM.Animations;
using SM.Core.Models;
using SM.Data.Models;
using SM.Data.Types.VectorTypes;
using SM.Scene;
using SM.Scene.Draw;

namespace Gamejam_2020
{
    public class Level
    {
        private static Dictionary<Model, Dictionary<Material, DrawCall>> drawCallDictionary = new Dictionary<Model, Dictionary<Material, DrawCall>>();
        public static SMItemCollection ShowObjectCollection;

        public static Preset? CurrentPreset;
        public static float Speed = 2;

        public static float SizeMultiplier = 0.75f;

        public static void Tick()
        {
            if (CurrentPreset.HasValue)
                foreach (GameObject obj in CurrentPreset.Value.Objects.ToArray())
                {
                    if (obj.CallParameter.Position.Z < Player.PlayerObject.Position.Z-4)
                    {
                        obj.DrawCall.DrawCallParameters.Remove(obj.CallParameter);
                        CurrentPreset.Value.Objects.Remove(obj);
                    }

                    if (CollisionTester.Test(Player.PlayerObject, obj))
                    {
                        obj.Collision();
                    }

                    obj.CallParameter.Position.Z -= Speed * (float)SMGlobals.UpdateDeltatime;
                }
        }

        public static void Create()
        {
            ShowObjectCollection = new SMItemCollection();
            Scene.Current.Add(ShowObjectCollection);
            Presets.GeneratePresets();

            GenerateNewPreset();
        }

        public static void GenerateNewPreset()
        {
            if (CurrentPreset.HasValue)
            {
                foreach (GameObject obj in CurrentPreset.Value.Objects)
                    obj.DrawCall.DrawCallParameters.Remove(obj.CallParameter);
            }

            CurrentPreset = Presets.AvailiblePresets[SMGlobals.Randomizer.Next(0, Presets.AvailiblePresets.Count)];

            foreach (GameObject obj in CurrentPreset.Value.Objects)
            {
                bool JustCreated = false;
                Dictionary<Material, DrawCall> drawCalls;
                if (!drawCallDictionary.ContainsKey(obj.Mesh))
                {
                    JustCreated = true;
                    drawCalls = new Dictionary<Material, DrawCall>();
                    drawCallDictionary.Add(obj.Mesh, drawCalls);
                }
                else drawCalls = drawCallDictionary[obj.Mesh];

                DrawCall call;
                if (JustCreated || !drawCalls.ContainsKey(obj.Material))
                {
                    call = new DrawCall()
                    {
                        Material = obj.Material,
                        Mesh = obj.Mesh
                    };
                    drawCalls.Add(obj.Material, call);
                    ShowObjectCollection.Add(call);
                }
                else call = drawCalls[obj.Material];

                obj.CallParameter = new CallParameter()
                {
                    Position = new Position(obj.RelativePosition.X * SizeMultiplier - 4 * SizeMultiplier, obj.RelativePosition.Y * SizeMultiplier - 4 * SizeMultiplier, obj.RelativePosition.Z * SizeMultiplier + 10),
                    Rotation = new Rotation(z: obj.Rotation * 90),
                    Size = new Size(SizeMultiplier)
                };
                call.DrawCallParameters.Add(obj.CallParameter);
                obj.DrawCall = call;
            }
        }
    }
}