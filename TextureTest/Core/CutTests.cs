using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using static Texture.Core.Cut;

namespace Texture.Core {
    [TestClass()]
    public class CutTests {
        [TestMethod("Gets count X for default cut")]
        public void CountXTest1() {
            Cut ob = NewCutDefault();
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_x");
            AreEqual(3, result);
        }

        [TestMethod("Gets count Y for default cut")]
        public void CountYTest1() {
            Cut ob = NewCutDefault();
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_y");
            AreEqual(3, result);
        }

        [TestMethod("Gets count X for slice cut with zero slices")]
        public void CountXTest2() {
            Cut ob = NewCutBySlice(slice_count_x: 0, slice_count_y: 0);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_x");
            AreEqual(1, result);
        }

        [TestMethod("Gets count Y for slice cut with zero slices")]
        public void CountYTest2() {
            Cut ob = NewCutBySlice(slice_count_x: 0, slice_count_y: 0);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_y");
            AreEqual(1, result);
        }

        [TestMethod("Gets count X for slice cut with one slice")]
        public void CountXTest3() {
            Cut ob = NewCutBySlice(slice_count_x: 1, slice_count_y: 1);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_x");
            AreEqual(2, result);
        }

        [TestMethod("Gets count Y for slice cut with one slice")]
        public void CountYTest3() {
            Cut ob = NewCutBySlice(slice_count_x: 1, slice_count_y: 1);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_y");
            AreEqual(2, result);
        }

        [TestMethod("Gets count X for piece cut with zero pieces")]
        public void CountXTest4() {
            Cut ob = NewCutByPiece(piece_count_x: 0, piece_count_y: 0);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_x");
            AreEqual(0, result);
        }

        [TestMethod("Gets count Y for piece cut with zero pieces")]
        public void CountYTest4() {
            Cut ob = NewCutByPiece(piece_count_x: 0, piece_count_y: 0);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_y");
            AreEqual(0, result);
        }

        [TestMethod("Gets count X for piece cut with one piece")]
        public void CountXTest5() {
            Cut ob = NewCutByPiece(piece_count_x: 1, piece_count_y: 1);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_x");
            AreEqual(1, result);
        }

        [TestMethod("Gets count Y for piece cut with one piece")]
        public void CountYTest5() {
            Cut ob = NewCutByPiece(piece_count_x: 1, piece_count_y: 1);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_y");
            AreEqual(1, result);
        }
    }
}