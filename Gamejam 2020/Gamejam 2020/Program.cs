using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM;
using SM.Core.Enums;
using SM.Core.Window;

namespace Gamejam_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            GLWindow window = new GLWindow(new WindowSettings(.9f, "Gamejam 2020 - Testing Build"), new GLInformation());
            window.Use(WindowUsage.All, new DefaultWindow(), new GameWindow());
            window.Run();
        }
    }
}
