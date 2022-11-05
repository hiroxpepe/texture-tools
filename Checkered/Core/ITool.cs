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
    /// <summary>
    /// interface of Tool.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public interface ITool {
        public void Draw(Point[] points);

        public void Draw(Point[] points, Color color);

        public void Fill(Point[] points);

        public void Fill(Point[] points, Color color);

        public void Fill(Point[] points, Color color, int img_idx);

        public void Fill(Point[] points, Color color, int img_idx, int cell_idx);

        public void Fill(Point[] points, Color color, int img_idx, int cell_idx, bool debug);

        public void Write(int img_idx);
    }
}
