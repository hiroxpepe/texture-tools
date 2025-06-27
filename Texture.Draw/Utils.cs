// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System.Linq;
using System.Drawing;

using TexPoint = Texture.Core.Point;

namespace Texture {
    /// <summary>
    /// Provides utility methods for the application.
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public static class Utils {

        /// <summary>
        /// Maps an array of TexPoint objects to an array of PointF objects.
        /// </summary>
        public static PointF[] MapPoints(TexPoint[] points) {
            return points.Select(selector: x => new PointF(x: x.X, y: x.Y)).ToArray();
        }

        /// <summary>
        /// Maps a single TexPoint object to a PointF object.
        /// </summary>
        public static PointF MapPoint(TexPoint point) {
            return new(x: point.X, y: point.Y);
        }
    }
}