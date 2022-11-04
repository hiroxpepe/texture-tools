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

namespace Checkered {
    /// <summary>
    /// interface of Tool.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public interface ITool {
        public void Draw(PointF[] points);

        public void Draw(PointF[] points, Color color);

        public void Fill(PointF[] points);

        public void Fill(PointF[] points, Color color);

        public void Fill(PointF[] points, Color color, int idx);

        public void Fill(PointF[] points, Color color, int idx, bool debug);

        public void Write();
    }
}
