// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;

namespace Texture.Core {
    /// <summary>
    /// point class
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public class Point {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        float _x, _y;

        bool _fixed_x, _fixed_y, _moved_x, _moved_y;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Point(float x, float y) {
            _x = x; _y = y;
            _fixed_x = _fixed_y = _moved_x = _moved_y = false;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, noun phrase, adjective] 

        public float X { get => _x; set => _x = value; }

        public float Y { get => _y; set => _y = value; }

        public bool FixedX { get => _fixed_x; set => _fixed_x = value; }

        public bool FixedY { get => _fixed_y; set => _fixed_y = value; }

        public bool MovedX { get => _moved_x; set => _moved_x = value; }

        public bool MovedY { get => _moved_y; set => _moved_y = value; }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        public override bool Equals(object? obj) {
            if ((obj == null) || !GetType().Equals(o: obj.GetType())) {
                return false;
            }
            else {
                Point other = (Point) obj;
                return (_x == other.X) && (_y == other.Y);
            }
        }

        public override int GetHashCode() {
            return HashCode.Combine(_x.GetHashCode(), _y.GetHashCode());
        }

        public override string ToString() {
            return $"{{ X = {_x}, Y = {_y} }}";
        }
    }
}