using System.Collections.Generic;
using OpenTK;

namespace Gamejam_2020
{
    public class Presets
    {
        public static List<Preset> AvailiblePresets = new List<Preset>();

        public static void GeneratePresets()
        {
            List<GameObject> tunnelList = new List<GameObject>();
            for (int x = 1; x <= Preset.MaxWidth; x++)
            {
                if (x > 1) continue;
                for (int y = 1; y <= Preset.MaxHeight; y++)
                {
                    if (y > 1) continue;
                    for (int z = 1; z < 10; z++)
                    {
                        tunnelList.Add(new Block() {RelativePosition = new Vector3(x,y,z)});
                    }
                }
            }

            AvailiblePresets.Add(new Preset(10, tunnelList));
        }
    }
}