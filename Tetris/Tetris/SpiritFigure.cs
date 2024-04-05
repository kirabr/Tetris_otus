﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class SpiritFigure : Figure
    {
        public SpiritFigure()
        {
        }

        public SpiritFigure(Figure figure) : base(figure) {}

        public SpiritFigure(int a, int b, char c) : base(a, b, c)
        {
            Sym = ' ';
        }

        public SpiritFigure(int a, int b, char c, byte rotation) : base(a, b, c, rotation)
        {
            Sym = ' ';
        }

        public override void SetPoints()
        {
            throw new NotImplementedException();
        }
    }
}
