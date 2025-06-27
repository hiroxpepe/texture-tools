// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

namespace Texture.Core {
    /// <summary>
    /// Represents the cell class.
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public class Cell {

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