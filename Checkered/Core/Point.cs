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

namespace Checkered.Core {

    public class Point {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        float _x, _y;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Point(float x, float y) {
            _x = x; _y = y;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, noun phrase, adjective] 

        public float X { get => _x; set => _x = value; }

        public float Y { get => _y; set => _y = value; }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        public override bool Equals(object? obj) {
            if ((obj == null) || !GetType().Equals(obj.GetType())) {
                return false;
            }
            else {
                Point other = (Point) obj;
                return (_x == other.X) && (_y == other.Y);
            }
        }

        public override int GetHashCode() {
            return HashCode.Combine(_x.GetHashCode(), _y.GetHashCode());
        }

        public override string ToString() {
            return $"{{X={_x}, Y={_y}}}";
        }
    }
}
