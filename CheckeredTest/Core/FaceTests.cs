using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;

using Checkered;
using Checkered.Core;
using static Checkered.Core.Cut;
using static Checkered.Core.Face;

namespace CheckeredTest {
    [TestClass()]
    public class FaceTests {
#nullable enable
        [TestMethod()]
        public void sliceTest1() {
            Face ob = NewFace(width: 5, hight: 5, cut: NewCutBySlice(slice_count_x: 1, slice_count_y: 1));
            float[]? result = new PrivateObject(ob: ob).Invoke(method_name: "slice", args: Coordinate.X) as float[];
            float[] expected = new [] { 0.0f, 2.5f, 5.0f };
            AreEqual(expected, result);
        }
        [TestMethod()]
        public void sliceTest2() {
            Face ob = NewFace(width: 5, hight: 5, cut: NewCutBySlice(slice_count_x: 1, slice_count_y: 1));
            float[]? result = new PrivateObject(ob: ob).Invoke(method_name: "slice", args: Coordinate.Y) as float[];
            float[] expected = new[] { 0.0f, 2.5f, 5.0f };
            AreEqual(expected, result);
        }
        [TestMethod()]
        public void sliceTest3() {
            Face ob = NewFace(width: 10, hight: 10, cut: NewCutBySlice(slice_count_x: 2, slice_count_y: 3));
            float[]? result = new PrivateObject(ob: ob).Invoke(method_name: "slice", args: Coordinate.X) as float[];
            float[] expected = new[] { 0.0f, (10f / 3f * 1f), (10f / 3f * 2f), (10f / 3f * 3f) };
            AreEqual(expected, result);
        }
        [TestMethod()]
        public void sliceTest4() {
            Face ob = NewFace(width: 10, hight: 10, cut: NewCutBySlice(slice_count_x: 2, slice_count_y: 3));
            float[]? result = new PrivateObject(ob: ob).Invoke(method_name: "slice", args: Coordinate.Y) as float[];
            float[] expected = new[] { 0.0f, (10f / 4f * 1f), (10f / 4f * 2f), (10f / 4f * 3f), (10f / 4f * 4f) };
            AreEqual(expected, result);
        }
        [TestMethod()]
        public void extendTest1() {
            Face ob = NewFace(width: 5, hight: 5, cut: NewCutBySlice(slice_count_x: 1, slice_count_y: 1));
            List<PointF>? result = new PrivateObject(ob: ob).Invoke(method_name: "_extendAndGetList") as List<PointF>;
            List<PointF> expected = new() {
                new(x: 0.0f, y: 0.0f), new(x: 2.5f, y: 0.0f), new(x: 5.0f, y: 0.0f),
                new(x: 0.0f, y: 2.5f), new(x: 2.5f, y: 2.5f), new(x: 5.0f, y: 2.5f),
                new(x: 0.0f, y: 5.0f), new(x: 2.5f, y: 5.0f), new(x: 5.0f, y: 5.0f)
            };
            AreEqual(expected, result);
        }
        [TestMethod()]
        public void extendTest2() {
            Face ob = NewFace(width: 12, hight: 12, cut: NewCutByPiece(piece_count_x: 3, piece_count_y: 4));
            List<PointF>? result = new PrivateObject(ob: ob).Invoke(method_name: "_extendAndGetList") as List<PointF>;
            List<PointF> expected = new() {
                new(x: 0.0f, y:  0.0f), new(x: 4.0f, y:  0.0f), new(x: 8.0f, y:  0.0f), new(x: 12.0f, y:  0.0f),
                new(x: 0.0f, y:  3.0f), new(x: 4.0f, y:  3.0f), new(x: 8.0f, y:  3.0f), new(x: 12.0f, y:  3.0f),
                new(x: 0.0f, y:  6.0f), new(x: 4.0f, y:  6.0f), new(x: 8.0f, y:  6.0f), new(x: 12.0f, y:  6.0f),
                new(x: 0.0f, y:  9.0f), new(x: 4.0f, y:  9.0f), new(x: 8.0f, y:  9.0f), new(x: 12.0f, y:  9.0f),
                new(x: 0.0f, y: 12.0f), new(x: 4.0f, y: 12.0f), new(x: 8.0f, y: 12.0f), new(x: 12.0f, y: 12.0f)
            };
            AreEqual(expected, result);
        }
    }
}
