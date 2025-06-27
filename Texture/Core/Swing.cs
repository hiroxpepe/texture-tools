// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

namespace Texture.Core {
    /// <summary>
    /// Represents the swing class.
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public class Swing {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        int _min_value_x, _max_value_x, _min_value_y, _max_value_y;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Swing(int min_value_x, int max_value_x, int min_value_y, int max_value_y) {
            _min_value_x = min_value_x; _max_value_x = max_value_x;
            _min_value_y = min_value_y; _max_value_y = max_value_y;
        }

        public static Swing NewSwing(int min_value_x, int max_value_x, int min_value_y, int max_value_y) {
            return new(min_value_x, max_value_x, min_value_y, max_value_y);
        }

        public static Swing NewSwing(int min_value, int max_value) {
            return new(min_value_x: min_value, max_value_x: max_value, min_value_y: min_value, max_value_y: max_value);
        }

        public static Swing NewSwing(int value) {
            return new(min_value_x: value, max_value_x: value, min_value_y: value, max_value_y: value);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, noun phrase, adjective] 

        public int MinValueX { get => -_min_value_x; }

        public int MaxValueX { get => _max_value_x; }

        public int MinValueY { get => -_min_value_y; }

        public int MaxValueY { get => _max_value_y; }
    }
}