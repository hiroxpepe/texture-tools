﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;

using System.Collections.Generic;
using static Texture.Core.Cut;
using static Texture.Core.Face;

namespace Texture.Core {
    [TestClass()]
    public class FaceTests {
        [TestMethod("Slices the face in X direction with single slice")]
        public void sliceTest1() {
            Face ob = NewFace(width: 5, height: 5, cut: NewCutBySlice(slice_count_x: 1, slice_count_y: 1));
            float[]? result = new PrivateObject(ob: ob).Invoke(method_name: "slice", args: Coordinate.X) as float[];
            float[] expected = new [] { 0.0f, 2.5f, 5.0f };
            AreEqual(expected, result);
        }

        [TestMethod("Slices the face in Y direction with single slice")]
        public void sliceTest2() {
            Face ob = NewFace(width: 5, height: 5, cut: NewCutBySlice(slice_count_x: 1, slice_count_y: 1));
            float[]? result = new PrivateObject(ob: ob).Invoke(method_name: "slice", args: Coordinate.Y) as float[];
            float[] expected = new[] { 0.0f, 2.5f, 5.0f };
            AreEqual(expected, result);
        }

        [TestMethod("Slices the face in X direction with multiple slices")]
        public void sliceTest3() {
            Face ob = NewFace(width: 10, height: 10, cut: NewCutBySlice(slice_count_x: 2, slice_count_y: 3));
            float[]? result = new PrivateObject(ob: ob).Invoke(method_name: "slice", args: Coordinate.X) as float[];
            float[] expected = new[] { 0.0f, (10f / 3f * 1f), (10f / 3f * 2f), (10f / 3f * 3f) };
            AreEqual(expected, result);
        }

        [TestMethod("Slices the face in Y direction with multiple slices")]
        public void sliceTest4() {
            Face ob = NewFace(width: 10, height: 10, cut: NewCutBySlice(slice_count_x: 2, slice_count_y: 3));
            float[]? result = new PrivateObject(ob: ob).Invoke(method_name: "slice", args: Coordinate.Y) as float[];
            float[] expected = new[] { 0.0f, (10f / 4f * 1f), (10f / 4f * 2f), (10f / 4f * 3f), (10f / 4f * 4f) };
            AreEqual(expected, result);
        }

        [TestMethod("Extends the face and gets list with single slice")]
        public void extendTest1() {
            Face ob = NewFace(width: 5, height: 5, cut: NewCutBySlice(slice_count_x: 1, slice_count_y: 1));
            List<Point>? result = new PrivateObject(ob: ob).Invoke(method_name: "_extend_and_get_list") as List<Point>;
            List<Point> expected = new() {
                new(x: 0.0f, y: 0.0f), new(x: 2.5f, y: 0.0f), new(x: 5.0f, y: 0.0f),
                new(x: 0.0f, y: 2.5f), new(x: 2.5f, y: 2.5f), new(x: 5.0f, y: 2.5f),
                new(x: 0.0f, y: 5.0f), new(x: 2.5f, y: 5.0f), new(x: 5.0f, y: 5.0f)
            };
            AreEqual(expected, result);
        }

        [TestMethod("Extends the face and gets list with multiple pieces")]
        public void extendTest2() {
            Face ob = NewFace(width: 12, height: 12, cut: NewCutByPiece(piece_count_x: 3, piece_count_y: 4));
            List<Point>? result = new PrivateObject(ob: ob).Invoke(method_name: "_extend_and_get_list") as List<Point>;
            List<Point> expected = new() {
                new(x: 0.0f, y:  0.0f), new(x: 4.0f, y:  0.0f), new(x: 8.0f, y:  0.0f), new(x: 12.0f, y:  0.0f),
                new(x: 0.0f, y:  3.0f), new(x: 4.0f, y:  3.0f), new(x: 8.0f, y:  3.0f), new(x: 12.0f, y:  3.0f),
                new(x: 0.0f, y:  6.0f), new(x: 4.0f, y:  6.0f), new(x: 8.0f, y:  6.0f), new(x: 12.0f, y:  6.0f),
                new(x: 0.0f, y:  9.0f), new(x: 4.0f, y:  9.0f), new(x: 8.0f, y:  9.0f), new(x: 12.0f, y:  9.0f),
                new(x: 0.0f, y: 12.0f), new(x: 4.0f, y: 12.0f), new(x: 8.0f, y: 12.0f), new(x: 12.0f, y: 12.0f)
            };
            AreEqual(expected, result);
        }

        [TestMethod("Creates 200% of the size to crop to 50%")]
        public void newTest1() {
            Cut cut = NewCutByPiece(piece_count_x: 7, piece_count_y: 7);
            Face result = NewFace(width: 256, height: 256, cut: cut, crop: 0.5d);
            Face expected = NewFace(width: 512, height: 512, cut: cut);
            Assert.AreEqual(expected.Width, result.Width);
            Assert.AreEqual(expected.Height, result.Height);
        }

        [TestMethod("Creates 133.33% of the size to crop to 75%")]
        public void newTest2() {
            Cut cut = NewCutByPiece(piece_count_x: 7, piece_count_y: 7);
            Face result = NewFace(width: 256, height: 256, cut: cut, crop: 0.75d);
            Face expected = NewFace(width: 341, height: 341, cut: cut);
            Assert.AreEqual(expected.Width, result.Width);
            Assert.AreEqual(expected.Height, result.Height);
        }

        [TestMethod("Creates 111.11% of the size to crop to 90%")]
        public void newTest3() {
            Cut cut = NewCutByPiece(piece_count_x: 7, piece_count_y: 7);
            Face result = NewFace(width: 256, height: 256, cut: cut, crop: 0.9d);
            Face expected = NewFace(width: 284, height: 284, cut: cut);
            Assert.AreEqual(expected.Width, result.Width);
            Assert.AreEqual(expected.Height, result.Height);
        }
    }
}