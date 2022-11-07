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
    /// edge class
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public class Edge {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        protected float _length;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        protected Edge(int length) {
            _length = (float) length;
        }

        public static Edge NewEdge(int length) {
            return new(length);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, noun phrase, adjective] 

        public float Length { get => _length; }
    }

    public class Width : Edge {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Width(int length) : base(length) {
        }

        public static Edge NewWidth(int length) {
            return new Width(length);
        }
    }

    public class Hight : Edge {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Hight(int length) : base(length) {
        }

        public static Edge NewHight(int length) {
            return new Hight(length);
        }
    }
}
