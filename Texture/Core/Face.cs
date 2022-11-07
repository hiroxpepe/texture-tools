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

using System;
using System.Collections.Generic;
using System.Linq;

using static Texture.Core.Cell;
using static Texture.Core.Hight;
using static Texture.Core.Width;

namespace Texture.Core {
    /// <summary>
    /// face class
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public class Face {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        Edge _width, _hight;

        Cut _cut;

        List<Point> _point_list;

        List<Cell> _cell_list;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Face(int width, int hight, Cut cut) {
            _width = NewWidth(length: width);
            _hight = NewHight(length: hight);
            _cut = cut;
            _point_list = new();
            _cell_list = new();
        }

        Face(int width, int hight) : this(width, hight, cut: Cut.NewCutDefault()) {
        }

        public static Face NewFace(int width, int hight, Cut cut) {
            return new(width, hight, cut);
        }

        public static Face NewFace(int width, int hight) {
            return new(width, hight);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, adjectives]

        public int Width { get => (int) _width.Length; }

        public int Hight { get => (int) _hight.Length; }

        public int CountX { get => _cut.CountX; }

        public int CountY { get => _cut.CountY; }

        public List<Point[]> AllPoint {
            get {
                List<Point[]> result = new();
                _cell_list.ForEach(action: x => result.Add(item: x.AllPoint));
                return result;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Events [verb, verb phrase]

        public event Action? OnReady, OnWrite;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        public void Make() {
            extend();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb, verb phrases]

        void extend() {
            // creates point list.
            const int TO_END = 1;
            float[] x_sliced = slice(Coordinate.X);
            float[] y_sliced = slice(Coordinate.Y);
            for (int y_idx = 0; y_idx < _cut.CountY + TO_END; y_idx++) {
                for (int x_idx = 0; x_idx < _cut.CountX + TO_END; x_idx++) {
                    Point point = new(x_sliced[x_idx], y_sliced[y_idx]);
                    _point_list.Add(item: point);
                }
            }
            setFixed();
            // creates cell list.
            for (int y_idx = 0; y_idx < _cut.CountY; y_idx++) {
                for (int x_idx = 0; x_idx < _cut.CountX; x_idx++) {
                    Point point = _point_list.Where(predicate: x => x.X == x_sliced[x_idx] && x.Y == y_sliced[y_idx]).First();
                    Cell cell = NewCell(col_idx: x_idx, row_idx: y_idx, left_top_point: point);
                    _cell_list.Add(item: cell);
                }
            }
            // finds and sets remaining points.
            const int TO_NEXT = 1;
            float x_value_prev, y_value_prev, x_value, y_value; x_value_prev = y_value_prev = x_value = y_value = 0;
            int cell_idx = 0;
            for (int y_idx = 0; y_idx < _cut.CountY; y_idx++) {
                y_value = y_sliced[y_idx + TO_NEXT] - y_value_prev;
                x_value_prev = 0;
                for (int x_idx = 0; x_idx < _cut.CountX; x_idx++) {
                    x_value = x_sliced[x_idx + TO_NEXT] - x_value_prev;
                    Cell cell = _cell_list[cell_idx];
                    Point left_top = cell.LeftTopPoint;
                    float left_top_x = left_top.X;
                    float left_top_y = left_top.Y;
                    Point right_top_point = _point_list.Where(predicate: x => x.X == (left_top_x + x_value) && x.Y == left_top_y).First();
                    cell.RightTopPoint = right_top_point;
                    Point left_bottom_point = _point_list.Where(predicate:x => x.X == left_top_x && x.Y == (left_top_y + y_value)).First();
                    cell.LeftBottomPoint = left_bottom_point;
                    Point right_bottom_point = _point_list.Where(predicate:x => x.X == (left_top_x + x_value) && x.Y == (left_top_y + y_value)).First();
                    cell.RightBottomPoint = right_bottom_point;
                    x_value_prev = x_sliced[x_idx + TO_NEXT];
                    cell_idx++;
                }
                y_value_prev = y_sliced[y_idx + TO_NEXT];
            }
            OnReady?.Invoke();
            OnWrite?.Invoke();
        }

        float[] slice(Coordinate coordinate) {
            const int TO_END = 1;
            int count, length; count = length = 0;
            switch (coordinate) {
                case Coordinate.X: count = _cut.CountX; length = Width; break;
                case Coordinate.Y: count = _cut.CountY; length = Hight; break;
            }
            float interval = (float) length / count;
            float[] result = new float[count + TO_END];
            for (int idx = 0; idx < count + TO_END; idx++) {
                result[idx] = (float) interval * idx;
            }
            return result;
        }

        void setFixed() {
            float min_x = 0f; float max_x = _width.Length; float min_y = 0f; float max_y = _hight.Length;
            _point_list.Where(predicate: x => x.X == min_x || x.X == max_y).ToList().ForEach(action: x => x.FixedX = true);
            _point_list.Where(predicate: x => x.Y == min_y || x.Y == max_y).ToList().ForEach(action: x => x.FixedY = true);
        }

        /// <note>
        /// for UnitTest
        /// </note>
        List<Point> _extendAndGetList() {
            extend();
            return _point_list;
        }
    }
}
