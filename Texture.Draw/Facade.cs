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

using Texture.Core;
using Texture.Draw;
using static Texture.Core.Cut;
using static Texture.Core.Face;
using static Texture.Draw.Switch;
using static Texture.Draw.Tool;

namespace Texture {
    /// <summary>
    /// facade class
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public static class Facade {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        static Random _random = new();

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        public static void Execute() {
            Cut cut1 = NewCutByPiece(piece_count_x: 7, piece_count_y: 7);
            Face face1 = NewFace(width: 256, hight: 256, cut: cut1);
            Cut cut2 = NewCutByPiece(piece_count_x: 5, piece_count_y: 5);
            Face face2 = NewFace(width: 256, hight: 256, cut: cut2);
            using Tool tool = NewTool(face_array: new Face[] { face1, face2 });
            // layer 1.
            int count = 0; int img_idx = 0;
            face1.OnReady += () => {
                // randomize
                face1.AllPoint.ForEach(action: x => {
                    x.Where(predicate: x => !x.FixedX).ToList().ForEach(action: x => {
                        if (!x.MovedX) { x.X += _random.Next(minValue: -10, maxValue: 10); x.MovedX = true; }
                    });
                    x.Where(predicate: x => !x.FixedY).ToList().ForEach(action: x => {
                        if (!x.MovedY) { x.Y += _random.Next(minValue: -10, maxValue: 10); x.MovedY = true; }
                    });
                });
                // fills by color.
                InitIndex(count_x: face1.CountX, count_y: face1.CountY);
                face1.AllPoint.ForEach(action: x => {
                    Color color = NextIndex() % 2 == 0 ? Color.Green : Color.Lime;
                    tool.Fill(points: x, color: color, img_idx: img_idx, cell_idx: count, debug: false);
                    int random_number = _random.Next(1, (face1.AllPoint.Count / 2) + 1);
                    if (random_number == 1) {
                        tool.Fill(points: x, color: Color.Yellow, img_idx: img_idx, cell_idx: count, debug: false);
                    }
                    count++;
                });
            };
            face1.OnWrite += () => {
                tool.Write(img_idx);
            };
            face1.Make();

            // layer 2.
            count = 0; img_idx++;
            face2.OnReady += () => {
                // randomize
                face2.AllPoint.ForEach(action: x => {
                    x.Where(predicate: x => !x.FixedX).ToList().ForEach(action: x => {
                        if (!x.MovedX) { x.X += _random.Next(minValue: -20, maxValue: 20); x.MovedX = true; }
                    });
                    x.Where(predicate: x => !x.FixedY).ToList().ForEach(action: x => {
                        if (!x.MovedY) { x.Y += _random.Next(minValue: -20, maxValue: 20); x.MovedY = true; }
                    });
                });
                // fills by color.
                InitIndex(count_x: face2.CountX, count_y: face2.CountY);
                face2.AllPoint.ForEach(action: x => {
                    Color color = NextIndex() % 2 == 0 ? Color.Magenta : Color.Yellow;
                    tool.Fill(points: x, color: color, img_idx: img_idx, cell_idx: count, debug: false);
                    count++;
                });
            };
            face2.OnWrite += () => {
                //tool.Write(img_idx);
            };
            //face2.Make();
        }
    }
}
