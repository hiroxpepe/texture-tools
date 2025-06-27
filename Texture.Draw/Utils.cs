﻿// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System.Linq;
using System.Drawing;

using TexPoint = Texture.Core.Point;

namespace Texture {
    /// <summary>
    /// Represents the utils class.
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public static class Utils {

        public static PointF[] MapPoints(TexPoint[] points) {
            return points.Select(selector: x => new PointF(x: x.X, y: x.Y)).ToArray();
        }

        public static PointF MapPoint(TexPoint point) {
            return new(x: point.X, y: point.Y);
        }
    }
}