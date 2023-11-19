// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System.Drawing;

using Texture.Core;

namespace Texture.Mix {

    public class Layer : ILayer {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        Bitmap? _bitmap;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Layer(Bitmap? bitmap) {
            _bitmap = bitmap;
        }

        public static Layer NewLayer(int width, int height, Cut cut) {
            return null; // new(width, height, cut);
        }
    }
}