using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using static Texture.Core.Cut;

namespace Texture.Core {
    [TestClass()]
    public class CutTests {
        [TestMethod()]
        public void CountXTest1() {
            Cut ob = NewCutDefault();
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_x");
            AreEqual(3, result);
        }
        [TestMethod()]
        public void CountYTest1() {
            Cut ob = NewCutDefault();
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_y");
            AreEqual(3, result);
        }
        [TestMethod()]
        public void CountXTest2() {
            Cut ob = NewCutBySlice(slice_count_x: 0, slice_count_y: 0);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_x");
            AreEqual(1, result);
        }
        [TestMethod()]
        public void CountYTest2() {
            Cut ob = NewCutBySlice(slice_count_x: 0, slice_count_y: 0);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_y");
            AreEqual(1, result);
        }
        [TestMethod()]
        public void CountXTest3() {
            Cut ob = NewCutBySlice(slice_count_x: 1, slice_count_y: 1);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_x");
            AreEqual(2, result);
        }
        [TestMethod()]
        public void CountYTest3() {
            Cut ob = NewCutBySlice(slice_count_x: 1, slice_count_y: 1);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_y");
            AreEqual(2, result);
        }
        [TestMethod()]
        public void CountXTest4() {
            Cut ob = NewCutByPiece(piece_count_x: 0, piece_count_y: 0);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_x");
            AreEqual(0, result);
        }
        [TestMethod()]
        public void CountYTest4() {
            Cut ob = NewCutByPiece(piece_count_x: 0, piece_count_y: 0);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_y");
            AreEqual(0, result);
        }
        [TestMethod()]
        public void CountXTest5() {
            Cut ob = NewCutByPiece(piece_count_x: 1, piece_count_y: 1);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_x");
            AreEqual(1, result);
        }
        [TestMethod()]
        public void CountYTest5() {
            Cut ob = NewCutByPiece(piece_count_x: 1, piece_count_y: 1);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_get_count_y");
            AreEqual(1, result);
        }
    }
}