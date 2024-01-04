// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using static System.Math;

namespace System.Drawing {
    /// <summary>
    /// HSVColor class
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public static class HSVColor {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        public static Color ToColor(Color color, float modifying_hue = 0f, float modifying_saturation = 0f, float modifying_value = 0f) {
            (float hue, float saturation, float value) = color_to_hsv(color);
            Color modified_color = hsv_to_color(
                hue += modifying_hue, 
                saturation += modifying_saturation, 
                value += modifying_value
            );
            return modified_color;
        }

        /// <summary>
        /// convert to range 0 to 360.
        /// </summary>
        public static int ToDegree(float float_value) {
            if (float_value < 0.0f || float_value > 1.0f) {
                throw new ArgumentException("the argument must be in the range 0 to 1.0f.");
            }
            int degree = (int) Round(float_value * 360.0f);
            return degree;
        }

        /// <summary>
        /// convert to range 0 to 100.
        /// </summary>
        public static int ToPercentage(float float_value) {
            if (float_value < 0.0f || float_value > 1.0f) {
                throw new ArgumentException("the argument must be in the range 0 to 1.0f.");
            }
            int percentage = (int) (float_value * 100.0f);
            return percentage;
        }

        /// <summary>
        /// convert from range 0 to 360 to a float value.
        /// </summary>
        public static float FromDegree(int degree) {
            if (degree < 0 || degree > 360) {
                throw new ArgumentException("the argument must be in the range 0 to 360.");
            }
            float float_value = degree / 360.0f;
            return float_value;
        }

        /// <summary>
        /// convert from range 0 to 100 to a float value.
        /// </summary>
        public static float FromPercentage(int percentage) {
            if (percentage < 0 || percentage > 100) {
                throw new ArgumentException("the argument must be in the range 0 to 100.");
            }
            float float_value = percentage / 100.0f;
            return float_value;
        }

        /// <summary>
        /// for test.
        /// </summary>
        public static (float hue, float saturation, float value) _public_color_to_hsv(Color color) {
            return color_to_hsv(color: color);
        }

        /// <summary>
        /// for test.
        /// </summary>
        public static Color _public_hsv_to_color(float hue, float saturation, float value) {
            return hsv_to_color(hue: hue, saturation: saturation, value: value);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb, verb phrases]

        /// <summary>
        /// convert Color to HSV
        /// </summary>
        static (float hue, float saturation, float value) color_to_hsv(Color color) {
            // convert RGB values to range 0 to 1.
            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;

            // get the maximum and minimum RGB value.
            float max = Max(val1: r, val2: Max(val1: g, val2: b));
            float min = Min(val1: r, val2: Min(val1: g, val2: b));

            // hue calculation.
            float hue = 0; // initialization.
            float delta = max - min; // get the difference used for hue calculation.

            // calculate hue if maximum and minimum values are different.
            if (max != min) {
                // when red is the maximum.
                if (max == r) {
                    hue = (g - b) / delta + (g < b ? 6 : 0); // calculate the hue of red
                }
                // when green is the maximum
                else if (max == g) {
                    hue = (b - r) / delta + 2; // calculate the hue of green.
                }
                // when blue is the maximum.
                else {
                    hue = (r - g) / delta + 4; // calculate the hue of blue.
                }
                hue /= 6; // normalize hue.
            }

            // saturation calculation.
            float saturation = max == 0 ? 0 : delta / max;

            // Value calculation.
            float value = max;

            // return calculation results.
            return (hue, saturation, value);
        }

        /// <summary>
        /// convert HSV to Color
        /// </summary>
        static Color hsv_to_color(float hue, float saturation, float value) {
            hue = (hue % 1.0f + 1.0f) % 1.0f; // constrain hue to the range 0 to 1.
            saturation = Max(0.0f, Min(1.0f, saturation)); // constrain saturation to range 0 to 1.
            value = Max(0.0f, Min(1.0f, value)); // constrain value to the range 0 to 1.

            int hi = (int)(hue * 6) % 6;
            float f = hue * 6 - hi;
            value *= 255;
            int v = (int) Round(value, MidpointRounding.ToEven);
            int p = (int) Round(value * (1.0f - saturation), MidpointRounding.ToEven);
            int q = (int) Round(value * (1.0f - f * saturation), MidpointRounding.ToEven);
            int t = (int) Round(value * (1.0f - (1.0f - f) * saturation), MidpointRounding.ToEven);
            switch (hi) {
                case 0: return Color.FromArgb(255, v, t, p);
                case 1: return Color.FromArgb(255, q, v, p);
                case 2: return Color.FromArgb(255, p, v, t);
                case 3: return Color.FromArgb(255, p, q, v);
                case 4: return Color.FromArgb(255, t, p, v);
                case 5: return Color.FromArgb(255, v, p, q);
                default: return Color.Black;
            }
        }
    }
}