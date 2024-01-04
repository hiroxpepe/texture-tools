// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;
using System.Drawing;
using System.Linq;

using Texture.Core;
using Texture.Draw;
using static Texture.Core.Cut;
using static Texture.Core.Face;
using static Texture.Core.Swing;
using static Texture.Draw.Extensions;
using static Texture.Draw.Palette;
using static Texture.Draw.Switch;
using static Texture.Draw.Tool;

namespace Texture {
    /// <summary>
    /// context object for app.
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public static class Context {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Const [nouns]

        const int LAYER_1 = 0;
        const int LAYER_2 = 1;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        static Random _random = new();

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Events [verb, verb phrase]

        public static event Changed? OnDo;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        public static bool Do(Rectangle rect, Param[] param_array, bool use_layer2 = true) {
            try {
                // for layer 1.
                Cut cut1 = NewCutByPiece(piece_count: param_array[LAYER_1].PieceCount);
                Face face1 = NewFace(rect: rect, cut: cut1, crop: param_array[LAYER_1].Crop);
                Palette palette1 = NewPalette(
                    primary: param_array[LAYER_1].Primary,
                    secondary: param_array[LAYER_1].Secondary,
                    accent: param_array[LAYER_1].Accent,
                    alpha: param_array[LAYER_1].Alpha
                );
                Swing swing1 = NewSwing(value: param_array[LAYER_1].Swing);
                // for layer 2.
                Cut cut2 = NewCutByPiece(piece_count: param_array[LAYER_2].PieceCount);
                Face face2 = NewFace(rect: rect, cut: cut2, crop: param_array[LAYER_2].Crop);
                Palette palette2 = NewPalette(
                    primary: param_array[LAYER_2].Primary,
                    secondary: param_array[LAYER_2].Secondary,
                    accent: param_array[LAYER_2].Accent,
                    alpha: param_array[LAYER_2].Alpha
                );
                Swing swing2 = NewSwing(value: param_array[LAYER_2].Swing);
                // creates tool
                string flie_path;
                using (Tool tool = NewTool(rect: rect, face_array: new Face[] { face1, face2 })) {
                    flie_path = tool.FilePath;
                    // callback for layer 1.
                    int count = 0; int img_idx = 0;
                    face1.OnReady += () => {
                        // randomize
                        face1.AllPoint.ForEach(action: x => {
                            x.Where(predicate: x => !x.FixedX).ToList().ForEach(action: x => {
                                if (!x.MovedX) {
                                    x.X += _random.Next(minValue: swing1.MinValueX, maxValue: swing1.MaxValueX);
                                    x.MovedX = true;
                                }
                            });
                            x.Where(predicate: x => !x.FixedY).ToList().ForEach(action: x => {
                                if (!x.MovedY) {
                                    x.Y += _random.Next(minValue: swing1.MinValueY, maxValue: swing1.MaxValueY);
                                    x.MovedY = true;
                                }
                            });
                        });
                        // fills by color.
                        InitIndex(count_x: face1.CountX, count_y: face1.CountY);
                        face1.AllPoint.ForEach(action: x => {
                            Color color = NextIndex() % 2 == 0 ? palette1.Primary : palette1.Secondary;
                            tool.Fill(points: x, color: color, img_idx: img_idx, cell_idx: count, debug: false);
                            int random_number = _random.Next(1, (face1.AllPoint.Count / 2) + 1);
                            if (random_number == 1) {
                                if (palette1.Accent is not Color.none) {
                                    tool.Fill(points: x, color: palette1.Accent, img_idx: img_idx, cell_idx: count);
                                }
                            }
                            if (Modify.Mode.Line) {
                                tool.Draw(points: x);
                            }
                            count++;
                        });
                    };
                    face1.OnWrite += () => {
                        tool.Write(img_idx, alpha: palette1.Alpha, angle: 0);
                    };
                    // executes layer 1.
                    face1.Make();

                    if (use_layer2) {
                        // callback for layer 2.
                        count = 0; img_idx++;
                        face2.OnReady += () => {
                            // randomize
                            face2.AllPoint.ForEach(action: x => {
                                x.Where(predicate: x => !x.FixedX).ToList().ForEach(action: x => {
                                    if (!x.MovedX) {
                                        x.X += _random.Next(minValue: swing2.MinValueX, maxValue: swing2.MaxValueX);
                                        x.MovedX = true;
                                    }
                                });
                                x.Where(predicate: x => !x.FixedY).ToList().ForEach(action: x => {
                                    if (!x.MovedY) {
                                        x.Y += _random.Next(minValue: swing2.MinValueY, maxValue: swing2.MaxValueY);
                                        x.MovedY = true;
                                    }
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
                            tool.Write(img_idx, alpha: palette2.Alpha, angle: 0);
                        };
                        // executes layer 2.
                        face2.Make();
                    }
                }
                // calls event.
                OnDo?.Invoke(sender: flie_path, e: new EvtArgs(name: "file_path"));
                return true;
            }
            catch (Exception ex) {
                throw new Exception(message: ex.Message);
            }
        }
    }

    /// <summary>
    /// modify value object for app.
    /// </summary>
    public static class Modify {
        public static class Range {
            public static float Hue { get; set; } = 0.0f;
            public static float Saturation { get; set; } = 0.0f;
            public static float Value { get; set; } = 0.0f;
        }
        public static class Adjust {
            public static float Saturation { get; set; } = 0.0f;
            public static float Value { get; set; } = 0.0f;
        }
        public static class Mode {
            public static bool Expand { get; set; } = false;
            public static bool Rock { get; set; } = false;
            public static bool Line { get; set; } = false;
        }
        public static class Pen {
            public static float Alpha { get; set; } = 1.0f;
            public static float Width { get; set; } = 1.0f;
        }
    }
}