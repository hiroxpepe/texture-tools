/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 2 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

namespace Texture.Core {
    /// <summary>
    /// cut class
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public class Cut {
#nullable enable

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
