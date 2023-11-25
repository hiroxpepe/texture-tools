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
        Color _accent = Color.none; // accent colors
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

        public static Palette NewPalette(string primary, string secondary, string accent, float alpha = 1f) {
            if (primary.Contains("none")) {
                throw new ArgumentException(message: "none cannot be a primary color.", paramName: nameof(NewPalette));
            }
            if (secondary.Contains("none")) {
                throw new ArgumentException(message: "none cannot be a secondary color.", paramName: nameof(NewPalette));
            }
            Color color1 = (Color) Enum.Parse(typeof(Color), primary);
            Color color2 = (Color) Enum.Parse(typeof(Color), secondary);
            if (accent.Contains("none")) {
                return new(primary: color1, secondary: color2, alpha: alpha) ;
            }
            else {
                Color color3 = (Color) Enum.Parse(typeof(Color), accent);
                return new(primary: color1, secondary: color2, accent: color3, alpha: alpha) ;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, adjectives]

        public Color Primary { get => _primary; }

        public Color Secondary { get => _secondary; }

        public Color Accent { get => _accent; }

        public float Alpha { get => _alpha; }
    }
}