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
using System.Linq;

using Checkered.Core;
using Checkered.Draw;
using static Checkered.Core.Cut;
using static Checkered.Core.Face;
using static Checkered.Core.Switch;
using static Checkered.Draw.Tool;

namespace Checkered {

    public static class Facade {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        static Random _random = new();

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        public static void Execute() {
            Cut cut = NewCutByPiece(piece_count_x: 6, piece_count_y: 6);
            Face face = NewFace(width: 256, hight: 256, cut: cut);
            Tool tool = NewTool(face: face);
            int count = 0;
            face.OnReady += () => {
                // randomize
                face.AllPoint.ForEach(action: x => {
                    x.Where(predicate: x => !x.FixedX).ToList().ForEach(action: x => {
                        if (!x.MovedX) { x.X += _random.Next(minValue: 0, maxValue: 5); x.MovedX = true; }
                    });
                    x.Where(predicate: x => !x.FixedY).ToList().ForEach(action: x => {
                        if (!x.MovedY) { x.Y += _random.Next(minValue: 0, maxValue: 5); x.MovedY = true; }
                    });
                });
                // fills by color
                InitIndex(count_x: face.CountX, count_y: face.CountY);
                face.AllPoint.ForEach(action: x => {
                    Color color = NextIndex() % 2 == 0 ? Color.Red : Color.White;
                    tool.Fill(points: x, color: color, idx: count, debug: false);
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
