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
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using static System.Environment;
using static System.Drawing.Brushes;
using static System.Drawing.Graphics;
using static System.Drawing.Imaging.ImageFormat;

using Texture.Core;
using TPoint = Texture.Core.Point;
using static Texture.Draw.Utils;

namespace Texture.Draw {
#pragma warning disable CA1416
    /// <summary>
    /// tool class
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public class Tool : ITool, IDisposable {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constants

        public const int LAYER_MAX = 4;

        public readonly string OUTPUT_DIR = GetFolderPath(SpecialFolder.DesktopDirectory);

        public readonly string OUTPUT_NAME = "output.png";

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        readonly Face[] _face_array;

        Bitmap?[] _bitmap_array;

        Bitmap? _tmp_bitmap;

        Graphics? _graphics;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Tool(Face[] face_array) {
            _face_array = face_array;
            _bitmap_array = new Bitmap[LAYER_MAX];
            init();
        }

        public static Tool NewTool(Face[] face_array) {
            return new(face_array);
        }

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

        public void Write(int img_idx) {
            ColorMatrix color_matrix = new();
            color_matrix.Matrix33 = (img_idx == 0) ? 1f : 0.5f;
            ImageAttributes image_attributes = new();
            image_attributes.SetColorMatrix(newColorMatrix: color_matrix);

            _graphics = FromImage(image: _tmp_bitmap);
            _graphics.DrawImage(
                image: _bitmap_array[img_idx], 
                destRect: new Rectangle(
                    x: 0,
                    y: 0,
                    width: _face_array[0].Width, 
                    height: _face_array[0].Hight
                ), 
                srcX: 0, 
                srcY: 0, 
                srcWidth: _face_array[img_idx].Width, 
                srcHeight: _face_array[img_idx].Hight, 
                srcUnit: GraphicsUnit.Pixel,
                imageAttrs: image_attributes
            );

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
            // sets a brush.
            Brush brush = color switch {
                Color.Red => new SolidBrush(System.Drawing.Color.FromArgb(255,51,68)), // HSV: 355,80,100
                Color.Orange => new SolidBrush(System.Drawing.Color.FromArgb(255,119,51)), // HSV: 20,80,100
                Color.Amber => new SolidBrush(System.Drawing.Color.FromArgb(255,204,51)), // HSV: 45,80,100
                Color.Yellow => new SolidBrush(System.Drawing.Color.FromArgb(255,255,51)), // HSV: 60,80,100
                Color.Lime => new SolidBrush(System.Drawing.Color.FromArgb(187,255,51)), // HSV: 80,80,100
                Color.Green => new SolidBrush(System.Drawing.Color.FromArgb(40,204,81)), // HSV: 135,80,80
                Color.Turquoise => new SolidBrush(System.Drawing.Color.FromArgb(35,179,179)), // HSV: 180,80,70
                Color.Azure => new SolidBrush(System.Drawing.Color.FromArgb(48,145,243)), // HSV: 210,80,95
                Color.Blue => new SolidBrush(System.Drawing.Color.FromArgb(51,51,255)), // HSV: 240,80,100
                Color.Purple => new SolidBrush(System.Drawing.Color.FromArgb(138,46,230)), // HSV: 270,80,90
                Color.Magenta => new SolidBrush(System.Drawing.Color.FromArgb(217,43,217)), // HSV: 300,80,85
                Color.Rose => new SolidBrush(System.Drawing.Color.FromArgb(243,48,145)), // HSV: 330,80,95
                Color.Black => Black,
                Color.White => White,
                _ => Black,
            };
            _graphics?.FillPolygon(brush: brush, points: MapPoints(points));
            // writes cell numbers as debug.
            if (debug) { 
                const string FONT_NAME = "MS UI Gothic"; const int FONT_SIZE = 10; 
                using (Font font = new Font(familyName: FONT_NAME, emSize: FONT_SIZE)) {
                    _graphics?.DrawString(cell_idx.ToString(), font, Black, MapPoints(points)[0]);
                }
            }
            // disposes of the graphics.
            if (_graphics is not null) { _graphics.Dispose(); _graphics = null; }
        }

        void init() {
            int idx = 0;
            // create an array of images for the number of Face objects.
            _face_array.ToList().ForEach(action: x => { 
                _bitmap_array[idx++] = new(width: x.Width, height: x.Hight); 
            });
            // the final output image size is index 0.
            _tmp_bitmap = new Bitmap(
                width: _face_array[0].Width, 
                height: _face_array[0].Hight
            );
        }
    }
#pragma warning restore CA1416
}