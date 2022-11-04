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

namespace Checkered.Core {

    public static class Switch {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        static int _count_x, _count_y;

        static int _count, _position_x;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        public static void InitIndex(int count_x, int count_y) {
            _count_x = count_x; _count_y = count_y;
            _count = _position_x = 0;
        }

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
