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

using System.Drawing;

namespace Checkered.Core {

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

        PointF[] _point_array;

        int _col_idx, _row_idx;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Cell(int col_idx, int row_idx, PointF origin) {
            _point_array = new PointF[5];
            _col_idx = col_idx; _row_idx = row_idx; _point_array[LEFT_TOP] = _point_array[END_POINT] = origin;
        }

        public static Cell NewCell(int col_idx, int row_idx, PointF left_top_point) {
            return new(col_idx, row_idx, left_top_point);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, noun phrase, adjective] 

        public PointF LeftTopPoint { get => _point_array[LEFT_TOP]; }

        public PointF RightTopPoint { set => _point_array[RIGHT_TOP] = value; }

        public PointF LeftBottomPoint { set => _point_array[LEFT_BOTTOM] = value; }

        public PointF RightBottomPoint { set => _point_array[RIGHT_BOTTOM] = value; }

        public PointF[] AllPoint { get => _point_array; }
    }
}
