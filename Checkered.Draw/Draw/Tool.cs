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
using System.Linq;
using static System.Environment;
using static System.Drawing.Brushes;
using static System.Drawing.Graphics;
using static System.Drawing.Imaging.ImageFormat;

using Checkered.Core;
using CPoint = Checkered.Core.Point;
using static Checkered.Draw.Utils;

namespace Checkered.Draw {
#pragma warning disable CA1416

    public class Tool : ITool {
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

        public void Draw(CPoint[] points) {
            throw new NotImplementedException();
        }

        public void Draw(CPoint[] points, Color color) {
            throw new NotImplementedException();
        }

        public void Fill(CPoint[] points) {
            fill(points, Color.Red);
        }

        public void Fill(CPoint[] points, Color color) {
            fill(points, color);
        }

        public void Fill(CPoint[] points, Color color, int img_idx = 0) {
            fill(points, color, img_idx);
        }

        public void Fill(CPoint[] points, Color color, int img_idx = 0, int cell_idx = 0) {
            fill(points, color, img_idx, cell_idx);
        }

        public void Fill(CPoint[] points, Color color, int img_idx = 0, int cell_idx = 0, bool debug = false) {
            fill(points, color, img_idx, cell_idx, debug);
        }

        public void Overlap() {
        }

        public void Write() {
            _bitmap_array[0]?.Save(filename: $"{OUTPUT_DIR}\\{OUTPUT_NAME}", format: Png);
            dispose();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb, verb phrases]

        void fill(CPoint[] points, Color color, int img_idx = 0, int cell_idx = 0, bool debug = false) {
            // creates the graphics.
            _graphics = FromImage(image: _bitmap_array[img_idx]);
            // sets a brush.
            Brush brush = White;
            switch (color) {
                case Color.Red: brush = Red; break;
                case Color.Yellow: brush = Yellow; break;
                case Color.Magenta: brush = Magenta; break;
                case Color.Black: brush = Black; break;
                case Color.White: brush = White; break;
            }
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
            _face_array.ToList().ForEach(action: x => { _bitmap_array[idx++] = new(width: x.Hight, height: x.Hight); });
        }

        void dispose() {
            if (_graphics is not null) { _graphics.Dispose(); _graphics = null;  }
            _bitmap_array.ToList().ForEach(action: x => { if (x is not null) { x.Dispose(); } }); _bitmap_array = null;  
        }
    }
#pragma warning restore CA1416
}
