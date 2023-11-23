// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using Texture.Core;
using Texture.Draw;

namespace Texture.Win64 {
    /// <summary>
    /// parameter object for app.
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public class Param {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        Cut _cut;

        Face _face;

        Palette _palette;

        Swing _swing;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        /// <summary>
        /// creates as a "note" notated parameter.
        /// </summary>
        public Param(Cut cut, Face face, Palette palette, Swing swing) {
            _cut = cut; _face = face; _palette = palette; _swing = swing;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, adjective] 

        public Cut Cut { get => _cut; }

        public Face Face { get => _face; }

        public Palette Palette { get => _palette; }

        public Swing Swing { get => _swing; }
    }
}