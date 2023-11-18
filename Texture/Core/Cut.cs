// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

namespace Texture.Core {
    /// <summary>
    /// cut class
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public class Cut {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        int _x, _y;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Cut(int x, int y) {
            _x = x; _y = y;
        }

        public static Cut NewCutBySlice(int slice_count_x, int slice_count_y) {
            return new(x: slice_count_x, y: slice_count_y);
        }

        public static Cut NewCutByPiece(int piece_count_x, int piece_count_y) {
            return new(x: piece_count_x - 1, y: piece_count_y - 1);
        }

        public static Cut NewCutDefault() {
            return new(x: 2, y: 2); // 3 * 3
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, noun phrase, adjective] 

        public int X { get => _x; }

        public int Y { get => _y; }

        public int CountX { get => _x + 1; }

        public int CountY { get => _y + 1; }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb, verb phrases]

        int _getCountX() { return CountX; } // for UnitTest

        int _getCountY() { return CountY; } // for UnitTest
    }
}