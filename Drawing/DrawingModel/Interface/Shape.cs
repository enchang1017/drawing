﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Interface
{
    public interface Shape
    {
        //畫線
        void Draw(IGraphics graphics);
    }
}
