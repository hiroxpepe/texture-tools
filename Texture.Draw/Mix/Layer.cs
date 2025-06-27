// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System.Drawing;

using Texture.Core;

namespace Texture.Mix {
    /// <summary>
    /// Provides the Layer class for mixing operations.
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public class Layer : ILayer {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        Bitmap? _bitmap;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        /// <summary>
        /// Initializes a Layer object with a bitmap.
        /// </summary>
        Layer(Bitmap? bitmap) {
            _bitmap = bitmap;
        }

        /// <summary>
        /// Creates a new Layer object with specified dimensions and cut.
        /// </summary>
        public static Layer NewLayer(int width, int height, Cut cut) {
            return null; // new(width, height, cut);
        }
    }
}