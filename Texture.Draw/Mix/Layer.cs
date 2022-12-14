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

using Texture.Core;

namespace Texture.Mix {

    public class Layer : ILayer {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        Bitmap? _bitmap;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Layer(Bitmap? bitmap) {
            _bitmap = bitmap;
        }

        public static Layer NewLayer(int width, int hight, Cut cut) {
            return null;// new(width, hight, cut);
        }
    }
}
