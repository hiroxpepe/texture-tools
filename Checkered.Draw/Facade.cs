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

using Checkered.Core;
using Checkered.Draw;
using static Checkered.Core.Cut;
using static Checkered.Core.Face;
using static Checkered.Draw.Tool;

namespace Checkered {

    public static class Facade {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        public static void Execute() {
            Cut cut = NewCutBySlice(slice_count_x: 4, slice_count_y: 4);
            Face face = NewFace(width: 300, hight: 300, cut: cut);
            Tool tool = NewTool(face: face);
            int count = 0;
            face.OnReady += () => {
                face.AllPoint.ForEach(action: x => {
                    Color color = count % 2 == 0 ? Color.Red : Color.White;
                    tool.Fill(points: x, color: color);
                    count++;
                });
            };
            face.OnWrite += () => {
                tool.Write();
            };
            face.Make();
        }
    }
}
