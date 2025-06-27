// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

namespace Texture.Draw {
    /// <summary>
    /// Represents the switch class.
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public static class Switch {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        static int _count_x, _count_y;

        static int _count, _position_x;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        /// <summary>
        /// Initializes the index.
        /// </summary>
        public static void InitIndex(int count_x, int count_y) {
            _count_x = count_x; _count_y = count_y;
            _count = _position_x = 0;
        }

        /// <summary>
        /// Provides the next index.
        /// </summary>
        public static int NextIndex() {
            if (_count_x % 2 == 0 && _position_x == _count_x) {
                _position_x = 0; _count = _count - 1;
            }
            int value = _count % 2 == 0 ? 0 : 1;
            _count++; _position_x++;
            return value;
        }
    }
}