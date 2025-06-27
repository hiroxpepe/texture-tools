﻿// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using static System.Math;

namespace System.Drawing {
    /// <summary>
    /// Represents the HSVColor class.
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
        /// Converts to range 0 to 360.
        /// </summary>
        public static int ToDegree(float float_value) {
            if (float_value < 0.0f || float_value > 1.0f) {
                throw new ArgumentException("The argument must be in the range 0 to 1.0f.");
            }
            int degree = (int) Round(float_value * 360.0f);
            return degree;
        }

        /// <summary>
        /// Converts to range 0 to 100.
        /// </summary>
        public static int ToPercentage(float float_value) {
            if (float_value < 0.0f || float_value > 1.0f) {
                throw new ArgumentException("The argument must be in the range 0 to 1.0f.");
            }
            int percentage = (int) (float_value * 100.0f);
            return percentage;
        }

        /// <summary>
        /// Converts from range 0 to 360 to a float value.
        /// </summary>
        public static float FromDegree(int degree) {
            if (degree < 0 || degree > 360) {
                throw new ArgumentException("The argument must be in the range 0 to 360.");
            }
            float float_value = degree / 360.0f;
            return float_value;
        }

        /// <summary>
        /// Converts from range 0 to 100 to a float value.
        /// </summary>
        public static float FromPercentage(int percentage) {
            if (percentage < 0 || percentage > 100) {
                throw new ArgumentException("The argument must be in the range 0 to 100.");
            }
            float float_value = percentage / 100.0f;
            return float_value;
        }

        /// <summary>
        /// Provides functionality for test.
        /// </summary>
        public static (float hue, float saturation, float value) _public_color_to_hsv(Color color) {
            return color_to_hsv(color: color);
        }

        /// <summary>
        /// Provides functionality for test.
        /// </summary>
        public static Color _public_hsv_to_color(float hue, float saturation, float value) {
            return hsv_to_color(hue: hue, saturation: saturation, value: value);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb, verb phrases]

        /// <summary>
        /// Converts Color to HSV.
        /// </summary>
        static (float hue, float saturation, float value) color_to_hsv(Color color) {
            // Converts RGB values to range 0 to 1.
            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;
            // Gets the maximum and minimum RGB value.
            float max = Max(val1: r, val2: Max(val1: g, val2: b));
            float min = Min(val1: r, val2: Min(val1: g, val2: b));
            // Hue calculation.
            float hue = 0; // Initialization.
            float delta = max - min; // Gets the difference used for hue calculation.
            // Calculates hue if maximum and minimum values are different.
            if (max != min) {
                // When red is the maximum.
                if (max == r) {
                    hue = (g - b) / delta + (g < b ? 6 : 0); // Calculates the hue of red.
                }
                // When green is the maximum.
                else if (max == g) {
                    hue = (b - r) / delta + 2; // Calculates the hue of green.
                }
                // When blue is the maximum.
                else {
                    hue = (r - g) / delta + 4; // Calculates the hue of blue.
                }
                hue /= 6; // Normalizes hue.
            }
            // Saturation calculation.
            float saturation = max == 0 ? 0 : delta / max;
            // Value calculation.
            float value = max;
            // Returns calculation results.
            return (hue, saturation, value);
        }

        /// <summary>
        /// Converts HSV to Color.
        /// </summary>
        static Color hsv_to_color(float hue, float saturation, float value) {
            hue = (hue % 1.0f + 1.0f) % 1.0f; // Constrains hue to the range 0 to 1.
            saturation = Max(val1: 0.0f, val2: Min(val1: 1.0f, val2: saturation)); // Constrains saturation to range 0 to 1.
            value = Max(val1: 0.0f, val2: Min(val1: 1.0f, val2: value)); // Constrains value to the range 0 to 1.
            // Divides the hue into 6 equal parts and gets the standard value of the corresponding color.
            int hi = (int) (hue * 6) % 6;
            // Calculates the decimal part.
            float f = hue * 6 - hi;
            // Multiplies the brightness by 255 and converts it to an integer.
            value *= 255;
            int v = (int) Round(value: value, mode: MidpointRounding.ToEven);
            // Calculates each ingredient.
            int p = (int) Round(value: value * (1.0f - saturation), mode: MidpointRounding.ToEven);
            int q = (int) Round(value: value * (1.0f - f * saturation), mode: MidpointRounding.ToEven);
            int t = (int) Round(value: value * (1.0f - (1.0f - f) * saturation), mode: MidpointRounding.ToEven);
            // Calculates each RGB component based on hue and returns a color object.
            switch (hi) {
                case 0: return Color.FromArgb(alpha: 255, red: v, green: t, blue: p);
                case 1: return Color.FromArgb(alpha: 255, red: q, green: v, blue: p);
                case 2: return Color.FromArgb(alpha: 255, red: p, green: v, blue: t);
                case 3: return Color.FromArgb(alpha: 255, red: p, green: q, blue: v);
                case 4: return Color.FromArgb(alpha: 255, red: t, green: p, blue: v);
                case 5: return Color.FromArgb(alpha: 255, red: v, green: p, blue: q);
                default: return Color.Black;
            }
        }
    }
}