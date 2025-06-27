using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using static System.Drawing.Color;
using static System.Drawing.HSVColor;

namespace System.Drawing {
    [TestClass()]
    public class HSVColorTests {
        [TestMethod("Red HSV: 355, 80, 100")]
        public void color_to_hsv_test1() {
            (float hue, float saturation, float value) = _public_color_to_hsv(color: FromArgb(255, 51, 68));
            AreEqual(355, ToDegree(float_value: hue));
            AreEqual(80, ToPercentage(float_value: saturation));
            AreEqual(100, ToPercentage(float_value: value));
        }
        [TestMethod("Orange HSV: 20, 80, 100")]
        public void color_to_hsv_test2() {
            (float hue, float saturation, float value) = _public_color_to_hsv(color: FromArgb(255, 119, 51));
            AreEqual(20, ToDegree(float_value: hue));
            AreEqual(80, ToPercentage(float_value: saturation));
            AreEqual(100, ToPercentage(float_value: value));
        }
        [TestMethod("Amber HSV: 45, 80, 100")]
        public void color_to_hsv_test3() {
            (float hue, float saturation, float value) = _public_color_to_hsv(color: FromArgb(255, 204, 51));
            AreEqual(45, ToDegree(float_value: hue));
            AreEqual(80, ToPercentage(float_value: saturation));
            AreEqual(100, ToPercentage(float_value: value));
        }
        [TestMethod("Yellow HSV: 60, 80, 100")]
        public void color_to_hsv_test4() {
            (float hue, float saturation, float value) = _public_color_to_hsv(color: FromArgb(255, 255, 51));
            AreEqual(60, ToDegree(float_value: hue));
            AreEqual(80, ToPercentage(float_value: saturation));
            AreEqual(100, ToPercentage(float_value: value));
        }
        [TestMethod("Lime HSV: 80, 80, 100")]
        public void color_to_hsv_test5() {
            (float hue, float saturation, float value) = _public_color_to_hsv(color: FromArgb(187, 255, 51));
            AreEqual(80, ToDegree(float_value: hue));
            AreEqual(80, ToPercentage(float_value: saturation));
            AreEqual(100, ToPercentage(float_value: value));
        }
        [TestMethod("Green HSV: 135, 80, 80")]
        public void color_to_hsv_test6() {
            (float hue, float saturation, float value) = _public_color_to_hsv(color: FromArgb(40, 204, 81));
            AreEqual(135, ToDegree(float_value: hue));
            AreEqual(80, ToPercentage(float_value: saturation));
            AreEqual(80, ToPercentage(float_value: value));
        }
        [TestMethod("Turquoise HSV: 180, 80, 70")]
        public void color_to_hsv_test7() {
            (float hue, float saturation, float value) = _public_color_to_hsv(color: FromArgb(35, 179, 179));
            AreEqual(180, ToDegree(float_value: hue));
            AreEqual(80, ToPercentage(float_value: saturation));
            AreEqual(70, ToPercentage(float_value: value));
        }
        [TestMethod("Azure HSV: 210, 80, 95")]
        public void color_to_hsv_test8() {
            (float hue, float saturation, float value) = _public_color_to_hsv(color: FromArgb(48, 145, 243));
            AreEqual(210, ToDegree(float_value: hue));
            AreEqual(80, ToPercentage(float_value: saturation));
            AreEqual(95, ToPercentage(float_value: value));
        }
        [TestMethod("Blue HSV: 240, 80, 100")]
        public void color_to_hsv_test9() {
            (float hue, float saturation, float value) = _public_color_to_hsv(color: FromArgb(51, 51, 255));
            AreEqual(240, ToDegree(float_value: hue));
            AreEqual(80, ToPercentage(float_value: saturation));
            AreEqual(100, ToPercentage(float_value: value));
        }
        [TestMethod("Purple HSV: 270, 80, 90")]
        public void color_to_hsv_test10() {
            (float hue, float saturation, float value) = _public_color_to_hsv(color: FromArgb(138, 46, 230));
            AreEqual(270, ToDegree(float_value: hue));
            AreEqual(80, ToPercentage(float_value: saturation));
            AreEqual(90, ToPercentage(float_value: value));
        }
        [TestMethod("Magenta HSV: 300, 80, 85")]
        public void color_to_hsv_test11() {
            (float hue, float saturation, float value) = _public_color_to_hsv(color: FromArgb(217, 43, 217));
            AreEqual(300, ToDegree(float_value: hue));
            AreEqual(80, ToPercentage(float_value: saturation));
            AreEqual(85, ToPercentage(float_value: value));
        }
        [TestMethod("Rose HSV: 330, 80, 95")]
        public void color_to_hsv_test12() {
            (float hue, float saturation, float value) = _public_color_to_hsv(color: FromArgb(243, 48, 145));
            AreEqual(330, ToDegree(float_value: hue));
            AreEqual(80, ToPercentage(float_value: saturation));
            AreEqual(95, ToPercentage(float_value: value));
        }
        [TestMethod("Red RGB: 255, 51, 68")]
        public void hsv_to_color_test1() {
            Color color = _public_hsv_to_color(
                hue: FromDegree(degree: 355),
                saturation: FromPercentage(percentage: 80),
                value: FromPercentage(percentage: 100)
            );
            AreEqual(expected: 255, actual: color.R, delta: 1.0f);
            AreEqual(expected: 51, actual: color.G, delta: 1.0f);
            AreEqual(expected: 68, actual: color.B, delta: 1.0f);
        }
        [TestMethod("Orange RGB: 255, 119, 51")]
        public void hsv_to_color_test2() {
            Color color = _public_hsv_to_color(
                hue: FromDegree(degree: 20),
                saturation: FromPercentage(percentage: 80),
                value: FromPercentage(percentage: 100)
            );
            AreEqual(expected: 255, actual: color.R, delta: 1.0f);
            AreEqual(expected: 119, actual: color.G, delta: 1.0f);
            AreEqual(expected: 51, actual: color.B, delta: 1.0f);
        }
        [TestMethod("Amber RGB: 255, 204, 51")]
        public void hsv_to_color_test3() {
            Color color = _public_hsv_to_color(
                hue: FromDegree(degree: 45),
                saturation: FromPercentage(percentage: 80),
                value: FromPercentage(percentage: 100)
            );
            AreEqual(expected: 255, actual: color.R, delta: 1.0f);
            AreEqual(expected: 204, actual: color.G, delta: 1.0f);
            AreEqual(expected: 51, actual: color.B, delta: 1.0f);
        }
        [TestMethod("Yellow RGB: 255, 255, 51")]
        public void hsv_to_color_test4() {
            Color color = _public_hsv_to_color(
                hue: FromDegree(degree: 60),
                saturation: FromPercentage(percentage: 80),
                value: FromPercentage(percentage: 100)
            );
            AreEqual(expected: 255, actual: color.R, delta: 1.0f);
            AreEqual(expected: 255, actual: color.G, delta: 1.0f);
            AreEqual(expected: 51, actual: color.B, delta: 1.0f);
        }
        [TestMethod("Lime RGB: 187, 255, 51")]
        public void hsv_to_color_test5() {
            Color color = _public_hsv_to_color(
                hue: FromDegree(degree: 80),
                saturation: FromPercentage(percentage: 80),
                value: FromPercentage(percentage: 100)
            );
            AreEqual(expected: 187, actual: color.R, delta: 1.0f);
            AreEqual(expected: 255, actual: color.G, delta: 1.0f);
            AreEqual(expected: 51, actual: color.B, delta: 1.0f);
        }
        [TestMethod("Green RGB: 40, 204, 81")]
        public void hsv_to_color_test6() {
            Color color = _public_hsv_to_color(
                hue: FromDegree(degree: 135),
                saturation: FromPercentage(percentage: 80),
                value: FromPercentage(percentage: 80)
            );
            AreEqual(expected: 40, actual: color.R, delta: 1.0f);
            AreEqual(expected: 204, actual: color.G, delta: 1.0f);
            AreEqual(expected: 81, actual: color.B, delta: 1.0f);
        }
        [TestMethod("Turquoise RGB: 35, 179, 179")]
        public void hsv_to_color_test7() {
            Color color = _public_hsv_to_color(
                hue: FromDegree(degree: 180),
                saturation: FromPercentage(percentage: 80),
                value: FromPercentage(percentage: 70)
            );
            AreEqual(expected: 35, actual: color.R, delta: 1.0f);
            AreEqual(expected: 179, actual: color.G, delta: 1.0f);
            AreEqual(expected: 179, actual: color.B, delta: 1.0f);
        }
        [TestMethod("Azure RGB: 48, 145, 243")]
        public void hsv_to_color_test8() {
            Color color = _public_hsv_to_color(
                hue: FromDegree(degree: 210),
                saturation: FromPercentage(percentage: 80),
                value: FromPercentage(percentage: 95)
            );
            AreEqual(expected: 48, actual: color.R, delta: 1.0f);
            AreEqual(expected: 145, actual: color.G, delta: 1.0f);
            AreEqual(expected: 243, actual: color.B, delta: 1.0f);
        }
        [TestMethod("Blue RGB: 51, 51, 255")]
        public void hsv_to_color_test9() {
            Color color = _public_hsv_to_color(
                hue: FromDegree(degree: 240),
                saturation: FromPercentage(percentage: 80),
                value: FromPercentage(percentage: 100)
            );
            AreEqual(expected: 51, actual: color.R, delta: 1.0f);
            AreEqual(expected: 51, actual: color.G, delta: 1.0f);
            AreEqual(expected: 255, actual: color.B, delta: 1.0f);
        }
        [TestMethod("Purple RGB: 138, 46, 230")]
        public void hsv_to_color_test10() {
            Color color = _public_hsv_to_color(
                hue: FromDegree(degree: 270),
                saturation: FromPercentage(percentage: 80),
                value: FromPercentage(percentage: 90)
            );
            AreEqual(expected: 138, actual: color.R, delta: 1.0f);
            AreEqual(expected: 46, actual: color.G, delta: 1.0f);
            AreEqual(expected: 230, actual: color.B, delta: 1.0f);
        }
        [TestMethod("Magenta RGB: 217, 43, 217")]
        public void hsv_to_color_test11() {
            Color color = _public_hsv_to_color(
                hue: FromDegree(degree: 300),
                saturation: FromPercentage(percentage: 80),
                value: FromPercentage(percentage: 85)
            );
            AreEqual(expected: 217, actual: color.R, delta: 1.0f);
            AreEqual(expected: 43, actual: color.G, delta: 1.0f);
            AreEqual(expected: 217, actual: color.B, delta: 1.0f);
        }
        [TestMethod("Rose RGB: 243, 48, 145")]
        public void hsv_to_color_test12() {
            Color color = _public_hsv_to_color(
                hue: FromDegree(degree: 330),
                saturation: FromPercentage(percentage: 80),
                value: FromPercentage(percentage: 95)
            );
            AreEqual(expected: 243, actual: color.R, delta: 1.0f);
            AreEqual(expected: 48, actual: color.G, delta: 1.0f);
            AreEqual(expected: 145, actual: color.B, delta: 1.0f);
        }
    }
}