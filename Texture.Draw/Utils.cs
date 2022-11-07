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

using System.Linq;
using System.Drawing;

using TPoint = Texture.Core.Point;

namespace Texture.Draw {
    /// <summary>
    /// utils class
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public static class Utils {
#nullable enable

        public static PointF[] MapPoints(TPoint[] points) {
            return points.Select(selector: x => new PointF(x: x.X, y: x.Y)).ToArray();
        }

        public static PointF MapPoint(TPoint point) {
            return new(x: point.X, y: point.Y);
        }

    }
}
