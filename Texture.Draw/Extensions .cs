// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System.Drawing;

using Texture.Core;

namespace Texture.Draw {
    /// <summary>
    /// generic extension method
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public static class Extensions {
        /// <summary>
        /// creates a Face object by the rectangle.
        /// </summary>
        public static Face NewFace(Rectangle rect, Cut cut, double crop = 1d) {
            return Face.NewFace(width: rect.Width, height: rect.Height, cut: cut, crop: crop);
        }
    }
}