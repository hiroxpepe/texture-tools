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
using static System.Environment;
using static System.Drawing.Brushes;
using static System.Drawing.Graphics;
using static System.Drawing.Imaging.ImageFormat;

using Checkered.Core;

namespace Checkered.Draw {
#pragma warning disable CA1416

    public class Tool : ITool {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constants

        public readonly string OUTPUT_DIR = GetFolderPath(SpecialFolder.DesktopDirectory);

        public readonly string OUTPUT_NAME = "output.png";

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        readonly Face _face;

        Bitmap? _bitmap;

        Graphics? _graphics;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Tool(Face face) {
            _face = face;
            init();
        }

        public static Tool NewTool(Face face) {
            return new(face);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        public void Draw(PointF[] points) {
            throw new NotImplementedException();
        }

        public void Draw(PointF[] points, Color color) {
            throw new NotImplementedException();
        }

        public void Fill(PointF[] points) {
            _graphics?.FillPolygon(brush: Red, points: points);
        }

        public void Fill(PointF[] points, Color color) {
            Brush brush = White;
            switch (color) {
                case Color.Red: brush = Red; break;
                case Color.Black: brush = Black; break;
                case Color.White: brush = White; break;
            }
            _graphics?.FillPolygon(brush: brush, points: points);
        }

        public void Write() {
            _bitmap?.Save(filename: $"{OUTPUT_DIR}\\{OUTPUT_NAME}", format: Png);
            dispose();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb, verb phrases]

        void init() {
            _bitmap = new(width: _face.Hight, height: _face.Hight);
            _graphics = FromImage(image: _bitmap);
        }

        void dispose() {
            if (_graphics is not null) { _graphics.Dispose(); _graphics = null;  }
            if (_bitmap is not null) { _bitmap.Dispose(); _bitmap = null;  }
        }
    }
#pragma warning restore CA1416
}
