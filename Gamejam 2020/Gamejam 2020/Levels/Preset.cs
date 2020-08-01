using System;
using System.Collections.Generic;

namespace Gamejam_2020
{
    public struct Preset
    {
        public const int MaxHeight = 8;
        public const int MaxWidth = 8;
        public int Depth;
        public ICollection<GameObject> Objects;

        public Preset(int depth, ICollection<GameObject> objects)
        {
            Depth = depth;
            Objects = objects;
        }
    }
}