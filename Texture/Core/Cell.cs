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
    /// cell class
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public class Cell {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constants

        const int LEFT_TOP = 0;
        const int RIGHT_TOP = 1;
        const int LEFT_BOTTOM = 3;
        const int RIGHT_BOTTOM = 2;
        const int END_POINT = 4;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        Point[] _point_array;

        int _col_idx, _row_idx;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Cell(int col_idx, int row_idx, Point origin) {
            _point_array = new Point[5];
            _col_idx = col_idx; _row_idx = row_idx; _point_array[LEFT_TOP] = _point_array[END_POINT] = origin;
        }

        public static Cell NewCell(int col_idx, int row_idx, Point left_top_point) {
            return new(col_idx, row_idx, left_top_point);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, noun phrase, adjective] 

        public Point LeftTopPoint { get => _point_array[LEFT_TOP]; }

        public Point RightTopPoint { set => _point_array[RIGHT_TOP] = value; }

        public Point LeftBottomPoint { set => _point_array[LEFT_BOTTOM] = value; }

        public Point RightBottomPoint { set => _point_array[RIGHT_BOTTOM] = value; }

        public Point[] AllPoint { get => _point_array; }
    }
}
