// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;
using static System.Environment;
using static System.Drawing.Brushes;
using static System.Drawing.Color;
using static System.Drawing.Graphics;
using static System.Drawing.Imaging.ImageFormat;

using TColor = Texture.Color;
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

        public void Draw(TPoint[] points, TColor color) {
            throw new NotImplementedException();
        }

        public void Fill(TPoint[] points) {
            fill(points, TColor.Red);
        }

        public void Fill(TPoint[] points, TColor color) {
            fill(points, color);
        }

        public void Fill(TPoint[] points, TColor color, int img_idx = 0) {
            fill(points, color, img_idx);
        }

        public void Fill(TPoint[] points, TColor color, int img_idx = 0, int cell_idx = 0) {
            fill(points, color, img_idx, cell_idx);
        }

        public void Fill(TPoint[] points, TColor color, int img_idx = 0, int cell_idx = 0, bool debug = false) {
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

        void fill(TPoint[] points, TColor color, int img_idx = 0, int cell_idx = 0, bool debug = false) {
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
        static Brush create_brush(TColor color) {

            float hue_range = 0.01f; // 0.10f;
            float saturation_range = 0.03f; // 0.10f;
            float value_range = 0.05f; // 0.10f;

            return color switch {
                // HSV: 355,80,100
                TColor.Red => brush_from_color(color: FromArgb(255, 51, 68), hue_range, saturation_range, value_range),
                // HSV: 20,80,100
                TColor.Orange => brush_from_color(color: FromArgb(255, 119, 51), hue_range, saturation_range, value_range),
                // HSV: 45,80,100
                TColor.Amber => brush_from_color(color: FromArgb(255, 204, 51), hue_range, saturation_range, value_range),
                // HSV: 60,80,100
                TColor.Yellow => brush_from_color(color: FromArgb(255, 255, 51), hue_range, saturation_range, value_range),
                // HSV: 80,80,100
                TColor.Lime => brush_from_color(color: FromArgb(187, 255, 51), hue_range, saturation_range, value_range),
                // HSV: 135,80,80
                TColor.Green => brush_from_color(color: FromArgb(40, 204, 81), hue_range, saturation_range, value_range),
                // HSV: 180,80,70
                TColor.Turquoise => brush_from_color(color: FromArgb(35, 179, 179), hue_range, saturation_range, value_range),
                // HSV: 210,80,95
                TColor.Azure => brush_from_color(color: FromArgb(48, 145, 243), hue_range, saturation_range, value_range),
                // HSV: 240,80,100
                TColor.Blue => brush_from_color(color: FromArgb(51, 51, 255), hue_range, saturation_range, value_range),
                // HSV: 270,80,90
                TColor.Purple => brush_from_color(color: FromArgb(138, 46, 230), hue_range, saturation_range, value_range),
                // HSV: 300,80,85
                TColor.Magenta => brush_from_color(color: FromArgb(217, 43, 217), hue_range, saturation_range, value_range),
                // HSV: 330,80,95
                TColor.Rose => brush_from_color(color: FromArgb(243, 48, 145), hue_range, saturation_range, value_range),
                TColor.Black => Brushes.Black,
                TColor.White => Brushes.White,
                _ => Brushes.Black,
            };
        }

        /// <summary>
        /// creates a System.Drawing.SolidBrush object.
        /// </summary>
        static SolidBrush brush_from_color(System.Drawing.Color color, float hue_range = 0f, float saturation_range = 0f, float value_range = 0f) {
            float hue_changing = random_value(range: hue_range);
            float saturation_changing = random_value(range: saturation_range);
            float value_changing = random_value(range: value_range);
            return new SolidBrush(HSVColor.ToColor(
                color: color, 
                hue_changing: hue_changing,
                saturation_changing: saturation_changing,
                value_changing: value_changing
            ));
        }

        /// <summary>
        /// create random value
        /// </summary>
        static float random_value(float range) {
            int min_value = -(int) (range * 100);
            int max_value = (int) (range * 100);
            int random_value = _random.Next(min_value, max_value + 1);
            return random_value / 100.0f;
        }
    }
#pragma warning restore CA1416
}