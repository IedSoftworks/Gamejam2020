using System.Collections.Generic;
using System.Runtime.Remoting;
using SM;
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

        public static void Tick()
        {
            if (CurrentPreset.HasValue)
                foreach (GameObject obj in CurrentPreset.Value.Objects)
                    obj.CallParameter.Position.Z -= Speed * (float)SMGlobals.UpdateDeltatime;
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

                obj.CallParameter = new CallParameter() {Position = new Position(obj.RelativePosition.X, obj.RelativePosition.Y, obj.RelativePosition.Z)};
                call.DrawCallParameters.Add(obj.CallParameter);
                obj.DrawCall = call;
            }
        }
    }
}