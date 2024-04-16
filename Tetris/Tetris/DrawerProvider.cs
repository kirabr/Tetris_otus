using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class DrawerProvider
    {
        private static IDrawer _drawer = new Drawer();
        public static IDrawer Drawer { get { return _drawer; } }

    }
}
