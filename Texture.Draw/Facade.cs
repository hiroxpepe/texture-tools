// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;
using System.Drawing;
using System.Linq;

using Texture.Core;
using Texture.Draw;
using static Texture.Core.Cut;
using static Texture.Core.Face;
using static Texture.Draw.Palette;
using static Texture.Draw.Switch;
using static Texture.Draw.Tool;

namespace Texture {
    /// <summary>
    /// facade class
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public static class Facade {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        static Random _random = new();

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        public static void Execute() {
            // output size.
            Rectangle rect = new(x: 0, y: 0, width: 256, height: 256);
            // for layer 1.
            Cut cut1 = NewCutByPiece(piece_count_x: 7, piece_count_y: 7);
            Face face1 = NewFace(width: rect.Width, hight: rect.Height, cut: cut1);
            Palette palette1 = NewPalette(
                primary: Color.Green, 
                secondary: Color.Lime,
                accent: Color.Yellow,
                alpha: 1f
            );
            // for layer 2.
            Cut cut2 = NewCutByPiece(piece_count_x: 6, piece_count_y: 6);
            Face face2 = NewFace(width: rect.Width, hight: rect.Height, cut: cut2, crop: 0.9d);
            Palette palette2 = NewPalette(
                primary: Color.Lime,
                secondary: Color.Yellow,
                alpha: 0.5f
            );
            // creates tool
            using Tool tool = NewTool(face_array: new Face[] { face1, face2 });

            // callback for layer 1.
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
                    Color color = NextIndex() % 2 == 0 ? palette1.Primary : palette1.Secondary;
                    tool.Fill(points: x, color: color, img_idx: img_idx, cell_idx: count, debug: false);
                    int random_number = _random.Next(1, (face1.AllPoint.Count / 2) + 1);
                    if (random_number == 1) {
                        tool.Fill(points: x, color: palette1.Accent, img_idx: img_idx, cell_idx: count);
                    }
                    count++;
                });
            };
            face1.OnWrite += () => {
                tool.Write(img_idx, palette1.Alpha);
            };
            // execute layer 1.
            face1.Make();

            // callback for layer 2.
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
                    Color color = NextIndex() % 2 == 0 ? palette2.Primary : palette2.Secondary;
                    tool.Fill(points: x, color: color, img_idx: img_idx, cell_idx: count);
                    count++;
                });
            };
            face2.OnWrite += () => {
                tool.Write(img_idx, palette2.Alpha);
            };
            // execute layer 2.
            face2.Make();
        }
    }
}