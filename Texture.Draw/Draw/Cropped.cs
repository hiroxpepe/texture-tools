// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;
using System.Drawing;

namespace Texture.Draw {
    /// <summary>
    /// cropping class
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public class Cropped {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        Rectangle _src, _dest;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Cropped(Rectangle src, Rectangle dest) {
            _src = src; _dest = dest;
        }

        public static Cropped NewCropped(Rectangle src, Rectangle dest) {
            return new(src: src, dest: dest);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        public Rectangle Do() {
            // checks the point is zero.
            Point zero_point = new Point(x: 0, y: 0);
            if (_src.Location != zero_point && _dest.Location != zero_point) {
                throw new ArgumentException(message: "point must be zero.", paramName: nameof(Do));
            }
            // checks dest is bigger than src.
            if (_dest.Width < _src.Width || _dest.Height < _src.Height) {
                throw new ArgumentException(message: "dest must be bigger than src.", paramName: nameof(Do));
            }
            return cropping();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb, verb phrases]

        /// <summary>
        /// cropping the dest rectangle by the src rectangle.
        /// </summary>
        Rectangle cropping() {
            // calculates cropped dimensions.
            int cropped_width = _dest.Width - _src.Width;
            int cropped_height = _dest.Height - _src.Height;
            // calculates cropped position.
            int cropped_x = cropped_width / 2;
            int cropped_y = cropped_height / 2;
            // returns the cropped rectangle.
            return new Rectangle(
                location: new Point(x: cropped_x, y: cropped_y), 
                size: new Size(width: _src.Width, height: _src.Height)
            );
        }
    }
}