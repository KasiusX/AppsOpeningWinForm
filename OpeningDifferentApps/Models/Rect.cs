﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeningDifferentApps.Models
{
    public struct Rect
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }      

        public int Height
        {
            get { return Bottom - Top; }            
        }

        public int Width
        {
            get { return Right - Left; }
        }

    }
}
