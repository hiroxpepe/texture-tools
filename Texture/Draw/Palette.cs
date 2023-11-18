// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;

namespace Texture.Draw {
    /// <summary>
    /// palette class
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public class Palette {

        Color _primary = Color.White; // primary colors
        Color _secondary = Color.White; // secondary colors
        Color _tertiary = Color.White; // tertiary colors
        Color _quaternary = Color.White; // quaternary colors
        Color _accent = Color.White; // accent colors
        float _alpha = 1f; // alpha channel value;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Palette(Color primary, Color secondary, float alpha = 1f) {
            _primary = primary; _secondary = secondary; _alpha = alpha;
        }

        Palette(Color primary, Color secondary, Color accent, float alpha = 1f) {
            _primary = primary; _secondary = secondary; _accent = accent; _alpha = alpha;
        }

        public static Palette NewPalette(Color primary, Color secondary, float alpha = 1f) {
            return new(primary: primary, secondary: secondary, alpha: alpha) ;
        }

        public static Palette NewPalette(Color primary, Color secondary, Color accent, float alpha = 1f) {
            return new(primary: primary, secondary: secondary, accent: accent, alpha: alpha) ;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, adjectives]

        public Color Primary { get => _primary; }

        public Color Secondary { get => _secondary; }

        public Color Accent { get => _accent; }

        public float Alpha { get => _alpha; }
    }
}