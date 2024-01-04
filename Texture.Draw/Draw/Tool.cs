// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using Point = System.Drawing.Point;
using static System.Environment;
using static System.Drawing.Brushes;
using static System.Drawing.Color;
using static System.Drawing.Graphics;
using static System.Drawing.Imaging.ImageFormat;

using Texture.Core;
using TPoint = Texture.Core.Point;
using static Texture.Utils;
using static Texture.Draw.Cropped;

namespace Texture.Draw {
#pragma warning disable CA1416
    /// <summary>
    /// tool class
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public class Tool : ITool, IDisposable {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constants

        public const int LAYER_MAX = 4;

        public readonly string OUTPUT_DIR = GetFolderPath(SpecialFolder.DesktopDirectory);

        public readonly string OUTPUT_NAME = "blcb_basic.png";

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        readonly Rectangle _rect;

        readonly Face[] _face_array;

        Bitmap?[] _bitmap_array;

        Bitmap? _tmp_bitmap;

        Graphics? _graphics;

        static Random _random = new Random();

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Tool(Rectangle rect, Face[] face_array) {
            _rect = rect;
            _face_array = face_array;
            _bitmap_array = new Bitmap[LAYER_MAX];
            init();
        }

        public static Tool NewTool(Rectangle rect, Face[] face_array) {
            return new(rect, face_array);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, adjective]

        public string FilePath { get => $"{OUTPUT_DIR}\\{OUTPUT_NAME}"; }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        public void Draw(TPoint[] points) {
            throw new NotImplementedException();
        }

        public void Draw(TPoint[] points, Color color) {
            throw new NotImplementedException();
        }

        public void Fill(TPoint[] points) {
            fill(points, Color.Red);
        }

        public void Fill(TPoint[] points, Color color) {
            fill(points, color);
        }

        public void Fill(TPoint[] points, Color color, int img_idx = 0) {
            fill(points, color, img_idx);
        }

        public void Fill(TPoint[] points, Color color, int img_idx = 0, int cell_idx = 0) {
            fill(points, color, img_idx, cell_idx);
        }

        public void Fill(TPoint[] points, Color color, int img_idx = 0, int cell_idx = 0, bool debug = false) {
            fill(points, color, img_idx, cell_idx, debug);
        }

        public void Write(int img_idx, float alpha = 1f, double angle = 0) {
            // gets ImageAttributes object.
            ImageAttributes image_attributes = get_image_attributes(alpha);
            // gets cropped rectangle.
            Rectangle cropped_rectangle = get_cropped_rectangle(img_idx);
            // creates Graphics object.
            _graphics = FromImage(image: _tmp_bitmap);
            // no rotation.
            if (angle is 0) {
                _graphics.DrawImage(
                    image: _bitmap_array[img_idx],
                    destRect: new Rectangle(
                        x: 0, y: 0, width: _rect.Width, height: _rect.Height
                    ),
                    srcX: cropped_rectangle.X, srcY: cropped_rectangle.Y,
                    srcWidth: cropped_rectangle.Width, srcHeight: cropped_rectangle.Height,
                    srcUnit: GraphicsUnit.Pixel,
                    imageAttrs: image_attributes
                );
            }
            // with rotation.
            else {
                if (_bitmap_array[img_idx] is null) { return; }

                Point[] dest_points = get_rotate_points(
                    rect: new Rectangle(
                        x: 0,
                        y: 0,
                        width: _bitmap_array[img_idx].Width,
                        height: _bitmap_array[img_idx].Height
                    ),
                    center_x: _bitmap_array[img_idx].Width / 2,
                    center_y: _bitmap_array[img_idx].Height / 2,
                    angle: angle
                );

                using Graphics? tmp_gr = FromImage(image: _bitmap_array[img_idx]);
                tmp_gr.DrawImage(
                    image: _bitmap_array[img_idx],
                    destPoints: dest_points,
                    srcRect: new Rectangle(
                        x: 0, y: 0,
                        width: _bitmap_array[img_idx].Width,
                        height: _bitmap_array[img_idx].Height
                    ),
                    srcUnit: GraphicsUnit.Pixel,
                    imageAttr: image_attributes
                );

                _bitmap_array[img_idx]?.Save(filename: $"{OUTPUT_DIR}\\tmp_{OUTPUT_NAME}", format: Png);
                using Image tmp_image = Image.FromFile(filename: $"{OUTPUT_DIR}\\tmp_{OUTPUT_NAME}");

                _graphics.DrawImage(
                    image: tmp_image,
                    destRect: new Rectangle(
                        x: 0, y: 0, width: _rect.Width, height: _rect.Height
                    ),
                    srcX: cropped_rectangle.X, srcY: cropped_rectangle.Y,
                    srcWidth: cropped_rectangle.Width, srcHeight: cropped_rectangle.Height,
                    srcUnit: GraphicsUnit.Pixel,
                    imageAttrs: image_attributes
                );
            }
            // saves as a PNG file.
            _tmp_bitmap?.Save(filename: $"{OUTPUT_DIR}\\{OUTPUT_NAME}", format: Png);
        }

        public void Dispose() {
            _graphics?.Dispose(); _graphics = null;
            _bitmap_array.ToList().ForEach(action: x => x?.Dispose());
            _tmp_bitmap?.Dispose();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb, verb phrases]

        void fill(TPoint[] points, Color color, int img_idx = 0, int cell_idx = 0, bool debug = false) {
            // creates the graphics.
            _graphics = FromImage(image: _bitmap_array[img_idx]);
            _graphics?.FillPolygon(brush: create_brush(color), points: MapPoints(points));
            // writes cell numbers as debug.
            if (debug) {
                const string FONT_NAME = "MS UI Gothic"; const int FONT_SIZE = 10;
                using (Font font = new Font(familyName: FONT_NAME, emSize: FONT_SIZE)) {
                    _graphics?.DrawString(cell_idx.ToString(), font, Brushes.Black, MapPoints(points)[0]);
                }
            }
            // disposes of the graphics.
            if (_graphics is not null) { _graphics.Dispose(); _graphics = null; }
        }

        void init() {
            int idx = 0;
            // creates an array of images for the number of Face objects.
            _face_array.ToList().ForEach(action: x => { 
                _bitmap_array[idx++] = new(width: x.Width, height: x.Height); 
            });
            // the final output image size is from by rect object.
            _tmp_bitmap = new Bitmap(
                width: _rect.Width, 
                height: _rect.Height
            );
        }

        /// <summary>
        /// creates ImageAttributes object.
        /// </summary>
        static ImageAttributes get_image_attributes(float alpha) {
            ColorMatrix color_matrix = new();
            color_matrix.Matrix33 = alpha;
            ImageAttributes image_attributes = new();
            image_attributes.SetColorMatrix(newColorMatrix: color_matrix);
            return image_attributes;
        }

        /// <summary>
        /// creates cropped rectangle.
        /// </summary>
        Rectangle get_cropped_rectangle(int img_idx) {
            Rectangle src = new(x: 0, y: 0, width: _rect.Width, height: _rect.Height);
            Rectangle dest = new(x: 0, y: 0, width: _face_array[img_idx].Width, height: _face_array[img_idx].Height);
            Cropped cropped = NewCropped(src: src, dest: dest);
            Rectangle cropped_rectangle = cropped.Do();
            return cropped_rectangle;
        }

        /// <summary>
        /// gets rotate points
        /// </summary>
        Point[] get_rotate_points(Rectangle rect, int center_x, int center_y, double angle) {
            int width = rect.Width / 2;
            int height = rect.Height / 2;
            double cos = Math.Cos(angle * Math.PI / 180);
            double sin = Math.Sin(angle * Math.PI / 180);
            Point[] points = new Point[] {
                new Point((int) (-cos * width + sin * height + center_x), (int) (-sin * width - cos * height + center_y)),
                new Point((int) (cos * width + sin * height + center_x), (int) (sin * width - cos * height + center_y)),
                new Point((int) (-cos * width - sin * height + center_x), (int) (-sin * width + cos * height + center_y)),
            };
            return points;
        }

        /// <summary>
        /// creates a System.Drawing.Brush object.
        /// </summary>
        static Brush create_brush(Color color) {
            return color switch {
                Color.Red => brush_from_color(color: FromArgb(255, 51, 68)), // HSV: 355,80,100
                Color.Orange => brush_from_color(color: FromArgb(255, 119, 51)), // HSV: 20,80,100
                Color.Amber => brush_from_color(color: FromArgb(255, 204, 51)), // HSV: 45,80,100
                Color.Yellow => brush_from_color(color: FromArgb(255, 255, 51)), // HSV: 60,80,100
                Color.Lime => brush_from_color(color: FromArgb(187, 255, 51)), // HSV: 80,80,100
                Color.Green => brush_from_color(color: FromArgb(40, 204, 81)), // HSV: 135,80,80
                Color.Turquoise => brush_from_color(color: FromArgb(35, 179, 179)), // HSV: 180,80,70
                Color.Azure => brush_from_color(color: FromArgb(48, 145, 243)), // HSV: 210,80,95
                Color.Blue => brush_from_color(color: FromArgb(51, 51, 255)), // HSV: 240,80,100
                Color.Purple => brush_from_color(color: FromArgb(138, 46, 230)), // HSV: 270,80,90
                Color.Magenta => brush_from_color(color: FromArgb(217, 43, 217)), // HSV: 300,80,85
                Color.Rose => brush_from_color(color: FromArgb(243, 48, 145)), // HSV: 330,80,95
                Color.Black => Brushes.Black,
                Color.White => Brushes.White,
                _ => Brushes.Black,
            };
        }

        /// <summary>
        /// creates a System.Drawing.SolidBrush object.
        /// </summary>
        static SolidBrush brush_from_color(System.Drawing.Color color) {
            float range_hue = Modify.Range.Hue;// 0.01f; // 0.10f;
            float range_saturation = Modify.Range.Saturation; // 0.03f; // 0.10f;
            float range_value = Modify.Range.Value; // 0.05f; // 0.10f;
            float modifying_hue = random_value(range: range_hue);
            float modifying_saturation = random_value(range: range_saturation);
            float modifying_value = random_value(range: range_value);
            return new SolidBrush(HSVColor.ToColor(
                color: color, 
                modifying_hue: modifying_hue,
                modifying_saturation: modifying_saturation,
                modifying_value: modifying_value
            ));
        }

        /// <summary>
        /// create random value
        /// </summary>
        static float random_value(float range) {
            int min_value = -(int) (range * 100);
            int max_value = (int) (range * 100);
            int random_value = _random.Next(minValue: min_value, maxValue: max_value + 1);
            return random_value / 100.0f;
        }
    }
#pragma warning restore CA1416
}